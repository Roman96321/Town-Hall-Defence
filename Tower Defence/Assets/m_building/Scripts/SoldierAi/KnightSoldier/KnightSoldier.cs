using UnityEngine;

[RequireComponent(typeof(SoldierMelleAttack))]
public class KnightSoldier : Soldier
{
    [SerializeField] private KnightSoldierProperties _properties;

    private SoldierMelleAttack _melleAttack;
    private float _spareDistance = 2;   

    private new void Awake()
    {
        base.Awake();

        _melleAttack = GetComponent<SoldierMelleAttack>();
        _soldierProperties = _properties;      
    }

    protected override void Attack()
    {
        float distance = Vector3.Distance(transform.position, _target.transform.position) - _spareDistance;

        if (distance <= _agent.stoppingDistance)
            _melleAttack.MelleAttack(_target, _soldierProperties.damage);
    }
}