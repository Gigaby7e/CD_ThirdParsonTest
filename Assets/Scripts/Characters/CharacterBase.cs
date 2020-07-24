using UnityEngine;

namespace Characters
{
    public class CharacterBase : MonoBehaviour, IDamageRecipient
    {
        [SerializeField] protected int _maxHealthPoint;
        [SerializeField] protected int _currentHeathPoint;
        [SerializeField] [Range(0, 1)] private float _armor;
        [SerializeField] protected float _movementSpeed;

        private bool _isAlive = true;
        public bool IsAlive { get => _isAlive; private set => _isAlive = value; }

        public int CurrentHeathPoint 
        { 
            get => _currentHeathPoint;
            set
            {
                _currentHeathPoint = value;
                CheckHealth();
            }
        }


        private void CheckHealth()
        {
            if (_currentHeathPoint <= 0)
            {
                Death();
            }
        }

        public virtual void Reset()
        {
            IsAlive = true;
            CurrentHeathPoint = _maxHealthPoint;
        }

        public virtual void GetDamage(int damage)
        {
            CurrentHeathPoint -= Mathf.RoundToInt(damage * _armor);
        }

        public virtual void RestoreHealt(int health)
        {
            CurrentHeathPoint += health;

            if (CurrentHeathPoint > _maxHealthPoint)
            {
                CurrentHeathPoint = _maxHealthPoint;
            }
        }

        public virtual void Death()
        {
            IsAlive = false;
        }
    }
}