using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Menu : MonoBehaviour
{
    [SerializeField]
    private SceneLoader sceneLoader = null;
    [SerializeField]
    private GameObject menu = null;
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
