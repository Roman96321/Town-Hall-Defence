using UnityEngine;

[RequireComponent(typeof(ColliderManipulate))]
public class TownHall : MonoBehaviour
{
    private ColliderManipulate _colliderManipulate;
    public static float nowUp = 1;

    private void Start()
    {
        _colliderManipulate = GetComponent<ColliderManipulate>();
        _colliderManipulate.FirstUpgrade(gameObject.name);
    }
}