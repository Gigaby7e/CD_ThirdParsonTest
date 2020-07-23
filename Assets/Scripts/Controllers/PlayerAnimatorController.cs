using UnityEngine;

namespace Controllers
{
    public class PlayerAnimatorController : MonoBehaviour
    {
        private const string FIRE = "Fire";
        private const string MOVE = "Move";

        [SerializeField] private Animator _palyerAnimatorController;
        [SerializeField] private SimpleTouchController _moveController;

        public void Fire()
        {
            _palyerAnimatorController.SetTrigger(FIRE);
        }

        private void Update()
        {
            _palyerAnimatorController.SetFloat(MOVE, _moveController.GetTouchPosition.magnitude);
        }
    }
}
