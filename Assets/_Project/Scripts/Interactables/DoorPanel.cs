using Scripts.Inputs;
using System.Collections;
using TMPro;
using UnityEngine;

namespace Scripts.Interactables
{
    public class DoorPanel : MonoBehaviour, IInteractible
    {
        [SerializeField] private GameObject _doorToUnlock;
        [SerializeField] private AudioClip _doorOpening, _doorClosing;
        [SerializeField] private Material _closeMat, _openMat;
        [SerializeField] private DoorPanel _otherPanel;

        private InputHandler _inputHandler;
        private TextMeshProUGUI _interactPrompt;
        private Animator _animator;
        private AudioSource _aSrc;
        private bool _isAnimating, _promptShowing;
        private Renderer _renderer;

        public bool HasBeenInteractedWith { get; set; }
        public bool CanBeInteractedWith { get; set; }

        private void Start()
        {
            _inputHandler = FindObjectOfType<InputHandler>();
            _animator = _doorToUnlock.GetComponent<Animator>();
            _interactPrompt = GetComponentInChildren<TextMeshProUGUI>();
            _aSrc = _doorToUnlock.GetComponent<AudioSource>();
            _renderer = GetComponent<Renderer>();
        }

        private void Update()
        {
            if (CanBeInteractedWith && !_isAnimating)
            {
                if (!_promptShowing)
                    ShowPrompt();

                if (_inputHandler.GetInteractButton())
                    Interact();
            }
            else if (_promptShowing)
                HidePrompt();
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Interaction Collider"))
                CanBeInteractedWith = true;
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Interaction Collider"))
                CanBeInteractedWith = false;
        }

        void ShowPrompt()
        {
            _interactPrompt.text = "[E]";
            _promptShowing = true;
        }

        void HidePrompt()
        {
            _interactPrompt.text = "";
            _promptShowing = false;
        }

        public void Interact()
        {
            if (_animator.GetBool("isOpen") == false)
                OpenDoor();
            else if (_animator.GetBool("isOpen") == true)
                CloseDoor();
        }

        void OpenDoor()
        {
            _animator.SetBool("isOpen", true);
            _aSrc.PlayOneShot(_doorOpening);
            SetPanelColour(_openMat);
            StartCoroutine(Delay(0.4f));
        }

        void CloseDoor()
        {
            _animator.SetBool("isOpen", false);
            _aSrc.PlayOneShot(_doorClosing);
            SetPanelColour(_closeMat);
            StartCoroutine(Delay(0.4f));
        }

        IEnumerator Delay(float seconds)
        {
            _isAnimating = true;
            yield return new WaitForSeconds(0.4f);
            _isAnimating = false;
        }

        void SetPanelColour(Material matToSet)
        {
            _renderer.material = matToSet;
            if (_otherPanel != null)
                _otherPanel.SetPanelColour(matToSet);
        }
    }
}