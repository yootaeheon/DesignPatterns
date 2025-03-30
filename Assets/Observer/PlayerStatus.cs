using UnityEngine;
using Util_ObserverPattern;

public class PlayerStatus : MonoBehaviour
{
    // =============================== V1. �������̽��� ����� ������ ����============================================
    private int _hp;
    public int Hp { get { return _hp; } set { _hp = value; StatusSubject.Notify(); } } // set�� ��, Notify ȣ��

    private int _mp;
    public int Mp { get { return _mp; } set { _mp = value; StatusSubject.Notify(); } }

    public Subject StatusSubject { get; private set; } = new();   // �ֽô�� ��ü ����


    // ============================== V2. ���׸�, ��������Ʈ�� ����� ������ ����============================================
    public ObservableProperty<int> Exe { get; private set; } = new(); //����ġ ����






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
