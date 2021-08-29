using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class HighFive : MonoBehaviour
{
    public static event Action onHighFivePlay;
    private int loopCount;

    public void OnStartAnimation ()
    {
        if (onHighFivePlay != null)
            onHighFivePlay();
    }

    public void OnDidCompleteAnimation ()
    {
        gameObject.SetActive(false);
    }
}
