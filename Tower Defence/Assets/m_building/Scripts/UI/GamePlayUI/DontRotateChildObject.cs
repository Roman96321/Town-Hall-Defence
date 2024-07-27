using UnityEngine;

public class DontRotateChildObject : MonoBehaviour
{
    private Transform _transform;

    private void Start()
    {
        _transform = transform;
    }

    private void FixedUpdate()
    {
        if (_transform.rotation != Quaternion.Euler(30, 0, 0))
            _transform.rotation = Quaternion.Euler(30, 0, 0);
    }
}
