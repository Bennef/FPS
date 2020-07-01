using UnityEngine;
public interface IInteractible 
{
    bool HasBeenInteractedWith { get; set; }
    void Interact();
}
