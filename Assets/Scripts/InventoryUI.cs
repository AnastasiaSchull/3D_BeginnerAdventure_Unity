
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private GameObject inventoryPanel; 
    [SerializeField] private Transform inventoryBody;  
    [SerializeField] private Cell cellPrefab;           

    [SerializeField] private KeyCode toggleKey = KeyCode.Space;

    private List<Cell> inventoryCells = new List<Cell>();
    private CanvasGroup canvasGroup; // для управления прозрачностью
    private Image img;
    

    private void Awake()
    {      
        canvasGroup = inventoryPanel.GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            canvasGroup = inventoryPanel.AddComponent<CanvasGroup>();
        }

        //начальная прозрачность
        canvasGroup.alpha = 0f; 
        canvasGroup.interactable = false; 
        canvasGroup.blocksRaycasts = false; 

        //событие изменения инвентаря
        var inventory = FindObjectOfType<Inventory>();
        if (inventory != null)
        {
            inventory.onInventoryChanged += UpdateInventoryUI;
        }
      
    }
    
    public void UpdateInventoryUI(List<ItemData> items)
    {
        // перезаписываем первую ячейку, если она существует
        if (inventoryBody.childCount > 0)
        {
            Cell firstCell = inventoryBody.GetChild(0).GetComponent<Cell>();
            if (items.Count > 0)
            {
                firstCell.UpdateCell(items[0].sprite, items[0].count); 
                if (!inventoryCells.Contains(firstCell))
                {
                    inventoryCells.Add(firstCell); 
                }
            }
        }

        for (int i = 1; i < items.Count; i++)
        {
            if (i < inventoryBody.childCount) 
            {
                Cell existingCell = inventoryBody.GetChild(i).GetComponent<Cell>();
                existingCell.UpdateCell(items[i].sprite, items[i].count);  
                if (!inventoryCells.Contains(existingCell))
                {
                    inventoryCells.Add(existingCell);
                }
            }
            else
            {
                Cell cell = Instantiate(cellPrefab, inventoryBody);
                cell.UpdateCell(items[i].sprite, items[i].count);
                inventoryCells.Add(cell);
            }
        }

    }

    // переключение видимости через прозрачность
    public void ToggleInventory()
    {
    
        if (canvasGroup.alpha == 0f) 
        {
            canvasGroup.alpha = 1f;                     
            canvasGroup.interactable = true; 
            canvasGroup.blocksRaycasts = true; 
            Debug.Log("инвентарь открыт");
            img.color = new Color(1f, 1f, 1f, 1f);
        }
        else 
        {
            canvasGroup.alpha = 0f; 
            canvasGroup.interactable = false; 
            canvasGroup.blocksRaycasts = false; 
            Debug.Log("инвентарь скрыт");
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(toggleKey)) // Space
        {
            ToggleInventory();
        }
    }

}


//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class InventoryUI : MonoBehaviour
//{
//    [SerializeField] private GameObject inventoryPanel; 
//    [SerializeField] private Transform inventoryBody;   
//    [SerializeField] private Cell cellPrefab;          

//    [SerializeField] private KeyCode toggleKey = KeyCode.Space;

//    private List<Cell> inventoryCells = new List<Cell>();

//    private void Awake()
//    { 
//        // подписываемся на событие изменения инвенторя
//        var inventory = FindObjectOfType<Inventory>();
//        if (inventory != null)
//        {
//            inventory.onInventoryChanged += UpdateInventoryUI;
//        }

//        //  начальное состояние книги
//        inventoryPanel.SetActive(true);

//    }

//    public void UpdateInventoryUI(List<ItemData> items)
//    {
//        // удаляем старые ячейки
//        foreach (Cell cell in inventoryCells)
//        {
//            Destroy(cell.gameObject);
//        }
//        inventoryCells.Clear();

//        // создаём новые ячейки
//        foreach (ItemData itemData in items)
//        {
//            Cell cell = Instantiate(cellPrefab, inventoryBody);
//            cell.UpdateCell(itemData.sprite, itemData.count);
//            inventoryCells.Add(cell);
//        }
//    }

//    private void Update()
//    {
//        var inventory = FindObjectOfType<Inventory>();
//        if (Input.GetKeyDown(toggleKey)) 
//        {         
//            inventoryPanel.SetActive(!inventoryPanel.activeSelf);
//            Debug.Log($"инвентарь {(inventoryPanel.activeSelf ? "открыт" : "скрыт")}");
//        }
//    } 
//}
