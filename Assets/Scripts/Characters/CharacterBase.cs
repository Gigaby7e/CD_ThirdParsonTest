using UnityEngine;

namespace Characters
{
    public class CharacterBase : MonoBehaviour, IDamageRecipient
    {
        [SerializeField] private int _maxHealthPoint;
        [SerializeField] private int _currentHeathPoint;
        
        [SerializeField] [Range(0, 1)] private float _armor;

        private float _movementSpeed;

        public virtual void Reset()
        {
            _currentHeathPoint = _maxHealthPoint;
        }

        public virtual void GetDamage(int damage)
        {
            _currentHeathPoint = _currentHeathPoint - Mathf.RoundToInt(damage * _armor);
        }

        public virtual void RestoreHealt(int health)
        {
            _currentHeathPoint += health;

            if (_currentHeathPoint > _maxHealthPoint)
            {
                _currentHeathPoint = _maxHealthPoint;
            }
        }
    }
}