using UnityEngine;

/// <summary>
/// Singleton 적용하는 스크립트;
/// 게임 중에 항상 유지되는 단일 인스턴스를 전역적으로 접근 가능하여 데이터를 편하게 관리 가능
/// </summary>
public class Singleton : MonoBehaviour
{
    public static Singleton Instance { get; private set; }

    private void Awake()
    {
        SetSingleton();
    }

    private void SetSingleton()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
