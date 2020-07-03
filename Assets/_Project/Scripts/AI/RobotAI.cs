using Scripts.Shooting;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
// TODO improve line of sight
// Random range for shooting 
// set waypoints to patrol to and enable walking state
// Fix shooting angle - Check this works
// Footsteps sound - Animation event not firing
// Implement shooting of weapon at player
// Implement health system for player and robot
// Handle death animations/ragdoll
// Spawning
namespace Scripts.AI
{
    public class RobotAI : MonoBehaviour
    {
        [SerializeField] private State _state;
        private NavMeshAgent _agent;
        private Transform _playerTransform;
        private LineOfSight _lineOfSight;
        private Animator _animator;
        private bool isShooting;
        private Gun _gun;

        private enum State
        {
            Idle,
            Walking,
            Shooting
        }

        void Start()
        {
            _agent = GetComponentInParent<NavMeshAgent>();
            _playerTransform = GameObject.Find("Player").transform;
            _lineOfSight = GetComponentInChildren<LineOfSight>();
            _animator = GetComponent<Animator>();
            _gun = GetComponentInChildren<Gun>();
            _agent.updateRotation = false;
        }

        void Update()
        {
            SetState();
            SetAction();
        }

        private void LateUpdate()
        {
            if (isShooting)
            {
                transform.rotation = Quaternion.LookRotation(_agent.velocity.normalized);
                transform.Rotate(new Vector3(0, 25, 0));
            }
            else
                _agent.updateRotation = true;
        }

        void SetState()
        {
            if (!isShooting)
            {
                if (_lineOfSight.CanSeePlayer)
                {
                    _state = State.Shooting; // Change to walking later
                    StartCoroutine(ShootForSeconds(2)); // Random range in here?
                }
                else
                    _state = State.Idle;
            }
        }

        void SetAction()
        {
            if (_state == State.Shooting)
                Shoot();
            else if (_state == State.Walking)
                Walk();
            else if (_state == State.Idle)
                Idle();
        }

        void Shoot()
        {
            _agent.isStopped = false;
            _animator.SetBool("isIdle", false);
            _animator.SetBool("isWalking", false);
            _animator.SetBool("isShooting", true);
            _agent.SetDestination(_playerTransform.position);
        }

        void Walk()
        {
            _animator.SetBool("isIdle", false);
            _animator.SetBool("isWalking", true);
            _animator.SetBool("isShooting", false);
            _agent.SetDestination(_playerTransform.position);
        }

        void Idle()
        {
            _agent.isStopped = true;
            _animator.SetBool("isIdle", true);
            _animator.SetBool("isWalking", false);
            _animator.SetBool("isShooting", false);
        }

        IEnumerator ShootForSeconds(float timeToShoot)
        {
            isShooting = true;
            StartCoroutine(FireWeapon());
            yield return new WaitForSeconds(timeToShoot);
            isShooting = false;
        }

        IEnumerator FireWeapon() // Separate into other class
        {
            _gun.Shoot();
            yield return new WaitForSeconds(0.5f);
            _gun.Shoot();
            yield return new WaitForSeconds(0.5f);
            _gun.Shoot();
        }
    }
}