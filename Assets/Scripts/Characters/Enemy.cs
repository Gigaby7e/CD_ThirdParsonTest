using UnityEngine;
using UnityEngine.AI;

namespace Characters
{
    [RequireComponent (typeof(NavMeshAgent))]
    public class Enemy : CharacterBase
    {
        public HealthBar HP;

        [SerializeField] private PatrolPoints _patrolPoints;
        [SerializeField] private NavMeshPath _path;
        private NavMeshAgent _agent;
        
        private Transform _target;
        private bool _isTarget = false;

        private void Start()
        {
            Initialize();
            MoveToRandomPoint();
        }

        private void Update()
        {
            CheckIsTarget();
            MoveTonextPosition();
        }

        private void MoveTonextPosition()
        {
            if (_agent.velocity == Vector3.zero)
            {
                MoveToRandomPoint();
            }
        }

        private void CheckIsTarget()
        {
            if (_isTarget)
            {
                _agent.isStopped = true;
            }
        }

        private void MoveToRandomPoint()
        {
            _agent.isStopped = false;
            _agent.SetDestination(_patrolPoints.GetRandomPoint().position);
        }

        private void Initialize()
        {
            _agent = GetComponent<NavMeshAgent>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(TagManager.PLAYER))
            {
                PlayerDetected(other.transform);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag(TagManager.PLAYER))
            {
                _isTarget = false;
            }
        }

        private void PlayerDetected(Transform playerTransform)
        {
            _target = playerTransform;
            _isTarget = true;
        }

        public override void GetDamage(int damage)
        {
            base.GetDamage(damage);

            HP.SetBarValue(_maxHealthPoint, _currentHeathPoint);
        }

        public override void Death()
        {
            base.Death();

            gameObject.SetActive(false);
        }
    }
}