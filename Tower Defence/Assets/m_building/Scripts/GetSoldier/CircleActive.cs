using UnityEngine;

public class CircleActive : MonoBehaviour
{
    [SerializeField] private GameObject _circle;

    private bool _clik = false;

    public void TouchButton()
    {
        _clik = !_clik;

        if (_clik)
            _circle.SetActive(true);
        else
            _circle.SetActive(false);
    }
}
