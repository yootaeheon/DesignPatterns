using UnityEngine;
using Util_ObserverPattern;

public class PlayerStatus : MonoBehaviour
{
    // =============================== V1. 인터페이스를 사용한 옵저버 패턴============================================
    private int _hp;
    public int Hp { get { return _hp; } set { _hp = value; StatusSubject.Notify(); } } // set될 때, Notify 호출

    private int _mp;
    public int Mp { get { return _mp; } set { _mp = value; StatusSubject.Notify(); } }

    public Subject StatusSubject { get; private set; } = new();   // 주시대상 객체 생성


    // ============================== V2. 제네릭, 델리게이트를 사용한 옵저버 패턴============================================
    public ObservableProperty<int> Exe { get; private set; } = new(); //경험치 변수






    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Hp++;
            Mp++;
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Exe.Value++;
        }
    }
}
