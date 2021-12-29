using System.Linq;
using Client.Scripts.Zombie.States;
using UnityEngine;

public class ZombieTriggerDetect : MonoBehaviour
{
    [SerializeField] private ZombieBase _zombie;

    private ZombieAttackState _attackState;
    private void Awake() => _zombie = GetComponentInParent<ZombieBase>();

    private void Start()
    {
        _attackState = (ZombieAttackState) _zombie.States.FirstOrDefault(state => state is ZombieAttackState);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerBase player))
        {
            _zombie.SwitchState<ZombieAttackState>();
            _attackState.SetPlayer(player);
            _zombie.CurrentState.Action();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out PlayerBase player))
        {
            _zombie.SwitchState<ZombieFollowState>();
            _zombie.CurrentState.Action();
        }
    }
}
