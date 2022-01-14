using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent(out ZombieBase zombie))
        {
            Debug.Log("Hit! Bullet to zombie");
            Destroy(gameObject);
        }
    }
}