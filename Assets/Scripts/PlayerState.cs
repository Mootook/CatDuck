using System.Collections;
using UnityEngine;
public class PlayerState : MonoBehaviour
{
    [Header("Movement settings")]
    public float lateralSpeedMultipiler;
    public float fallMultiplier;
    public float lowJumpMultiplier;
    public float jumpMultiplier;
    public float dashDistance;

    public GameObject companion;

    [Header("Audio")]
    public AudioClip walkingSound;
    public AudioClip jumpSound;
    public AudioClip dashSound;
}

