using UnityEngine;
using UnityEngine.UI;

public class VolumeButton : MonoBehaviour
{
    [SerializeField] private Sprite spriteVolumeMute;
    [SerializeField] private Sprite spriteVolume;

    private int _disableVolume = 0;
    private int _enableVolume = 1;
    private Image image; 

    private void Start()
    {
        image = GetComponent<Image>();

        if (PlayerPrefs.GetInt(Prefs.Volume) == _disableVolume)
            SetVolume(spriteVolumeMute, _disableVolume);
        else
            SetVolume(spriteVolume, _enableVolume);
    }

    public void Clic()
    {
        if (image.sprite == spriteVolume)
            SetVolume(spriteVolumeMute, _disableVolume);
        else
            SetVolume(spriteVolume, _enableVolume);
    }

    private void SetVolume(Sprite sprite, int value)
    {
        image.sprite = sprite;
        PlayerPrefs.SetInt(Prefs.Volume, value);

        AudioListener.volume = value;
    }
}
