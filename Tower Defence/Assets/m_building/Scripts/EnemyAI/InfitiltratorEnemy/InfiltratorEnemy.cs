using UnityEngine;
using System.Collections;

[RequireComponent(typeof(EnemyMelleAttack))]
public class InfiltratorEnemy : Enemy
{
    [SerializeField] private EnemyProperties _properties;

    private EnemyMelleAttack _enemyMelleAttack;
    private bool _waitAttacks = true;

    private void Awake()
    {
        _enemyProperties = _properties;
        _enemyMelleAttack = GetComponent<EnemyMelleAttack>();
    }
    
    protected override void FixedUpdate()
    {
        Move(_townHallPosition);
         _target = _searchObject.GetObject(_enemyProperties.buildingAgreRange, Tag.Building);

        if (_target == null)
            return;

        if (_target.transform.parent.name[default].ToString() == "0")
        {
            if (_waitAttacks)
            {   
                _waitAttacks = false;    
                StartCoroutine(WaitAttack());   
            }
        }        
    }

    private IEnumerator WaitAttack()
    {     
        yield return new WaitForSeconds(_enemyProperties.attackSpeed);
        _enemyMelleAttack.MelleAttack(_target, _enemyProperties.damage);
        _waitAttacks = true;
    }
}