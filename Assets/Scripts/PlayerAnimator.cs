using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] Player player;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        animator.SetBool("IsWallking", player.IsWalking());

    }
}
