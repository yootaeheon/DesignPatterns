using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTester : MonoBehaviour
{
    /// <summary>
    /// 소리를 질렀을 때 반응을 연결할 이벤트;
    /// 소리를 지르는 메서드(OnScream)에서 이 이벤트를 발생시킴; 
    /// </summary>
    public event Action OnScream; // Action이나 UnityAction 똑같음

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
    }
}
