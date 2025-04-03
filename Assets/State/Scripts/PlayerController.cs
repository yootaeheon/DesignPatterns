using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 딕셔너리에 저장한 상태들의 인스턴스를 생성하며 초기화
/// 매프레임마다 현재 상태의 Update를 호출할 수 있게 전환해줌
/// </summary>
public class PlayerController : MonoBehaviour
{
    [field: SerializeField] [field: Range(0, 30)] public float AttackRadius { get; private set; }
    [field: SerializeField] public int AttackValue { get; private set; }

    private StateMachine _state;

    private void Awake()
    {
        Init();
    }

    private void Update()
    {
        _state.OnUpdate();
    }

    private void Init()
    {
        _state = new StateMachine(new StateIdle(this), new StateAttack(this));
    }
}
