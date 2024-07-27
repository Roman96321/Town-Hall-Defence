using UnityEngine;
using Zenject;

[RequireComponent(typeof(PlayerRecovery), typeof(PlayerHpBar))]
public class PlayerHealth : MonoBehaviour
{
    [Inject] private PlayerProperties _playerProperties;

    private PlayerRecovery _playerRecovery;
    private bool _sliderIsTrue = false;  
    private PlayerHpBar _playerHpBar; 
    private float _maxHealth;
    private float _health;

    private void Start()
    {
        _playerRecovery = GetComponent<PlayerRecovery>();
        _playerHpBar = GetComponent<PlayerHpBar>();

        _health = _playerProperties.health;          
        _playerHpBar.sliderHp.maxValue = _health;
        _playerHpBar.sliderHp.value = _health;
        _maxHealth = _health;

        _playerHpBar.ActiveIsFalse();
    }

    private void CheakDie()
    {
        if (_health == _maxHealth)
            _playerHpBar.ActiveIsFalse();

        if (_sliderIsTrue)
        {
            _playerHpBar.SliderUpdate(_health);

            if (_health < _maxHealth)
                _playerHpBar.ActiveIsTrue();

            if (_health <= 0)
                GetComponent<GameOver>().GameIsAnd();
        }
        else
        {
            _playerHpBar.ActiveIsFalse();
        }           
    }

    public void TakeHealth(float hp)
    {
        if (_health + hp > _maxHealth)
        {
            _health = _maxHealth;
            CheakDie();
            return;
        }

        if (hp >= 0)
            _health += hp;

        CheakDie();
    }

    public void TakeDamage(float damage)
    {
        if (damage >= 0)       
            _health -= damage;

        _playerRecovery.recoveryTimer = 0;
        _sliderIsTrue = true;
        CheakDie();
    }
}