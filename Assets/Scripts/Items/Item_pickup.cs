using UnityEngine;

public class Item_pickup : Interactable 
{

    public Item item;
    public override void Interact()
    {
        base.Interact();

        PickUp();
    } 


    void PickUp()
    {
        Debug.Log("pciking up item" + item.name);
        // put item in inventory
        bool WasItemPicked = Inventory.instance.Add(item);
        if (WasItemPicked)
        {
            Destroy(gameObject);
        }
       
        

    }
    // Start is called before the first frame update
    
}
