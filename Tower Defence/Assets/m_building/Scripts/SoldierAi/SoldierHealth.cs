using UnityEngine;
using UnityEngine.UI;
using Zenject;

[RequireComponent(typeof(Soldier))]
public class SoldierHealth : MonoBehaviour
{
    [SerializeField] private Slider _sliderHp;

    [Inject] private WaveStateHandler _waveState;
    
    private float _health;

    private void Start()
    {
        _health = GetComponent<Soldier>().GetPropertiesHealt();

        _sliderHp.maxValue = _health;
        _sliderHp.value = _health;
    }

    private void ResetHealth()
    {
        _health = _sliderHp.maxValue;
        _sliderHp.value = _health;
    }

    private void CheakDeadAndDestroy()
    {
        _sliderHp.value = _health;
        if (_health < _sliderHp.maxValue)
            _sliderHp.gameObject.SetActive(true);

        if (_health <= 0)
            Destroy(gameObject);
    }

    public void TakeDamage(float damage)
    {
        if (damage >= 0)
            _health -= damage;

        CheakDeadAndDestroy();
    }

    private void OnEnable()
    {
        _waveState.onWaveFalse += ResetHealth;
    }

    private void OnDisable()
    {
        _waveState.onWaveFalse -= ResetHealth;
    }
}