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
    /// 딕셔너리를 생성하여 각 상태들을 저장해놓음
    /// params 키워드를 사용하여 초기화 하는 쪽에서 매개변수 인자값의 갯수 제한없이 받을 수 있음 
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
    /// 상태 전환하는 메서드
    /// 현재 상태를 인자값 상태로 전환하고 전환한 상태의 Enter()메서드를 실행하여 초기화 과정을 실행
    /// </summary>
    /// <param name="state"></param>
    public void ChangeState(StateType state)
    {
        CurrentType = state;
        Debug.Log($"현재 상태 {state}");
        CurrentState.Enter();
    }
}
