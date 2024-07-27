using System.Collections;
using UnityEngine.AI;
using UnityEngine;

[RequireComponent(typeof(SearchObject), typeof(NavMeshAgent))]
public class Enemy : MonoBehaviour 
{ 
    protected EnemyProperties _enemyProperties;
    protected bool _imGoToTownHall = true;
    protected SearchObject _searchObject;
    protected Vector3 _townHallPosition;
    protected NavMeshAgent _agent;
    protected GameObject _target; 

    private bool _waitAttack = true;
    private bool _waitSearh = true;

    protected void Start() 
    {
        _townHallPosition = new Vector3(0, 0, 0);

        _searchObject = GetComponent<SearchObject>();
        _agent = GetComponent<NavMeshAgent>();   
        
        _agent.stoppingDistance = _enemyProperties.stopDistance;
        _agent.speed = _enemyProperties.moveSpeed;
    }

    protected virtual void FixedUpdate()
    {
        if (_waitSearh)
        {
            StartCoroutine(SearhTarget());
            _waitSearh = false;
        }

        if (_target != null)
        {
            if (_waitAttack)
            {
                _waitAttack = false;
                StartCoroutine(WaitAttack());
            }
            Move(_target.transform.position);
        }
    }

    private IEnumerator SearhTarget()
    {
        yield return new WaitForSeconds(1);
        _waitSearh = true;

        if (_imGoToTownHall)
            Move(_townHallPosition);

        GameObject target = FindTargetInRange(_enemyProperties.playerAgreRange, Tag.Player) ?? 
            FindTargetInRange(_enemyProperties.soldierAgreRange, Tag.Soldier) ?? 
            FindTargetInRange(_enemyProperties.buildingAgreRange, Tag.Building);

        if (target)
        {
            _target = target;
            yield break;
        } 

        _target = null;
        _imGoToTownHall = true;
    }

    protected virtual void Attack(){}

    private IEnumerator WaitAttack()
    {
        Attack();
        yield return new WaitForSeconds(_enemyProperties.attackSpeed);
        _waitAttack = true;
    }

    private GameObject FindTargetInRange(float range, string tag)
    {
        return _searchObject.GetObject(range, tag);
    }

    protected void Move(Vector3 target)
    {
        _agent.SetDestination(target); 
    }

    public float GetPropertiesHealt()
    {
        return _enemyProperties.health;
    }
}