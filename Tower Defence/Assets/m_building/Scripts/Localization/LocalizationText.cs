using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class LocalizationText : MonoBehaviour
{
    [SerializeField] private string[] _localizationText;

    private TextMeshProUGUI _viewText;

    private void Start()
    {
        _viewText = GetComponent<TextMeshProUGUI>();
        _viewText.text = _localizationText[PlayerPrefs.GetInt(Prefs.Language)];
    }
}