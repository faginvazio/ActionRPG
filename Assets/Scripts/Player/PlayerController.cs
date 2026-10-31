using UnityEngine;
using UnityEngine.InputSystem;

namespace ActionRPGGame
{
    public class PlayerController : MonoBehaviour
    {
        private Transform refTransform;

        private InputAction moveAction;

        [SerializeField] private float moveSpeed = 8f;

        private void Awake()
        {
            if (refTransform == null)
            {
                refTransform = transform;  // better for optimization why??
            }

            if (moveAction == null)
            {
                moveAction = InputSystem.actions.FindAction("Move");
            }
        }


        private void Update()
        {
            Vector2 moveValue = moveAction.ReadValue<Vector2>();

            Vector3 direction = new Vector3(moveValue.x, 0f, moveValue.y);

            direction.Normalize();

            refTransform.position = refTransform.position + direction * moveSpeed * Time.deltaTime;
        }
    }
}

