using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Rigidbody), typeof(NavMeshAgent))]
public abstract class ZombieBase : MonoBehaviour, IZombieSwitchState
{
    public List<ZombieBaseState> States { get; private protected set; }
    public ZombieBaseState CurrentState { get; private set; }
    
    protected Rigidbody Rigidbody { get; private set; }
    protected NavMeshAgent Agent { get; private set; }

    protected virtual void Awake()
    {
        
        Rigidbody = GetComponent<Rigidbody>();
        Agent = GetComponent<NavMeshAgent>();

        Rigidbody.isKinematic = true;
        
        States = InitStates(States);
        CurrentState = States[0];
    }

    /// <summary>
    /// Awake initialize states for zombie(npc)
    /// </summary>
    /// <param name="states"> Base list from parent class which records</param>
    /// <returns>You have to return list from params with initialized states of object</returns>
    protected abstract List<ZombieBaseState> InitStates(List<ZombieBaseState> states);

    public void SwitchState<T>() where T : ZombieBaseState
    {
        CurrentState.Stop();
        var nextState = States.FirstOrDefault(s => s is T);
        CurrentState = nextState;

        CurrentState?.Start();
    }

    private void OnDestroy()
    {
        CurrentState = null;
        States = null;
    }
}