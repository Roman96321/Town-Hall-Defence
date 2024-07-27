using TMPro;
using UnityEngine;

public class QualityTextChanged : MonoBehaviour
{
    [SerializeField] private string[] _localizationText;
    [SerializeField] private string[] _qualityLocalizationUK;
    [SerializeField] private string[] _qualityLocalizationUA;

    private TextMeshProUGUI _text;

    private void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();

        string[][] quality = new string[_localizationText.Length][];
        quality[0] = _qualityLocalizationUK;
        quality[1] = _qualityLocalizationUA;
        
        int localization = PlayerPrefs.GetInt(Prefs.Language);
        _text.text = _localizationText[localization] + " " + quality[localization][PlayerPrefs.GetInt(Prefs.Quality)];
    }
}