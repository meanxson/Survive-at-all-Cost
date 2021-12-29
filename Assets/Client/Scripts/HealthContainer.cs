using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthContainer : MonoBehaviour
{
    [SerializeField] private int _health;
    public event UnityAction<int> OnHealthChanged;
    public event UnityAction Died;

    public void ApplyDamage(int damage)
    {
        if (_health > 0)
        {
            _health -= damage;
            OnHealthChanged?.Invoke(_health);
        }

        if (_health <= 0)
            Died?.Invoke();
    }
}