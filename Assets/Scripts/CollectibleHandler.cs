using UnityEngine;

public class CollectibleHandler : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {       
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.playOnAwake = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectible"))
        {
            ItemObject itemObject = other.GetComponent<ItemObject>();
            if (itemObject != null)
            {
                if (itemObject.collectSound != null)
                {
                    audioSource.PlayOneShot(itemObject.collectSound);
                }

                Debug.Log($"подобран: {itemObject.itemName}, количество: {itemObject.value}");

                Destroy(other.gameObject);
            }
        }
    }
}
