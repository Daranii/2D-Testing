using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Menu : MonoBehaviour
{
    public SceneLoader sceneLoader;
    public GameObject menu;
    public void PlayGame()
    {
        menu.SetActive(false);
        sceneLoader.FadeToLoad();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
