using UnityEngine;

[RequireComponent(typeof(EnemyDistanceAttack))]
public class ArcherEnemy : Enemy
{
    [SerializeField] private ArcherEnemyProperties _properties;

    private EnemyDistanceAttack _distanceAttack;
    private float _spareDistance = 2;
    
    private void Awake()
    {
        _distanceAttack = GetComponent<EnemyDistanceAttack>();
        _enemyProperties = _properties;
    }  

    protected override void Attack()
    {
        float distance = Vector3.Distance(transform.position, _target.transform.position) - _spareDistance;

        if (distance <= _agent.stoppingDistance)
            _distanceAttack.DistantAttack(_target, _properties.damage, _properties.prefab);

        _imGoToTownHall = false;               
    }
}