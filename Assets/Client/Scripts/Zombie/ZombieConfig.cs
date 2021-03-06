using System;
using UnityEngine;

[Serializable]
public class ZombieConfig
{
    [field: SerializeField] public int Damage { get; private set; }
    [field: SerializeField] public float AttackSpeed { get; private set; }
    [field: SerializeField] public float Speed { get; private set; }
    [field: SerializeField] public float StopDistance { get; private set; }
    [field: SerializeField] public float TriggerRadius { get; private set; }
}
