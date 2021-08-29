using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip startSound;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void StartGame ()
    {
        StartCoroutine(StartGameAfterAudioShot());
    }

    private IEnumerator StartGameAfterAudioShot ()
    {
        audioSource.PlayOneShot(startSound);
        yield return new WaitWhile(() => audioSource.isPlaying);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
    public void QuitGame ()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
