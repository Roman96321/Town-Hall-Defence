using UnityEngine;

public class LookPlayer : MonoBehaviour
{
    [SerializeField] private float _smoothSpeed;
    [SerializeField] private Transform _player;        
    [SerializeField] private Vector3 _offset;          
    
    private Transform _transform;

    private void Start()
    {
        _transform = transform;
    }

    private void LateUpdate()
    {
        Vector3 desiredPosition = _player.position + _offset;
        Vector3 smoothedPosition = Vector3.Lerp(_transform.position, desiredPosition, _smoothSpeed);

        _transform.position = smoothedPosition;
    }
}