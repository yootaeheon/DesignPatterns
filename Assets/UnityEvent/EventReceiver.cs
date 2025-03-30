using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventReceiver : MonoBehaviour
{
    [SerializeField] EventTester tester; //�̺�Ʈ�� �ִ� Ŭ���� ����

    private Rigidbody _rigidBody;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        // OnScream �̺�Ʈ�� Jump�� �����Ŵ 
        tester.OnScream += Jump;
    }

    private void OnDisable()
    {
        // OnScream �̺�Ʈ�� Jump�� ���� ����
        tester.OnScream -= Jump;
    }

    public void Jump()
    {
        _rigidBody.AddForce(Vector3.up * 8f, ForceMode.Impulse);
    }
}
