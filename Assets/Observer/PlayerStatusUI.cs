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
    /// 참조를 풀어 가비지컬렉터 대상으로 만들어주는 구독 해제 메서드
    /// 구독/구독해제는 OnEnable/OnDisable, Start/OnDestroy 쌍으로 함
    /// </summary>
    private void OnDestroy()
    {
        _playerStatus.StatusSubject.Unsubscribe(this);
        _playerStatus.Exe.Unsubscribe(PrintExe);
    }

    private void Init()
    {
        //_playerStatus에 있는 StatusSubject(주시대상) 객체를 this(자신)가 구독한다는 메서드
        _playerStatus.StatusSubject.Subscribe(this);

        //_playerStatus에 있는 ObservableProperty(경험치 변수 : Exe)에 PrintExe 메서드를 구독
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
