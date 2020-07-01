using Scripts.Inputs;
using TMPro;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    private SphereCollider _interactionCollider;
    private InputHandler _inputHandler;
    private TextMeshProUGUI _interactPrompt;

    private void Start()
    {
        _interactionCollider = GetComponent<SphereCollider>();
        _inputHandler = FindObjectOfType<InputHandler>();
    }

    private void OnTriggerStay(Collider other)
    {
        _interactPrompt = other.GetComponentInChildren<TextMeshProUGUI>();
        _interactPrompt.text = "E";

        if (other.gameObject.GetComponent<DoorPanel>() != null)
            if (_inputHandler.GetInteractButton())
                other.gameObject.GetComponent<DoorPanel>().Interact();
    }

    private void OnTriggerExit(Collider other)
    {
        _interactPrompt.text = "";
    }
}