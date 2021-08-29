using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Water : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlatformerMovement player = collision.gameObject.GetComponent<PlatformerMovement>();
        if (player && player.isChad())
        {
            Debug.Log("Do all the death effects");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
