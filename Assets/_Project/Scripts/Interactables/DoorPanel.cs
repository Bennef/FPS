using UnityEngine;

public class DoorPanel : MonoBehaviour, IInteractible
{
    public bool HasBeenInteractedWith { get; set; }

    [SerializeField] private GameObject _doorToUnlock;
    [SerializeField] private AudioClip _doorOpening, _doorClosing;
    
    private GameObject _panel;
    private Animator _animator;
    private AudioSource _aSrc;

    private void Start()
    {
        _animator = _doorToUnlock.GetComponent<Animator>();
        _aSrc = _doorToUnlock.GetComponent<AudioSource>();
    }

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