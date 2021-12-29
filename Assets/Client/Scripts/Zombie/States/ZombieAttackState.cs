using System.Threading.Tasks;
using UnityEngine;

namespace Client.Scripts.Zombie.States
{
    public class ZombieAttackState : ZombieBaseState
    {
        private readonly float _damage;
        private PlayerBase _attackTarget;
        
        public ZombieAttackState(Animator animator, IZombieSwitchState zombieSwitchState, float damage) : base(animator, zombieSwitchState)
        {
            _damage = damage;
        }

        public override void Start()
        {
            Debug.Log("Attack State On!");
        }

        public override void Stop()
        {
        }

        public override async void Action()
        {
            while (true)
            {
                await Task.Delay(2500);
                
            }
        }

        public void SetPlayer(PlayerBase player) => _attackTarget = player;
    }
}