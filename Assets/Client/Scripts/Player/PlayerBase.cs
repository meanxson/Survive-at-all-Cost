using Client.Scripts.Player;
using UnityEngine;
using UnityEngine.AI;
using Utils.GameSession;
using Random = UnityEngine.Random;

public class PlayerBase : MonoBehaviour
{
    [SerializeField] private Joystick _joystick;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private NavMeshAgent _agent;
    public PlayerModel Model { get; private set; }

    private PlayerMovement _playerMovement;

    private void Awake()
    {
        _playerMovement = new PlayerMovement(_rigidbody, _joystick, _agent, transform);
        Model = new PlayerModel("TestPlayerNickName", Random.Range(0, 100));
    }

    private void Start() => GameSession.Instance.RegisterPlayer(this);

    //Todo: Make observable
    private void FixedUpdate()
    {
        _playerMovement.Move();
    }
}