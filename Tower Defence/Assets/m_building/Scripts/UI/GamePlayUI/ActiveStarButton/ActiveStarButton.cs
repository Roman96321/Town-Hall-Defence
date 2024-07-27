using UnityEngine;

public class ActiveStarButton : MonoBehaviour
{
    [SerializeField] private StarVisibility _getStar;

    private GameObject _prohibitedSign;

    private void Start()
    {
        _prohibitedSign = transform.GetChild(1).gameObject;
    }

    public void TouchButton()
    {
        _prohibitedSign.SetActive(!_prohibitedSign.activeSelf);
        _getStar.ActiveStar();
    }
}
