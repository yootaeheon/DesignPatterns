using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventReceiver : MonoBehaviour
{
    [SerializeField] EventTester tester; //이벤트가 있는 클래스 참조

    private Rigidbody _rigidBody;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        // OnScream 이벤트에 Jump를 연결시킴 
        tester.OnScream += Jump;
    }

    private void OnDisable()
    {
        // OnScream 이벤트에 Jump를 연결 해제
        tester.OnScream -= Jump;
    }

    public void Jump()
    {
        _rigidBody.AddForce(Vector3.up * 8f, ForceMode.Impulse);
    }
}
