using UnityEngine;

[RequireComponent(typeof(SoldierDistanceAttack))]
public class ArcherSoldier : Soldier
{
    [SerializeField] private ArcherSoldierPropertie _properties;

    private SoldierDistanceAttack _distanceAttack;
    private float _spareDistance = 2;

    private new void Awake()
    {
        base.Awake();

        _distanceAttack = GetComponent<SoldierDistanceAttack>();
        _soldierProperties = _properties;
    }

    protected override void Attack()
    {
        float distance = Vector3.Distance(transform.position, _target.transform.position) - _spareDistance;

        if (distance <= _agent.stoppingDistance)
            _distanceAttack.DistantAttack(_target, _soldierProperties.damage, _properties.prefab);
    }
}