using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioSource music;

    void Start() {
        Time.timeScale = 1f;
        music.volume = PlayerPrefs.GetFloat("MusicVolume");
    }

    public void PlayGame() {
        Debug.Log("PLAY");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame() {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
