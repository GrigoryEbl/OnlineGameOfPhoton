using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MooverSphere : MonoBehaviour
{
    [SerializeField] private float _speed = 0.5f;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = Vector3.forward * _speed;
    }
}
