using UnityEngine;

namespace Player
{
    public class PlayerMovement
    {
        private Transform _transform;
        private Rigidbody2D _rigidbody;

        public PlayerMovement(Transform playerTransform, Rigidbody2D playerRigidbody)
        {
            _transform = playerTransform;
            _rigidbody = playerRigidbody;
        }

        public void MoveForward(float speed,float drag)
        {
            IncreaseForwardVelocity(speed);
            AdjustDrag(drag);
        }

        public void Rotate(float rotationSpeed)
        {
            _transform.Rotate(Vector3.back,GetRotationAngle(rotationSpeed));
        }

        private void AdjustDrag(float drag)
        {
            Vector2 velocityDecrease = _rigidbody.velocity * drag * Time.deltaTime;
            _rigidbody.velocity -= velocityDecrease;
        }

        private void IncreaseForwardVelocity(float speed)
        {
            Vector2 forwardVelocity = _transform.up * GetForwardInput(speed);
            _rigidbody.velocity += forwardVelocity;
        }

        private float GetForwardInput(float speed)
        {
            float forwardInput = Mathf.Clamp(Input.GetAxis("Vertical"), 0, 1);
            return forwardInput * speed * Time.deltaTime;
        }

        private float GetRotationAngle(float rotationSpeed)
        {
            float rotationInput = Input.GetAxis("Horizontal");
            return rotationInput * rotationSpeed * Time.deltaTime;
        }
    }
}
