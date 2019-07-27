using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mover : MonoBehaviour
{
    Transform target;

    // Update is called once per frame
    void Update()
    {    
        // if (Input.GetMouseButton(0)){
        //     MoveToCursor();
        // }
        // Debug.DrawRay(lastRay.origin, lastRay.direction * 100);
        UpdateAnimator();        
    }

    public void MoveTo(Vector3 destination)
    {
        GetComponent<NavMeshAgent>().destination = destination;
    }

    private void UpdateAnimator()
    {
        Vector3 velocity = GetComponent<NavMeshAgent>().velocity;
        Vector3 localVelocity = transform.InverseTransformDirection(velocity);
        float speed = localVelocity.z;
        GetComponent<Animator>().SetFloat("ForwardSpeed",speed);
    }
}
