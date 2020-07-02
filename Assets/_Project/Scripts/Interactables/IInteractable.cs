using UnityEngine;
public interface IInteractible 
{
    bool CanBeInteractedWith { get; set;
    }
    bool HasBeenInteractedWith { get; set; }
    
    void Interact();
}
