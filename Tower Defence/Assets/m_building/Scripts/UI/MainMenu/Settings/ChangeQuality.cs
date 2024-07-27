using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeQuality : MonoBehaviour
{
    public void Change(int qualityValue)
    {
        QualitySettings.SetQualityLevel(qualityValue);
        PlayerPrefs.SetInt(Prefs.Quality, qualityValue);

        SceneManager.LoadScene(Scene.MainMenu);        
    }
}