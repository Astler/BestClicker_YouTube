using UnityEngine;

namespace Enemy.View
{
    public class EnemyAnimationsView : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        private static readonly int Walking = Animator.StringToHash("walking");
        private static readonly int Idling = Animator.StringToHash("idling");
        private static readonly int Hurt = Animator.StringToHash("hurt");

        public void PlayWalkAnimation()
        {
            animator.SetBool(Walking, true);
            animator.SetBool(Idling, false);
        }

        public void PlayIdleAnimation()
        {
            animator.SetBool(Walking, false);
            animator.SetBool(Idling, true);
        }

        public void PlayHurtAnimation()
        {
            animator.SetTrigger(Hurt);
        }
    }
}