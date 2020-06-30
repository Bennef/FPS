using UnityEngine;

namespace Scripts.Cameras
{
    public class MouseLook : MonoBehaviour
    {
        [SerializeField] private float _mouseSensitivity = 150;
        private Transform _playerBody;
        private float _xRotation = 0f;

        // Start is called before the first frame update
        void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            _playerBody = GameObject.Find("Player").GetComponent<Transform>();
        }

        // Update is called once per frame
        void Update()
        {
            float mouseX = Input.GetAxis("Mouse X") * _mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * _mouseSensitivity * Time.deltaTime;

            _xRotation -= mouseY;
            _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);

            transform.localRotation = Quaternion.Euler(_xRotation, 0, 0);

            _playerBody.Rotate(Vector3.up * mouseX);
        }
    }
}