using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{  
    [SerializeField] private Slider _sliderHp;

    private float _enemyHp;

    private void Start()
    {
        _enemyHp = GetComponent<Enemy>().GetPropertiesHealt();

        _sliderHp.maxValue = _enemyHp;
        _sliderHp.value = _enemyHp;
    }

    private void CheakDeadAndDestroy()
    {
        _sliderHp.value = _enemyHp;

        if (_enemyHp < _sliderHp.maxValue)
            _sliderHp.gameObject.SetActive(true);

        if (_enemyHp <= 0)
            Destroy(gameObject);       
    }

    public void TakeDamage(float damage)
    {
        if (damage >= 0)
            _enemyHp -= damage;

        CheakDeadAndDestroy();
    }
}