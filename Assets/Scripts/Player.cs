using UnityEditor.Rendering;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Inventory inventory; 

    private void OnTriggerEnter(Collider other)
    {
        ItemObject itemObject = other.GetComponent<ItemObject>();
        if (itemObject != null)
        {
            inventory.AddItem(itemObject.itemName, itemObject.sprite, 1); // ++ предмет в инвентарь
            Destroy(other.gameObject); 
        }
    }
}
