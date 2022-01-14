public interface IZombieSwitchState
{
    void SwitchState<T>() where T : ZombieBaseState;
}
