using UnityEngine;

[RequireComponent(typeof(EnemyMelleAttack))]
public class KnightEnemy : Enemy
{
    [SerializeField] private KnightEnemyProperties _properties;

    private EnemyMelleAttack _enemyMelleAttack;
    private float _spareDistance = 5; 
    
    private void Awake()
    {
        _enemyMelleAttack = GetComponent<EnemyMelleAttack>();
        _enemyProperties = _properties;
    }

    protected override void Attack()
    {
        float distance = Vector3.Distance(transform.position, _target.transform.position) - _spareDistance;

        if (distance <= _agent.stoppingDistance)    
            _enemyMelleAttack.MelleAttack(_target, _enemyProperties.damage);

        _imGoToTownHall = false;
    }
}