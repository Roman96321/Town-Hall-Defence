using UnityEngine;
using Zenject;

public class EnemyArrow : Arrow
{
    [Inject] private BuildingTakeDamage _buildingTakeDamage;
    [Inject] private PlayerHealth _playerHp;
    
    protected override void Attack(Collider other)
    {
        if (other.CompareTag(Tag.Player))
        {
            _playerHp.TakeDamage(_damage);
            Destroy(gameObject);
        }

        if (other.CompareTag(Tag.Building))
        {
            _buildingTakeDamage.TakeDamages(other.transform.parent.name.ToString(), _damage);
            Destroy(gameObject);
        }

        if (other.CompareTag(Tag.Soldier))
        {
            other.GetComponent<SoldierHealth>().TakeDamage(_damage);
            Destroy(gameObject);
        }
    }
}