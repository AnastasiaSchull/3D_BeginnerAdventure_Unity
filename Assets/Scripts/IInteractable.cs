using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable 
{
    string Message { get; }
    void Interact();
}
