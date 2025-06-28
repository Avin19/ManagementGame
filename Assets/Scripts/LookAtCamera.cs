using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    public enum Mode
    {
        LookAt,
        LookAtInverted,
        CamerForword,
        CamerForwordInverted,
    }

    [SerializeField] private Mode mode;

    void LateUpdate()
    {
        switch (mode)
        {
            case Mode.LookAt:
                transform.LookAt(Camera.main.transform);
                break;
            case Mode.LookAtInverted:
                Vector3 LookDir = transform.position - Camera.main.transform.position;
                transform.LookAt(transform.position + LookDir);
                break;
            case Mode.CamerForword:
                transform.forward = Camera.main.transform.forward;
                break;
            case Mode.CamerForwordInverted:
                transform.forward = -Camera.main.transform.forward;
                break;
        }
    }
}
