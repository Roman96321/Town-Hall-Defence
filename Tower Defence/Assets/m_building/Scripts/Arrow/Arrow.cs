using UnityEngine;

public class Arrow : MonoBehaviour
{
    private float _speed = 0.009f;
    private Transform _transform;
    private float _progress;

    protected GameObject _target;
    protected float _damage;

    public GameObject Target {set {_target = value;}}
    public float Damage {set {_damage = value >= 0 ? value : default;}}

    private void Start()
    {
        _transform = transform;
    }

    private void FixedUpdate()
    {
        if (_target != null && _target.activeSelf != false)
        {
            _transform.position = Vector3.Lerp(_transform.position, _target.transform.position, _progress);
            _progress += _speed;

            _transform.LookAt(_target.transform);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    protected virtual void Attack(Collider other) { }

    private void OnTriggerEnter(Collider other)
    {
        Attack(other);
    }
}