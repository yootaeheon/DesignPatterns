using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 어댑터에서 상호작용을 구현할 인터페이스
/// </summary>
public interface IInteractable
{
    void Interact(Player plater);
}
