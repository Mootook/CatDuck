using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    public CameraStateManager cameraState;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        cameraState.SwitchCamera();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        cameraState.SwitchCamera();
    }
}
