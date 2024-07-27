using UnityEngine;

public class SoldierMelleAttack : MonoBehaviour
{
    [SerializeField] private Animation _animation;

    public void MelleAttack(GameObject target, float damage)
    {
        _animation.Play();
        target.GetComponent<EnemyHealth>().TakeDamage(damage);
    }
}