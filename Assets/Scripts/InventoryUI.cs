using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//для отображения инвентаря

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private GameObject inventoryPanel;
    [SerializeField] private Transform inventoryBody;   
    [SerializeField] private Cell cellPrefab;          

    private List<Cell> inventoryCells = new List<Cell>();

    private void Awake()
    {
        // подписываемся на событие изменения инвентаря
        FindObjectOfType<Inventory>().onInventoryChanged += UpdateInventoryUI;
    }

    public void UpdateInventoryUI(List<ItemData> items)
    {
        // удаляем старые ячейки
        foreach (Cell cell in inventoryCells)
        {
            Destroy(cell.gameObject);
        }
        inventoryCells.Clear();

        // создаем новые ячейки
        foreach (ItemData itemData in items)
        {
            Cell cell = Instantiate(cellPrefab, inventoryBody);
            cell.UpdateCell(itemData.sprite, itemData.count);
            inventoryCells.Add(cell);
        }
    }

    public void ToggleInventory()
    {
        inventoryPanel.SetActive(!inventoryPanel.activeSelf); 
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab)) // откр/закр инвентаря
        {
            ToggleInventory();
        }
    }

}
