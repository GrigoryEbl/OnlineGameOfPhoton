using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapMarker : MonoBehaviour
{
    private MiniMap _miniMap;
    private Transform _target;
    [SerializeField] private float _scale =  0.001f;
    private RectTransform _rectTransform;

    public void initialize(MiniMap miniMap, Transform target, float scale)
    {
        _miniMap = miniMap;
        _target = target;
        _scale = scale;
    }

    private void Awake()
    {
        _rectTransform = transform as RectTransform;
    }

    private void Update()
    {
        if (_miniMap.Owner == null)
            return;

        if(_target == null)
        {
            Destroy(gameObject);
            return;
        }

        var coordinate = _miniMap.Owner.InverseTransformPoint(_target.position);
        Vector2 position = new Vector2(coordinate.x, coordinate.z);
        position *= _scale;

        _rectTransform.anchoredPosition = position;
    }
}
