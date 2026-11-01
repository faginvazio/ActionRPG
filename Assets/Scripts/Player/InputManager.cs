using UnityEngine;
using UnityEngine.InputSystem;

namespace ActionRPGGame
{
    [DefaultExecutionOrder(-1)]
    public class InputManager : MonoBehaviour
    {
        public static Vector2 Movement { get; private set; } = Vector2.zero;

        private InputAction moveAction;


        private void Awake()
        {
            if (moveAction == null)
            {
                moveAction = InputSystem.actions.FindAction("Move");
            }
        }

        private void Update()
        {
            Movement = moveAction.ReadValue<Vector2>();
        }
    }
}
