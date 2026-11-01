using UnityEngine;
using UnityEngine.Events;


namespace ActionRPGGame
{
    public class PlayerStateManager : MonoBehaviour
    {
        public enum State
        {
            None = -1,
            Idle,
            Move,
            Length
        }

        [SerializeField] private State state = State.None;

        [SerializeField] private PlayerStateBase[] states;

        [SerializeField] private UnityEvent<State> OnStateChanged;



        private void OnEnable()
        {
            SetState(State.Idle);
        }

        private void Update()
        {
            if (InputManager.Movement == Vector2.zero)
            {
                SetState(State.Idle);
            }
            else
            {
                SetState(State.Move);
            }
        }

        public void SetState(State newState)
        {
            if (state == newState)
            {
                return;
            }

            if (state != State.None)
            {
                states[(int)state].enabled = false;
            }

            states[(int)newState].enabled = true;

            state = newState;

            OnStateChanged?.Invoke(state);
        }
    }
}