using UnityEngine;

public class PatticalSystemActive : MonoBehaviour
{
    [SerializeField] private GameObject _partical;

    private void OnEnable()
    {
        _partical.SetActive(true);
    }

    private void OnDisable()
    {
        _partical.SetActive(false);
    }
}
