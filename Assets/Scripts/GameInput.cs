using System;
using UnityEngine;


public class GameInput : MonoBehaviour
{
    public event EventHandler OnInteractAction;
    public event EventHandler OnInteractAltAction;
    private PlayerInputAction playInputAction;
    private void Awake()
    {
        playInputAction = new PlayerInputAction();
        playInputAction.Player.Enable();
        playInputAction.Player.Interact.performed += Interact_performed;
        playInputAction.Player.InteractAlt.performed += Interact_performedAlt;

    }

    private void Interact_performedAlt(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnInteractAltAction?.Invoke(this, EventArgs.Empty);
    }

    private void Interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        /* if(OnInteractAction!= null)
        {
            OnInteractAction (this, EventAArgs.Empty);
        }

        */
        OnInteractAction?.Invoke(this, EventArgs.Empty);
    }
    public Vector2 GetMovementVectorNormalized()
    {
        Vector2 inputVector = playInputAction.Player.Move.ReadValue<Vector2>();
        inputVector = inputVector.normalized;

        return inputVector;
    }
}
