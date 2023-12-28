using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RotateCube : MonoBehaviour
{
    [SerializeField] private float _speed = 0.5f;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        _rigidbody.angularVelocity = Vector3.up * _speed;
    }
}