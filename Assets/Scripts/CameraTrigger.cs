using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    public CameraStateManager cameraState;
    public string cameraAnimName;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        cameraState.SwitchCamera(cameraAnimName);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        cameraState.SwitchDefault();
    }
}
