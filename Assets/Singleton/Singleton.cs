using UnityEngine;

/// <summary>
/// Singleton �����ϴ� ��ũ��Ʈ;
/// ���� �߿� �׻� �����Ǵ� ���� �ν��Ͻ��� ���������� ���� �����Ͽ� �����͸� ���ϰ� ���� ����
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
