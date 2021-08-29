using UnityEngine;

public class CameraStateManager : MonoBehaviour
{
    private Animator animator;

    private bool defaultFollow = true;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void SwitchCamera ()
    {
        if (defaultFollow)
            animator.Play("FollowLookAhead");
        else
            animator.Play("FollowDefault");

        defaultFollow = !defaultFollow;
    }
}
