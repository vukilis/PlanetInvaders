using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectDifficultyScript : MonoBehaviour
{
    public AudioSource music;

    void Start()
    {
        Time.timeScale = 1f;
        music.volume = PlayerPrefs.GetFloat("MusicVolume");
    }

    public void NormalGame()
    {
        Debug.Log("Normal");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void InsaneGame()
    {
        Debug.Log("Insane");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    public void BackToManu()
    {
        Debug.Log("BackToManu");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}