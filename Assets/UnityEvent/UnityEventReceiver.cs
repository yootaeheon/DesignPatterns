using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityEventReceiver : MonoBehaviour
{
    [SerializeField] UnityEventTester tester; //이벤트가 있는 클래스 참조

    private Rigidbody _rigidBody;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    /// <summary>
    /// UnityEvent는 대입 연산으로 구독과 구독해제가 불가능 하므로 AddListener 사용해서 코드로 붙이거나 인스펙터에서 참조해야함
    /// </summary>
    private void OnEnable()
    {
        tester.OnScream.AddListener(Jump);
    }

    private void OnDisable()
    {
        tester.OnScream.RemoveListener(Jump);
    }

    public void Jump()
    {
        _rigidBody.AddForce(Vector3.up * 8f, ForceMode.Impulse);
    }

    /*// 이벤트 매개변수 있는 버전 예시
    public void Jump(float force)
    {
        _rigidBody.AddForce(Vector3.up * force, ForceMode.Impulse);
    }*/
}
