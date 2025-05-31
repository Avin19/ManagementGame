using System;
using UnityEngine;

public class Player : MonoBehaviour, IkitchenObjectParent
{

   public static Player Instance { get; private set; }
   [SerializeField] private float movSpeed = 7f;
   [SerializeField] private GameInput gameInput;
   [SerializeField] private LayerMask counterLayer;
   private BaseCounter selectedCounter;
   private bool isWalking;
   private Vector3 lastInteraction;
   private KitchenObject kitchenObject;
   [SerializeField] private Transform kitchenobjectHoldPosition;
   public event EventHandler<OnSelectedCounterChangedEventArgs> OnSelectedCounterChanged;

   public class OnSelectedCounterChangedEventArgs : EventArgs
   {
      public BaseCounter selectCounter;

   }
   //Signleton Behaviour
   private void Awake()
   {
      if (Instance != null)
      {
         Debug.Log("There is more than one player Instances");
      }
      Instance = this;
   }
   private void Start()
   {
      // Subscriber of OnInteractionAction 
      gameInput.OnInteractAction += GameInput_OnInteractAction;
   }

   private void GameInput_OnInteractAction(object sender, EventArgs e)
   {
      if (selectedCounter != null)
      {
         // Calling the  Interact function and passing player as a reference 
         selectedCounter.Interact(this);
      }

   }

   private void Update()
   {
      HandleMovement();
      HandleInteraction();
   }
   public bool IsWalking()
   {
      return isWalking;
   }
   private void HandleInteraction()
   {
      Vector2 inputVector = gameInput.GetMovementVectorNormalized();
      Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);
      if (moveDir != Vector3.zero)
      {
         lastInteraction = moveDir;
      }
      float interactDistance = 2f;
      if (Physics.Raycast(transform.position, lastInteraction, out RaycastHit raycastHit, interactDistance, counterLayer))
      {
         if (raycastHit.transform.TryGetComponent(out BaseCounter baseCounter))
         {
            // Has ClearCounter
            if (baseCounter != selectedCounter)
            {
               SetSelectCounter(baseCounter);
            }


         }
         else
         {
            SetSelectCounter(null);
         }
      }
      else
      {
         SetSelectCounter(null);
      }

   }
   private void HandleMovement()
   {
      Vector2 inputVector = gameInput.GetMovementVectorNormalized();


      Vector3 movDir = new Vector3(inputVector.x, 0f, inputVector.y);


      float moveDistance = movSpeed * Time.deltaTime;
      float playerRaduis = 0.7f;
      float playerHeight = 2f;

      bool canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRaduis, movDir, moveDistance);
      if (!canMove)
      {   // Attemting to move in x direction only
         Vector3 moveDirx = new Vector3(movDir.x, 0f, 0f).normalized;
         canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRaduis, moveDirx, moveDistance);
         if (canMove)
         {
            // can move in x direction only
            movDir = moveDirx;
         }
         else
         { // Attempting to move in z direction only
            Vector3 moveDirz = new Vector3(0f, 0f, movDir.z).normalized;
            canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRaduis, moveDirz, moveDistance);
            if (canMove)
            { // can move in z direction 
               movDir = moveDirz;
            }
            else
            {
               // Can't move in any direction 
            }
         }





      }
      if (canMove)
      {
         transform.position += movDir * movSpeed * Time.deltaTime;
      }
      isWalking = movDir != Vector3.zero;
      float rotationSpeed = 10f;
      transform.forward = Vector3.Slerp(transform.forward, movDir, Time.deltaTime * rotationSpeed);

   }
   private void SetSelectCounter(BaseCounter selectCounter)
   {
      this.selectedCounter = selectCounter;
      OnSelectedCounterChanged?.Invoke(this, new OnSelectedCounterChangedEventArgs { selectCounter = selectCounter });

   }
   public Transform GetKitchenobjectFollowTransform()
   {
      return kitchenobjectHoldPosition;
   }
   // setting up the kitchen object to this counter
   public void SetKitchenObject(KitchenObject kitchenObject)
   {
      this.kitchenObject = kitchenObject;
   }
   // getting to know if kitchen object is aalready there
   public KitchenObject GetKitchenObject()
   {
      return kitchenObject;
   }
   //after sending kitchen object setting up to null 
   public void ClearKitchenObject()
   {
      kitchenObject = null;
   }
   public bool HasKitchenObject()
   {
      return kitchenObject != null;
   }
}
