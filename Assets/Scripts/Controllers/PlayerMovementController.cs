using Cinemachine;
using UnityEngine;

namespace Controllers
{
    public class PlayerMovementController : MonoBehaviour
    {
        [SerializeField] private Transform _camera;
        [SerializeField] private CinemachineFreeLook _cinemachineCameraFreeLook;
        [SerializeField] private CharacterController _characterController;

        [SerializeField] private SimpleTouchController _leftController;
        [SerializeField] private SimpleTouchController _rightController;

        [SerializeField] private float _speed = 10f;

        private float turnSmoothTime = 0.1f;
        private float turnSmoothVelocity;

        private void Update()
        {
            PlayerMovement();
            CameraMovement();
        }

        private void CameraMovement()
        {
            _cinemachineCameraFreeLook.m_XAxis.m_InputAxisValue = _rightController.GetTouchPosition.x * -1;
            _cinemachineCameraFreeLook.m_YAxis.m_InputAxisValue = _rightController.GetTouchPosition.y * -1;
        }

        private void PlayerMovement()
        {
            float horizontal = _leftController.GetTouchPosition.x;
            float vertical = _leftController.GetTouchPosition.y;

            Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

            if (direction.magnitude >= 0.1f)
            {
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + _camera.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);

                Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
                _characterController.Move(moveDirection.normalized * _speed * Time.deltaTime); 
            }
        }
    }
}