using System.Collections;
using UnityEngine;
using Zenject;

public class EnemyMelleAttack : MonoBehaviour
{
    [SerializeField] private Animation _animation;

    [Inject] private BuildingTakeDamage _buildingTakeDamage;
    [Inject] private PlayerHealth _playerHp;
    
    private float _animationSpeed = 0.5f;

    public void MelleAttack(GameObject target, float damage)
    {
        StartCoroutine(Attack(target, damage));
    }

    public IEnumerator Attack(GameObject target, float damage)
    {
        _animation.Play();

        yield return new WaitForSeconds(_animationSpeed);

        if (target == null)
            yield break;

        if (target.CompareTag(Tag.Building))    
            _buildingTakeDamage.TakeDamages(target.transform.parent.name.ToString(), damage);

        if (target.CompareTag(Tag.Player))
            _playerHp.TakeDamage(damage);

        if (target.CompareTag(Tag.Soldier))
            target.GetComponent<SoldierHealth>().TakeDamage(damage);
    }
}