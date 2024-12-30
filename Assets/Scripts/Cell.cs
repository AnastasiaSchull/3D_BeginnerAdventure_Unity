using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    public Text txt;  
    public Image img;

    public void UpdateCell(Sprite itemSprite, int itemCount)
    {
        img.sprite = itemSprite;
        img.color = new Color(1f, 1f, 1f, 1f); //полная непрозрачность
        txt.text = itemCount.ToString();      
    }
}
