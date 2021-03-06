﻿using Scripts.Inputs;
using UnityEngine;

namespace Scripts.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _walkSpeed = 8f;
        [SerializeField] private float _runSpeed = 16f;
        [SerializeField] private float _jumpHeight = 12f;
        [SerializeField] private float _groundDistance = 0.4f;
        [SerializeField] private LayerMask _groundmask;

        private const float _GRAVITY = -30f;
        private CharacterController _controller;
        private InputHandler _inputHandler;
        private Transform _groundCheck;
        private Vector3 _velocity;

        void Start()
        {
            _controller = FindObjectOfType<CharacterController>();
            _inputHandler= FindObjectOfType<InputHandler>();
            _groundCheck = GameObject.Find("Ground Check").GetComponent<Transform>();
        }

        void Update()
        {
            if (_inputHandler.GetRunButtonDown())
                _speed = _runSpeed;
            else
                _speed = _walkSpeed;

            if (IsGrounded() && _velocity.y < 0)
                _velocity.y = -2f;

            float x = _inputHandler.GetHorizontalAxis();
            float z = _inputHandler.GetVerticalAxis();

            Vector3 move = transform.right * x + transform.forward * z;

            _controller.Move(move * _speed * Time.deltaTime);

            if (_inputHandler.GetJumpButton() && IsGrounded())
                _velocity.y = Mathf.Sqrt(_jumpHeight * -2f * _GRAVITY / 4);

            _velocity.y += _GRAVITY * Time.deltaTime;

            _controller.Move(_velocity * Time.deltaTime);
        }

        bool IsGrounded() => Physics.CheckSphere(_groundCheck.position, _groundDistance, _groundmask);
    }
}