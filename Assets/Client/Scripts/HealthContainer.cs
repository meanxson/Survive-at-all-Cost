using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthContainer : MonoBehaviour, IDamageable
{
    [SerializeField] private int _health;
    public event UnityAction<int> OnHealthChanged;
    public event UnityAction Died;
    
    [field: SerializeField] public HealthViewer Viewer { get; private set; }

    public void ApplyDamage(int damage)
    {
        _health -= damage;
        OnHealthChanged?.Invoke(_health);

        if (_health <= 0)
            Died?.Invoke();
    }
}