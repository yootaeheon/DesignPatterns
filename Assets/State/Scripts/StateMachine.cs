using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StateType
{
    Idle, Attack
}

public class StateMachine
{
    private Dictionary<StateType, PlayerState> _stateContainer;
    public StateType CurrentType { get; private set; }
    private PlayerState CurrentState => _stateContainer[CurrentType];

    /// <summary>
    /// ��ųʸ��� �����Ͽ� �� ���µ��� �����س���
    /// params Ű���带 ����Ͽ� �ʱ�ȭ �ϴ� �ʿ��� �Ű����� ���ڰ��� ���� ���Ѿ��� ���� �� ���� 
    /// </summary>
    /// <param name="states"></param>
    public StateMachine(params PlayerState[] states)
    {
        _stateContainer = new Dictionary<StateType, PlayerState>();

        foreach (var s in states)
        {
            if (!_stateContainer.ContainsKey(s.ThisType))
            {
                _stateContainer.Add(s.ThisType, s);    
            }
            s.Machine = this;
        }

        CurrentType = states[0].ThisType;
        CurrentState.Enter();
    }

    public void OnUpdate()
    {
        CurrentState.OnUpdate();
    }

    /// <summary>
    /// ���� ��ȯ�ϴ� �޼���
    /// ���� ���¸� ���ڰ� ���·� ��ȯ�ϰ� ��ȯ�� ������ Enter()�޼��带 �����Ͽ� �ʱ�ȭ ������ ����
    /// </summary>
    /// <param name="state"></param>
    public void ChangeState(StateType state)
    {
        CurrentType = state;
        Debug.Log($"���� ���� {state}");
        CurrentState.Enter();
    }
}
