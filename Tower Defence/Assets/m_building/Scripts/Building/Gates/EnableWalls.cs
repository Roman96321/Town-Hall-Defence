using UnityEngine;

public class EnableWalls : MonoBehaviour
{
    [SerializeField] private GameObject _walls;

    private void Start()
    {
        _walls.SetActive(true);
    }
}
