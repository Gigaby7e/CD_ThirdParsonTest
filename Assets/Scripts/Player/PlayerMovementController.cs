﻿using UnityEngine;

namespace Player
{
    public class PlayerMovementController : MonoBehaviour
    {
        [SerializeField] private Transform _camera;
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private float _speed = 10f;

        private float turnSmoothTime = 0.1f;
        private float turnSmoothVelocity;

        private void Update()
        {
            InputFoMove();
        }

        private void InputFoMove()
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

            if (direction.magnitude >= 0.1f)
            {
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);

                //Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
                _characterController.Move(direction * _speed * Time.deltaTime); 
            }
        }
    }
}