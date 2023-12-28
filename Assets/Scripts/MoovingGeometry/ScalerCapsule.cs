using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScalerCapsule : MonoBehaviour
{
    [SerializeField] private Vector3 _targetSize;
    [SerializeField] private float _speed = 0.1f;

    private Vector3 _startSize;
    private Vector3 _currentTarget;

    private void Awake()
    {
        _startSize = transform.localScale;
    }

    private void Update()
    {

        if (transform.localScale == _targetSize)
            _currentTarget = _startSize;
        else if (transform.localScale == _startSize)
            _currentTarget = _targetSize;

        transform.localScale = Vector3.MoveTowards(transform.localScale, _currentTarget, Time.deltaTime * _speed);
    }
}
