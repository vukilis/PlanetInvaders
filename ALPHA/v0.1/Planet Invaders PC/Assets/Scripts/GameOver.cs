using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void restartScene()
    {
        SceneManager.LoadScene("Leve 1");
        scoreScript.scoreValue = 0;
    }

    public void restartSceneInsane()
    {
        SceneManager.LoadScene("Leve 2");
        scoreScript.scoreValue = 0;
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
        scoreScript.scoreValue = 0;
    }
}

