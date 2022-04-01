using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 3f;
    public Transform interactionTransform;

    bool isFocus = false;
    Transform player;

    bool hasinteracted = false;

    public virtual void Interact()
    {
        Debug.Log("Interacting with" + transform.name);
    }

     void Update()
    {
        if (isFocus && !hasinteracted)
        {
            float distance = Vector3.Distance(player.position, interactionTransform.position);
            if(distance <= radius)
            {
                
                Interact();
             
                hasinteracted = true;
            }
        }
    }
    public void onFocused (Transform playerTransform)
    {
        isFocus = true;
        player = playerTransform;
        hasinteracted = false;

   
    }

    public void onDefocused()
    {
        isFocus = false;
        player = null;
        hasinteracted = false;
    }

    void OnDrawGizmosSelected ()
    {
        if (interactionTransform == null)
            interactionTransform = transform;

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactionTransform.position, radius);

    }
    // Start is called before the first frame update
}
