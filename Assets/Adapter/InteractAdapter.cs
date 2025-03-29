using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// ������ ����� ���� Ŭ����;
/// IInteractable�� �޾� OnInteract �̺�Ʈ�� ȣ��;
/// 1. ��ȣ�ۿ��ϴ� ������Ʈ�� ����͸� ����;
/// 2. �ν����Ϳ��� ����Ϳ� ������ �޼��带 �̺�Ʈ�� �����Ѵ�;
///     (�� �������� �� ������Ʈ�� �ڵ带 �������� �ʾƵ� ���� ����)
/// </summary>
public class InteractAdapter : MonoBehaviour, IInteractable
{
    public UnityEvent<Player> OnInteract;
    public void Interact(Player player)
    {
        OnInteract?.Invoke(player);
    }
}
