using UnityEngine;

public class SoldierArrow : Arrow
{

    protected override void Attack(Collider other)
    {
        if (other.CompareTag(Tag.Enemy))
        {
            other.GetComponent<EnemyHealth>().TakeDamage(_damage);
            Destroy(gameObject);
        }
        else
        {
            if (_target == null)
                Destroy(gameObject);
        }
    }
}