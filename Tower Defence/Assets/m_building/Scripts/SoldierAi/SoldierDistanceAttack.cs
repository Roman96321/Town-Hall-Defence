using UnityEngine;
using Zenject;

public class SoldierDistanceAttack : MonoBehaviour
{
    [Inject] private DiContainer _diContainer;

    public void DistantAttack(GameObject target, float damage, GameObject prefab)
    {
        GameObject arrow = _diContainer.InstantiatePrefab(prefab, transform.position, Quaternion.identity, null);

        SoldierArrow soldierArrow = arrow.GetComponent<SoldierArrow>();
        soldierArrow.Damage = damage;
        soldierArrow.Target = target;
    }
}