using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class UnityEventTester : MonoBehaviour
{
    /// <summary>
    /// �Ҹ��� ������ �� ������ ������ �̺�Ʈ;
    /// �Ҹ��� ������ �޼���(OnScream)���� �� �̺�Ʈ�� �߻���Ŵ; 
    /// UnityEvent�� ������Ʈ �������� �����Ǿ� �־� ���Կ����ڰ� �� ��;
    /// �ν����Ϳ��� �巡�׾ص������ ����;
    /// </summary>
    public UnityEvent OnScream;

    /*// �Ű� ���� �ִ� ����Ƽ �̺�Ʈ ����
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
        Debug.Log("�÷��̾ �Ҹ��� ������");
        OnScream?.Invoke();

        // �Ű����� �ִ� ����Ƽ �̺�Ʈ ����
        /*OnScream_int?.Invoke(_jumpForce);*/
    }
}
