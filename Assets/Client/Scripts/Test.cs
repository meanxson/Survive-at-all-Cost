using System;
using Client.Scripts;
using DG.Tweening;
using ObservableVariable;
using Sirenix.OdinInspector;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] private float _duration;
    [SerializeField] private TestConfig _config;
    
    [Button]
    public void TurnLeft()
    {
        transform.DOMoveX(-5, _duration); //[-20,0,0]
    }

    [Button]
    public void TurnRight()
    {
        transform.DOMoveX(5, _duration); //[20,0,0]
    }
}
