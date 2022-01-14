using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;
using Utils.GameSession;

public class ZombieFollowState : ZombieBaseState
{
    private readonly NavMeshAgent _agent;
    private readonly float _stopDistance;
    private readonly float _speed;

    public Vector3 Target { get; private set; }
    public Transform Transform { get; private set; }

    private PlayerBase _currentTarget;
    public ZombieFollowState(Animator animator, IZombieSwitchState zombieSwitchState, NavMeshAgent agent,
        float stopDistance, Transform transform, float speed)
        : base(animator, zombieSwitchState)
    {
        _agent = agent;
        Transform = transform;
        _speed = speed;
        _stopDistance = stopDistance;

        NavInit();
    }

    public ZombieFollowState SetTarget(Vector3 targetPosition)
    {
        Target = targetPosition;
        return this;
    }

    //TODO: Inject animation
    public override void Start()
    {
        _agent.isStopped = false;
        _currentTarget = GameSession.Instance.GetRandomPlayer();
    }

    public override void Stop()
    {
        _agent.isStopped = true;
    }

    public override async void Action()
    {
        var target = _currentTarget;
        while (true)
        {
            if (!ReferenceEquals(target, null)) Target = target.transform.position;

            await Task.Delay(1);

            if (_agent.isOnNavMesh) _agent.SetDestination(Target);
            else return;
        }
    }

    private void NavInit()
    {
        _agent.stoppingDistance = _stopDistance;
        _agent.speed = _speed;
    }
}