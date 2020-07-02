using Scripts.Inputs;
using TMPro;
using UnityEngine;

public class DoorPanel : MonoBehaviour, IInteractible
{
    public bool HasBeenInteractedWith { get; set; }
    public bool CanBeInteractedWith { get; set; }

    [SerializeField] private GameObject _doorToUnlock;
    [SerializeField] private AudioClip _doorOpening, _doorClosing;

    private InputHandler _inputHandler;
    private TextMeshProUGUI _interactPrompt;
    private GameObject _panel;
    private Animator _animator;
    private AudioSource _aSrc;

    private void Start()
    {
        _inputHandler = FindObjectOfType<InputHandler>();
        _animator = _doorToUnlock.GetComponent<Animator>();
        _interactPrompt = GetComponentInChildren<TextMeshProUGUI>();
        _aSrc = _doorToUnlock.GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (CanBeInteractedWith)
        {
            ShowPrompt();

            if (_inputHandler.GetInteractButton())
                Interact();
        }
        else
            HidePrompt();
    }

    private void OnTriggerEnter(Collider other) => CanBeInteractedWith = true;

    private void OnTriggerExit(Collider other) => CanBeInteractedWith = false;

    void ShowPrompt() => _interactPrompt.text = "[E]";

    void HidePrompt() => _interactPrompt.text = "";

    public void Interact()
    {
        if (_animator.GetBool("isOpen") == false)
        {
            _animator.SetBool("isOpen", true);
            _aSrc.PlayOneShot(_doorOpening);
        }

        else if (_animator.GetBool("isOpen") == true)
        {
            _animator.SetBool("isOpen", false);
            _aSrc.PlayOneShot(_doorClosing);
        } 
    }
}