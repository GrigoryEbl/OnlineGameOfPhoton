using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthPresenter : MonoBehaviour
{
    private RectTransform _healthBar;
    private Damagable _damagable;
    private float _maxSize;

    public void Connect(Damagable damagable)
    {
        _healthBar = transform as RectTransform;
        _damagable = damagable;
        _maxSize = _healthBar.sizeDelta.x;
    }

    private void Update()
    {
        if (_damagable != null)
        {
            _healthBar.sizeDelta = new Vector2((_maxSize * _damagable.Health) / 100f, _healthBar.sizeDelta.y);
        }
    }
}
