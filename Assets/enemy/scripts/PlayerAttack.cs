using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    Transform cameraTransform;
    float range = 100f;

    [SerializeField]
    float rawDamage = 10f;

    PlayerInput playerInput;
    InputAction attackAction;

    void OnEnable()
    {
        playerInput = GetComponent<PlayerInput>();

        var map = playerInput.currentActionMap;

        attackAction = map.FindAction("Attack", true);
    }

    void Update()
    {
        FireThirdWeapon();
    }

    void FireThirdWeapon()
    {
        if (attackAction.triggered)
        {
            cameraTransform = Camera.main.transform;
            Ray ray = new Ray(cameraTransform.position, cameraTransform.forward);
            RaycastHit raycastHit;
            LayerMask mask = ~LayerMask.GetMask("Player");

            if (Physics.Raycast(ray, out raycastHit, range, mask))
            {
                if (raycastHit.transform != null)
                {
                    raycastHit.collider.SendMessageUpwards("Hit", rawDamage, SendMessageOptions.DontRequireReceiver);

                }
            }
            else
            {
                Debug.Log("NO RAYCAST");
            }
        }
    }
}