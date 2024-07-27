using TMPro;
using UnityEngine;

public class StateButton : MonoBehaviour
{ 
    private TextMeshProUGUI _enebleText;
    private bool _click = true;

    private void Start()
    {
        _enebleText = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
    }

    public void TouchButton()
    {      
        if (_click)
        {
            _enebleText.text = "0/10";
            _enebleText.gameObject.SetActive(true);
        }
        else
        {
            _enebleText.gameObject.SetActive(false);
        }
           
        _click = !_click;
    }

    public void ChangeSoldierCount(int count = default)
    {
        _enebleText.text = $"{count}/10";
    }
}
