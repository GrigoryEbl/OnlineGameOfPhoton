using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScalerCapsule : MonoBehaviour
{
    [SerializeField] private Vector3 _targetScale;
    [SerializeField] private float _speed = 0.1f;

    private Vector3 _startSize;

    private void Awake()
    {
        _startSize = transform.localScale;
    }

    void Update()
    {
        transform.localScale = new Vector3(Mathf.PingPong(Time.time, _targetScale.x - _startSize.x),
                                           Mathf.PingPong(Time.time, _targetScale.y - _startSize.y),
                                           Mathf.PingPong(Time.time, _targetScale.z - _startSize.z));


    }
}
