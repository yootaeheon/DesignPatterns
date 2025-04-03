using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ��ųʸ��� ������ ���µ��� �ν��Ͻ��� �����ϸ� �ʱ�ȭ
/// �������Ӹ��� ���� ������ Update�� ȣ���� �� �ְ� ��ȯ����
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
