using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartScene : MonoBehaviour
{

    public void RestartCurrentScene()
    {
        PlayerPrefs.SetInt("skipMainMenu", 1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
