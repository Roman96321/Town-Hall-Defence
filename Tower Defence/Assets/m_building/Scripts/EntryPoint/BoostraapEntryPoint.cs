using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoostraapEntryPoint : MonoBehaviour
{
    [SerializeField] private GameObject _loadingWindow;

    private float _loadingTime = 1.5f;

    private IEnumerator Start()
    {     
        Instantiate(_loadingWindow);

        Application.targetFrameRate = 30;
        Screen.sleepTimeout = SleepTimeout.NeverSleep;

        if (Application.systemLanguage == SystemLanguage.Ukrainian)
            PlayerPrefs.SetInt(Prefs.Language, 1);
        else
            PlayerPrefs.SetInt(Prefs.Language, 0);

        PlayerPrefs.Save();

        QualitySettings.SetQualityLevel(PlayerPrefs.GetInt(Prefs.Quality));

        yield return new WaitForSeconds(_loadingTime);

        SceneManager.LoadScene(Scene.MainMenu);
    }
}