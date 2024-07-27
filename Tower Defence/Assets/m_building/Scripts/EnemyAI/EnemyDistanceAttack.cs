using UnityEngine;
using Zenject;

public class EnemyDistanceAttack : MonoBehaviour
{
    [Inject] private DiContainer _diContainer;

    public void DistantAttack(GameObject target, float damage, GameObject prefab)
    {
        GameObject arrow = _diContainer.InstantiatePrefab(prefab, transform.position, Quaternion.identity, null);

        arrow.GetComponent<EnemyArrow>().Damage = damage;
        arrow.GetComponent<EnemyArrow>().Target = target;        
    }
}