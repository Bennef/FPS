using Scripts.Inputs;
using UnityEngine;

namespace Scripts.Cameras
{
    public class MouseLook : MonoBehaviour
    {
        [SerializeField] private float _mouseSensitivity = 150;
        private Transform _playerBody;
        private float _xRotation = 0f;
        private InputHandler _inputHandler;

        void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            _playerBody = GameObject.Find("Player").GetComponent<Transform>();
            _inputHandler = FindObjectOfType<InputHandler>();
        }

        void Update()
        {
            _xRotation -= _inputHandler.GetMouseY() * _mouseSensitivity * Time.deltaTime;
            _xRotation = Mathf.Clamp(_xRotation, -45f, 45f);

            transform.localRotation = Quaternion.Euler(_xRotation, 0, 0);

            _playerBody.Rotate(Vector3.up * _inputHandler.GetMouseX() * _mouseSensitivity * Time.deltaTime);
        }
    }
}