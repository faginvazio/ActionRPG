using UnityEngine;


namespace ActionRPGGame
{
    public class PlayerStateBase : MonoBehaviour
    {
        protected Transform refTransform;

        protected CharacterController characterController;

        protected Animator refAnimator;


        protected virtual void OnEnable()
        {
            if (refTransform == null)
            {
                refTransform = transform;
            }

            if (characterController == null)
            {
                characterController = GetComponent<CharacterController>();
            }

            if (refAnimator == null)
            {
                refAnimator = GetComponent<Animator>();
            }
        }

        protected virtual void Update()
        {
            characterController.Move(Physics.gravity * Time.deltaTime);
        }

        protected virtual void OnDisable()
        {

        }

        protected virtual void OnAnimatorMove()
        {
            characterController.Move(refAnimator.deltaPosition);
        }
    }
}

