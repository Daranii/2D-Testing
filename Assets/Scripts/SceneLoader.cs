using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// TO DO: Implement Singleton in SceneLoader but without persistance to be able to have custom settings on a per scene basis.
public class SceneLoader : MonoBehaviour
{
    /*  [SerializeField]
        private GameObject loadingScreen;*/
    [SerializeField]
    private GameObject sliderGO = null;
    [SerializeField]
    private GameObject loadTextGO = null;
    [SerializeField]
    private Slider slider = null;
    [SerializeField]
    private Text progressText = null;
    [SerializeField]
    private Animator animator = null;

    public void FadeToLoad()
    {
        if (SceneManager.GetActiveScene().buildIndex < SceneManager.sceneCountInBuildSettings - 1)
        {
            animator.SetTrigger("FadeIn");
        }
    }

    public void FadeToLevel()
    {
        animator.SetTrigger("FadeOut");
    }

    public void LoadScene()
    {
        // TO DO: Fix hardcoding to next scene number 
        sliderGO.SetActive(true);
        loadTextGO.SetActive(true);
        StartCoroutine(LoadAsync(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void FinishLoadScene()
    {
        sliderGO.SetActive(false);
        loadTextGO.SetActive(false);
    }

    IEnumerator LoadAsync(int index)
    {
        AsyncOperation data = SceneManager.LoadSceneAsync(index);

        while (!data.isDone)
        {
            float progress = Mathf.Clamp01(data.progress / 0.9f);
            slider.value = progress;
            progressText.text = progress * 100f + "%";

            yield return null;
        }
    }

    void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //    FadeToLoad();
    }
}
