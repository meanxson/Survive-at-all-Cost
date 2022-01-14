using System.Threading.Tasks;
using UnityEngine;

namespace Client.Scripts.Zombie.States
{
    public class ZombieAttackState : ZombieBaseState
    {
        private readonly int _damage;
        private PlayerBase _attackTarget;

        private bool _isAction;
        
        public ZombieAttackState(Animator animator, IZombieSwitchState zombieSwitchState, int damage) : base(animator, zombieSwitchState)
        {
            _damage = damage;
        }

        public override void Start()
        {
            _isAction = true;
            Debug.Log($"Attack State {_isAction}");
        }

        public override void Stop()
        {
            _isAction = false;
            Debug.Log($"Attack State {_isAction}");
        }

        public override async void Action()
        {
            while (_isAction)
            {
                await Task.Delay(500);
                _attackTarget.HealthContainer.ApplyDamage(_damage);
            }
        }

        public void SetPlayer(PlayerBase player) => _attackTarget = player;
    }
}