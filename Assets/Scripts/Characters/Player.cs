using Controllers;
using UnityEngine;

namespace Characters
{
    public class Player : CharacterBase
    {
        public PlayerAnimatorController PlayerAnimator;

        [SerializeField] private int _damage;
        private IDamageRecipient _target;

        private void Start()
        {
            Init();
        }

        private void Init()
        {
            Reset();
        }

        private void OnTriggerEnter(Collider other)
        {
            TryToCollect(other);
        }

        private void TryToCollect(Collider other)
        {
            if (other.GetComponent<ICollectableObject>() != null)
            {
                if (other.CompareTag(TagManager.MEDKIT))
                {
                    CollectMedKit(other);
                }
            }
        }

        private void CollectMedKit(Collider other)
        {
            var kit = other.GetComponent<ICollectableObject>();
            RestoreHealt(kit.Collect());
            kit.OnCollected();
        }

        public void Fire()
        {
            if (_target != null)
            {
                _target.GetDamage(_damage);
            }
        }


        public void SetTarget(IDamageRecipient damageRecipient)
        {
            _target = damageRecipient;
        }
    }
}