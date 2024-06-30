using UnityEngine;

public class BaseCounter : MonoBehaviour, IkitchenObjectParent
{

   [SerializeField] private Transform counterTop;
   private KitchenObject kitchenObject;

   public virtual void Interact(Player player)
   {
      Debug.Log("baseCounter.interact()");
   }
   public Transform GetKitchenobjectFollowTransform()
   {
      return counterTop;
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
