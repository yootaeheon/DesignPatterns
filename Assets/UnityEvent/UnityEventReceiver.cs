using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityEventReceiver : MonoBehaviour
{
    [SerializeField] UnityEventTester tester; //�̺�Ʈ�� �ִ� Ŭ���� ����

    private Rigidbody _rigidBody;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    /// <summary>
    /// UnityEvent�� ���� �������� ������ ���������� �Ұ��� �ϹǷ� AddListener ����ؼ� �ڵ�� ���̰ų� �ν����Ϳ��� �����ؾ���
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

    /*// �̺�Ʈ �Ű����� �ִ� ���� ����
    public void Jump(float force)
    {
        _rigidBody.AddForce(Vector3.up * force, ForceMode.Impulse);
    }*/
}
