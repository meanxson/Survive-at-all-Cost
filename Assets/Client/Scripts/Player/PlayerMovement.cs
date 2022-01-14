using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement
{
    private readonly Rigidbody _rigidbody;
    private readonly Joystick _joystick;
    private readonly NavMeshAgent _agent;
    private readonly Transform _transform;

    public PlayerMovement(Rigidbody rigidbody, Joystick joystick, NavMeshAgent agent, Transform transform)
    {
        _rigidbody = rigidbody;
        _joystick = joystick;
        _agent = agent;
        _transform = transform;
    }

    public void Move()
    {
        var direction = _transform.position + new Vector3(_joystick.Horizontal, 0, _joystick.Vertical);
        _agent.SetDestination(direction);
    }
}