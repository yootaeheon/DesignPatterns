using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util_ObserverPattern;

public class PlayerStatusUI : MonoBehaviour, IObserver
{
    [SerializeField] private PlayerStatus _playerStatus;

    private void Start()
    {
        Init();
    }

    /// <summary>
    /// ������ Ǯ�� �������÷��� ������� ������ִ� ���� ���� �޼���
    /// ����/���������� OnEnable/OnDisable, Start/OnDestroy ������ ��
    /// </summary>
    private void OnDestroy()
    {
        _playerStatus.StatusSubject.Unsubscribe(this);
        _playerStatus.Exe.Unsubscribe(PrintExe);
    }

    private void Init()
    {
        //_playerStatus�� �ִ� StatusSubject(�ֽô��) ��ü�� this(�ڽ�)�� �����Ѵٴ� �޼���
        _playerStatus.StatusSubject.Subscribe(this);

        //_playerStatus�� �ִ� ObservableProperty(����ġ ���� : Exe)�� PrintExe �޼��带 ����
        _playerStatus.Exe.Subscribe(PrintExe);
    }

    public void OnNotify()
    {
        PrintStatus();
    }

    private void PrintStatus()
    {
        Debug.Log($"HP : {_playerStatus.Hp} \nMP : {_playerStatus.Mp}");
    }

    private void PrintExe()
    {
        Debug.Log($"Exe : {_playerStatus.Exe.Value}");
    }
}
