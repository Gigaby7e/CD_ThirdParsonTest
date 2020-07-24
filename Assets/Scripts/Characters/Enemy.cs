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
        private bool _isTargetPresent = false;

        [SerializeField] Animator _animator;
        private Transform _target;

        private void Start()
        {
            Initialize();
            MoveToRandomPoint();
        }

        private void Update()
        {
            CheckIsTarget();
            MoveTonextPosition();
            Move();
        }

        private void Move()
        {
            //todo
            _animator.SetFloat("Move", _agent.velocity.magnitude);
        }

        private void MoveTonextPosition()
        {
            if (_agent.velocity == Vector3.zero && IsAlive)
            {
                MoveToRandomPoint();
            }
        }

        private void CheckIsTarget()
        {
            if (_isTargetPresent)
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
                _isTargetPresent = false;
            }
        }

        private void PlayerDetected(Transform playerTransform)
        {
            _target = playerTransform;
            _isTargetPresent = true;
        }

        public override void GetDamage(int damage)
        {
            base.GetDamage(damage);

            HP.SetBarValue(_maxHealthPoint, _currentHeathPoint);
        }

        public override void Death()
        {
            if (IsAlive)
            {
                base.Death();
                _agent.isStopped = true;
                
                //todo
                _animator.SetTrigger("Death");
            }
        }
    }
}