using TMPro;
using UnityEngine;
using Zenject;

public class EnemyCountView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] _text;
    [SerializeField] private string[] _englishText;
    [SerializeField] private string[] _ukraineText;
    [SerializeField] private Wave _wave;      

    [Inject] private WaveStateHandler _waveState;

    private string[][] currentLocalization = new string[2][];

    private void Awake()
    {
        currentLocalization[0] = _englishText;
        currentLocalization[1] = _ukraineText;
    }

    private void SetEnemyCount()
    {
        var waveStages = _wave.WaveProperties[_waveState.nowWave].stage;

        for (int i = 0; i < _text.Length; i++)
        {
            _text[i].text = currentLocalization[PlayerPrefs.GetInt(Prefs.Language)][i] + ": " + waveStages.enemyCount[i];
        }   
    }

    private void OnEnable()
    {
        SetEnemyCount();
    }
}