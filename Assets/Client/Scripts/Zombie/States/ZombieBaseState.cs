using UnityEngine;

public abstract class ZombieBaseState
{
    protected Animator Animator { get; private set; }
    protected IZombieSwitchState ZombieSwitchState { get; private set; }

    protected ZombieBaseState(Animator animator, IZombieSwitchState zombieSwitchState)
    {
        Animator = animator;
        ZombieSwitchState = zombieSwitchState;
    }

    public abstract void Start();
    public abstract void Stop();
    public abstract void Action();
}
