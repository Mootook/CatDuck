using UnityEngine;

public class CameraStateManager : MonoBehaviour
{
    public static string DEFAULT = "FollowDefault";
    public static string LA_1 = "FollowLookAhead";
    public static string LA_2 = "FollowLookAhead2";
    public static string LA_3 = "FollowLookAhead3";
     
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void SwitchCamera (string cameraAnimName)
    {
        animator.Play(cameraAnimName);
    }

    public void SwitchDefault ()
    {
        SwitchCamera(DEFAULT);
    }
}
