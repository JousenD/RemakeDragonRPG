using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using RPG.Core;

namespace RPG.Movement
{
    public class Mover : MonoBehaviour,IAction
    {
        [SerializeField] Transform target;
        

        NavMeshAgent navMeshAgent;

        private void Start() 
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
        }
        // Update is called once per frame
        void Update()
        {
            // if (Input.GetMouseButton(0)){
            //     MoveToCursor();
            // }
            // Debug.DrawRay(lastRay.origin, lastRay.direction * 100);
            UpdateAnimator();
        }

        public void StartMoveAction(Vector3 destination){
            MoveTo(destination);
        }

        public void MoveTo(Vector3 destination)
        {
            GetComponent<ActionScheduler>().StartAction(this);
            navMeshAgent.destination = destination;
            navMeshAgent.isStopped = false;
        }

        public void Cancel()
        {
            navMeshAgent.isStopped = true;
        }


        private void UpdateAnimator()
        {
            Vector3 velocity = navMeshAgent.velocity;
            Vector3 localVelocity = transform.InverseTransformDirection(velocity);
            float speed = localVelocity.z;
            GetComponent<Animator>().SetFloat("ForwardSpeed", speed);
        }
    }
}
