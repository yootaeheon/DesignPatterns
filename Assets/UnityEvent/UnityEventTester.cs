using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class UnityEventTester : MonoBehaviour
{
    /// <summary>
    /// 소리를 질렀을 때 반응을 연결할 이벤트;
    /// 소리를 지르는 메서드(OnScream)에서 이 이벤트를 발생시킴; 
    /// UnityEvent는 컴포넌트 패턴으로 구현되어 있어 대입연산자가 안 됨;
    /// 인스펙터에서 드래그앤드롭으로 참조;
    /// </summary>
    public UnityEvent OnScream;

    /*// 매개 변수 있는 유니티 이벤트 예시
    public UnityEvent<float> OnScream_int;
    [SerializeField] float _jumpForce;*/

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Scream();
        }
    }

    private void Scream()
    {
        Debug.Log("플레이어가 소리를 질렀다");
        OnScream?.Invoke();

        // 매개변수 있는 유니티 이벤트 예시
        /*OnScream_int?.Invoke(_jumpForce);*/
    }
}
