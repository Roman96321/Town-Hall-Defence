using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(SearchObject), typeof(NavMeshAgent))]
public class Soldier : MonoBehaviour
{
    protected SoldierProperties _soldierProperties;
    protected SearchObject _searchObject;
    protected NavMeshAgent _agent;
    protected GameObject _target;

    private bool _waitAttack = true;
    private bool _stop = true;

    protected void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _searchObject = GetComponent<SearchObject>();
    }

    protected void Start()
    {
        _agent.speed = _soldierProperties.moveSpeed;
        _agent.stoppingDistance = _soldierProperties.stopDistance;
    }

    protected void FixedUpdate()
    {
        if (_stop == false)
        {
            if (_agent.remainingDistance <= 3 && _agent.remainingDistance != 0)
            {
                _agent.stoppingDistance = _soldierProperties.stopDistance;
                _stop = true;
            }
            return;
        }

        if (_target != null)
        {
            if (_waitAttack)
            {
                _waitAttack = false;
                StartCoroutine(WaitAttack());
                Attack();
            }
            Move(_target.transform);
        }

        GameObject enemyTarget = _searchObject.GetObject(_soldierProperties.agrRange, Tag.Enemy);

        if (enemyTarget)
        {
            _target = enemyTarget;
            return;
        }
        _target = null;

        if (_agent.remainingDistance > 1)
            Move(transform);
    }

    protected virtual void Attack(){}

    private IEnumerator WaitAttack()
    {
        yield return new WaitForSeconds(_soldierProperties.attackSpeed);
        _waitAttack = true;
    }

    private void Move(Transform target) 
    {
        _agent.SetDestination(target.position); 
    }

    public void SetPosition(Vector3 targetPosition)
    {
        _agent.stoppingDistance = 2;
        _stop = false;
        _agent.SetDestination(targetPosition);
    }

    public float GetPropertiesHealt()
    {
        return _soldierProperties.health;
    }
}