using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject target;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            // 인스펙터에서 참조 시켜서 target을 지정하고 있지만
            // OverlapSphere 또는 Raycast를 사용하여 응용 가능
            IInteractable interactable = target.GetComponent<IInteractable>();
            if (interactable != null)
            {
                InteractObject(interactable);
            }
        }
    }

    public void InteractObject(IInteractable interactable)
    {
        interactable.Interact(this);
    }
}
