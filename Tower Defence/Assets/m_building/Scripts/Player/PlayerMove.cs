using UnityEngine;
using Zenject;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Joystick _joystick;

    [Inject] PlayerProperties _properties;

    private Rigidbody _rigidBody;
    private Transform _transform;

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _transform = transform;
    }

    void Update()
    {
        _rigidBody.linearVelocity = new Vector3(_joystick.Horizontal * _properties.moveSpeed, _rigidBody.linearVelocity.y, _joystick.Vertical * _properties.moveSpeed);

        Vector3 moveDirection = new Vector3(_joystick.Horizontal, 0, _joystick.Vertical).normalized;

        if (_joystick.Horizontal != 0 && _joystick.Vertical != 0)
        {
            Quaternion toRotation = Quaternion.LookRotation(moveDirection);
            _transform.rotation = Quaternion.Slerp(_transform.rotation, toRotation, _properties.rotateSpeed * Time.deltaTime);
        }      
    }
}
