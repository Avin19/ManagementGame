using System;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    public event EventHandler OnInteractAction;
    private PlayerInputAction playInputAction;
    private void Awake()
    {
        playInputAction = new PlayerInputAction();
        playInputAction.Player.Enable();
        playInputAction.Player.Interact.performed += Interact_performed;

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
