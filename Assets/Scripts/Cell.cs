using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    public Text txt;  
    public Image img; 

   
    public void UpdateCell(Sprite itemSprite, int itemCount)
    {
        img.sprite = itemSprite; 
        txt.text = itemCount.ToString(); 
    }
}
