using UnityEngine;
using UnityEngine.UI;

public class DontUpBuildingButton : MonoBehaviour
{
    [SerializeField] private GameObject _player;

    private GameObject _prohibitedSign;
    private bool _clik = true;

    private void Start()
    {
        _prohibitedSign = transform.GetChild(1).gameObject;
    }

    public void TouchButton()
    {
        if (_clik)
            _player.tag = Tag.Untagged;
        else
            _player.tag = Tag.Player;

        _prohibitedSign.SetActive(!_prohibitedSign.activeSelf);
        _clik = !_clik;
    }
}
