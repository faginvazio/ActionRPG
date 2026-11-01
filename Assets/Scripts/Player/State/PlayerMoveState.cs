using UnityEngine;


namespace ActionRPGGame
{
    public class PlayerMoveState : PlayerStateBase
    {
        [SerializeField] private float rotationSpeed = 540f;

        protected override void Update()
        {
            base.Update();

            Vector3 direction = new Vector3(InputManager.Movement.x, 0f, InputManager.Movement.y);

            if (direction.sqrMagnitude > 1.0f)
            {
                direction.Normalize();
            }

            if (direction != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                refTransform.rotation = Quaternion.RotateTowards(refTransform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            }
        }

        private void PlayStep()  // for PlayStep event on EllenRunForward animation
        {

        }
    }
}
