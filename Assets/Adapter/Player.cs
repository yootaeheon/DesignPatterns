using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject target;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            // �ν����Ϳ��� ���� ���Ѽ� target�� �����ϰ� ������
            // OverlapSphere �Ǵ� Raycast�� ����Ͽ� ���� ����
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
