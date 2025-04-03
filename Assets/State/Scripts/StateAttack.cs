using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StateAttack : PlayerState
{
    private float _delay = 2;
    private WaitForSeconds _wait;
    
    public StateAttack(PlayerController controller) : base(controller)
    {
        
    }

    public override void Init()
    {
        _wait = new WaitForSeconds(_delay);
        ThisType = StateType.Attack;
    }

    public override void Enter()
    {
        Controller.StartCoroutine(DelayRoutine());
      
       
    }

    public override void OnUpdate()
    {
        Debug.Log("Attack On Update");
    }

    public override void Exit()
    {
        Debug.Log("exit 돌입 완료");
        Machine.ChangeState(StateType.Idle);
    }

    private void Attack()
    {
        Debug.Log("attack 돌입");
        Collider[] cols = Physics.OverlapSphere(
            Controller.transform.position,
            Controller.AttackRadius
            );

        IDamagable damagable;
        foreach (Collider col in cols)
        {
            if (col.CompareTag("NormalMonster"))
            {
                damagable = col.GetComponent<IDamagable>();
                damagable.TakeHit(Controller.AttackValue);
                Debug.Log("공격 성공");
            }
            
        
            // 공격성공 로그가 뜨고 다음 아래에 exit 돌입 전 로그가 뜨지 않음 
            // 여기서부터 실행이 멈춤
            // 왜?
            // col 중에 damable이 아닌 오브젝트에게 계속 공격을 시도하는 것으로 의심됨
        }
    }

    public IEnumerator DelayRoutine()
    {
        yield return _wait;
        Attack();
        Debug.Log("exit 돌입 전");
        Exit();
    }

}
