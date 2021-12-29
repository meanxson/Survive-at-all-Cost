using System.Collections.Generic;
using Client.Scripts.Zombie.States;
using UnityEngine;

public class ZombieEssence : ZombieBase
{
    [SerializeField] private Animator _animator;
    [SerializeField] private ZombieConfig _config;
    [SerializeField] private SphereCollider _triggerCollider;

    private void OnValidate() => _triggerCollider.radius = _config.TriggerRadius;

    private void Start()
    {
        CurrentState.Start();
        CurrentState.Action();
    }

    protected override List<ZombieBaseState> InitStates(List<ZombieBaseState> states)
    {
        return States = new List<ZombieBaseState>()
        {
            new ZombieFollowState(_animator, this, Agent, _config.StopDistance, transform, _config.Speed),
            new ZombieAttackState(_animator, this,_config.Damage)
        };
    }
}