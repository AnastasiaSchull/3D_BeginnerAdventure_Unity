using UnityEngine;


[System.Serializable]
public class ItemData
{
    public string itemName;  
    public Sprite sprite;    
    public int count;        

    public ItemData(string name, Sprite sprite, int count)
    {
        this.itemName = name;
        this.sprite = sprite;
        this.count = count;
    }
}

