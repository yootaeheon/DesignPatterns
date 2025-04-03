/// <summary>
/// 각 상태가 상속받는 base가 되는 state
/// 추상클래스를 사용하여 각 상태에서 Override하여 내부에서 필요한 기능을 구현 가능
/// </summary>
public abstract class PlayerState
{
    public PlayerController Controller { get; private set; }
    public StateMachine Machine { get; set; }
    public StateType ThisType { get; protected set; }

    public PlayerState(PlayerController controller)
    {
        Controller = controller;
        Init();
    }

    public abstract void Init();
    public virtual void Enter() { }
    public virtual void OnUpdate() { }
    public virtual void Exit() { }
}