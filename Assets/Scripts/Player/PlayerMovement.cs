using UnityEngine;

namespace Player
{
    public class PlayerMovement: MonoBehaviour
    {
        private CharacterController controller;
        private Vector3 playerVelocity;
        private bool groundedPlayer;
        public float playerSpeed = 2.0f;
        public float jumpHeight = 1.0f;

        private void Start()
        {
            if (!gameObject.TryGetComponent<CharacterController>(out controller))
            {
                controller = gameObject.AddComponent<CharacterController>();
            }
        }

        void Update()
        {
            groundedPlayer = controller.isGrounded;
            if (groundedPlayer && playerVelocity.y < 0)
            {
                playerVelocity.y = 0f;
            }

            Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
            controller.Move(move * Time.deltaTime * playerSpeed);

            // Changes the height position of the player..
            if (Input.GetButtonDown("Jump") && groundedPlayer)
            {
                playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * Physics.gravity.y);
            }

            playerVelocity.y += Physics.gravity.y * Time.deltaTime;
            controller.Move(playerVelocity * Time.deltaTime);
        }
    }
}