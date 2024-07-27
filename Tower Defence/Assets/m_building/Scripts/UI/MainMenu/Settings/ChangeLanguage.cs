using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLanguage : MonoBehaviour
{
    public void Change(int value)
    {
        PlayerPrefs.SetInt(Prefs.Language, value);
        SceneManager.LoadScene(Scene.MainMenu);
    }
}
