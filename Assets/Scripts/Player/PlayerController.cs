using UnityEngine;

namespace ActionRPGGame
{
    public class PlayerController : MonoBehaviour
    {
        private Transform refTransform;

        private void Awake()
        {
            if (refTransform == null)
            {
                refTransform = transform;  // better for optimization why??
            }
        }
    }
}

