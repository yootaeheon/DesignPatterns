using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTester : MonoBehaviour
{
    /// <summary>
    /// �Ҹ��� ������ �� ������ ������ �̺�Ʈ;
    /// �Ҹ��� ������ �޼���(OnScream)���� �� �̺�Ʈ�� �߻���Ŵ; 
    /// </summary>
    public event Action OnScream; // Action�̳� UnityAction �Ȱ���

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
    }
}
