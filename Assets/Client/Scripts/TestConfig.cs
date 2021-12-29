using System;
using UnityEngine;

namespace Client.Scripts
{
    [Serializable]
    public class TestConfig
    {
        [field: SerializeField] public float TestFloat { get; private set; }
        [field: SerializeField] public float TestFloat2 { get; private set; }
        [field: SerializeField] public float TestFloat3 { get; private set; }
    }
}