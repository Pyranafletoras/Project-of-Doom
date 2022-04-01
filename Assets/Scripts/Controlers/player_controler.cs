using UnityEngine.EventSystems;
using UnityEngine;


public class player_controler : MonoBehaviour
{

    public Interactable focus;

    public LayerMask movementMask;

    Camera cam;
    


    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        
            
        
    }

    // Update is called once per frame
    void Update()
    { 
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        
        
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {
              Interactable interactable = hit.collider.GetComponent<Interactable>();
                if (interactable != null)
                {
                    SetFocus(interactable);
                    
                }

                
                  
            }
        }



    }
    void SetFocus(Interactable NewFocus)
    {
        if(NewFocus != focus)
        {
            if(focus != null)
            {
                focus.onDefocused();
            }
            
            focus = NewFocus;
            
        }
        
        NewFocus.onFocused(transform);
       
    }

    void RemoveFocus()
    {
        focus.onDefocused();
        focus = null;
       
    }

}

