using UnityEngine;
using UnityEngine.InputSystem;

namespace ActionRPGGame
{
    public class PlayerController : MonoBehaviour
    {
        private Transform refTransform;

        private InputAction moveAction;

        [SerializeField] private float moveSpeed = 8f;

        [SerializeField] private float rotationSpeed = 720f;


        [SerializeField] private Animator refAnimator;


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

            if (refAnimator == null)
            {
                refAnimator = GetComponentInChildren<Animator>();
            }
        }


        private void Update()
        {
            Vector2 moveValue = moveAction.ReadValue<Vector2>();

            Vector3 direction = new Vector3(moveValue.x, 0f, moveValue.y);

            direction.Normalize();

            refTransform.position = refTransform.position + direction * moveSpeed * Time.deltaTime;


            if (direction != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(direction);

                refTransform.rotation = Quaternion.RotateTowards(refTransform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            }

            if (moveValue == Vector2.zero)
            {
                refAnimator.SetInteger("State", 0);
            }
            else
            {
                refAnimator.SetInteger("State", 1);
            }
        }
    }
}

