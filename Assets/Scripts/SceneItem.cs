using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneItem : MonoBehaviour, IInteractable
{
    [SerializeField] private string messageForUser;
    public string Message => messageForUser;

    public void Interact()
    {
        Destroy(gameObject);
    }


}