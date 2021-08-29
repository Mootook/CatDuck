using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{

    private bool isPlayingCinematicMusic = false;

    public AudioSource audioSource;
    public AudioClip cinematicMusic;
    public AudioClip themeMusic;

    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    private void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        string sceneName = scene.name;

        if (sceneName.Equals("Intro_Cinematic") || sceneName.Equals("Outro_Cinematic"))
            PlayCinematicMusic();
        else
            PlayThemeMusic();
    }

    private void PlayCinematicMusic ()
    {
        if (!isPlayingCinematicMusic)
        {
            audioSource.clip = cinematicMusic;
            audioSource.Play();
            isPlayingCinematicMusic = true;
        }

    }

    private void PlayThemeMusic ()
    {
        if (isPlayingCinematicMusic || !audioSource.isPlaying)
        {
            audioSource.clip = themeMusic;
            audioSource.Play();
            isPlayingCinematicMusic = false;
        }
    }

}
