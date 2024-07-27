using UnityEngine;
using UnityEngine.UI;

public class PlayerHpBar : MonoBehaviour
{
    public Slider sliderHp;

    public void ActiveIsTrue()
    { 
        sliderHp.gameObject.SetActive(true);
    }

    public void ActiveIsFalse() 
    {
        sliderHp.gameObject.SetActive(false);
    }

    public void SliderUpdate(float health) 
    {
        sliderHp.value = health;
    }
}
