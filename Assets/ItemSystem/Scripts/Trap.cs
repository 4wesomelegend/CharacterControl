using UnityEngine;
using UnityEngine.UI;

public class Trap : MonoBehaviour
{
    

    [SerializeField]
    bool isPickupOnCollision = true;

    [SerializeField]
    int TrapDam;

    private void Start()
    {
        if (isPickupOnCollision)
        {
            gameObject.GetComponent<Collider>().isTrigger = true;
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (isPickupOnCollision)
        {
            if (collider.tag == "Player")
            {
               collider.SendMessageUpwards("Hit", TrapDam, SendMessageOptions.DontRequireReceiver);
            }
        }
    }
}