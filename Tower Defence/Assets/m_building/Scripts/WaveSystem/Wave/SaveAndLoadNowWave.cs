using UnityEngine;

[RequireComponent(typeof(WaveStateHandler))]
public class SaveAndLoadNowWave : MonoBehaviour
{
    private JsonSaveServise _saveServise = new JsonSaveServise();
    private NowWave _waveSaveClass = new NowWave();
    private WaveStateHandler _waveState;

    private void Awake()
    {
        _waveState = GetComponent<WaveStateHandler>();
        Load();
    }

    public void Save()
    {
        _waveSaveClass.nowWave = _waveState.nowWave;
        _saveServise.Save(Json.Wave, _waveSaveClass);
    }

    public void Load()
    {
        NowWave nowWave = JsonUtility.FromJson<NowWave>(_saveServise.Load(Json.Wave));

        if (nowWave == null)
            return;
        
        _waveState.nowWave = nowWave.nowWave;
    }

    private void OnApplicationQuit()
    {
        Save();
    }
}

[SerializeField]
class NowWave
{
    public int nowWave;
}
