using UnityEngine;
using Zenject;

public class EnemyFactory : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPoint;
    [SerializeField] private GameObject[] _enemys;

    [Inject] private DiContainer _container;

    private float _spawnRange = 2;

    public GameObject[] Create(int enemyValue, int spawnPointValue, int count)
    {
        GameObject[] objects = new GameObject[count];

        for (int i = 0; i < count; i++)
        {
            Vector3 origin = spawnPoint[spawnPointValue - 1].position;
            float randomX = Random.Range(-_spawnRange, _spawnRange);
            float randomZ = Random.Range(-_spawnRange, _spawnRange);

            objects[i] = _container.InstantiatePrefab(_enemys[enemyValue], new Vector3(origin.x + randomX, origin.y, origin.z + randomZ), Quaternion.identity, null);
        }
        return objects;
    }
}