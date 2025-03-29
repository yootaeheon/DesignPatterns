using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// 실제로 어댑터 역할 클래스;
/// IInteractable을 받아 OnInteract 이벤트를 호출;
/// 1. 상호작용하는 오브젝트에 어댑터를 부착;
/// 2. 인스펙터에서 어댑터에 연결할 메서드를 이벤트로 참조한다;
///     (이 과정으로 각 오브젝트의 코드를 수정하지 않아도 연결 가능)
/// </summary>
public class InteractAdapter : MonoBehaviour, IInteractable
{
    public UnityEvent<Player> OnInteract;
    public void Interact(Player player)
    {
        OnInteract?.Invoke(player);
    }
}
