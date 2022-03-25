using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AILocomotion : MonoBehaviour
{
    NavMeshAgent agent;
    Animator animator;
    [SerializeField] Transform followObject;
    [SerializeField] float maxTime = 1f;
    [SerializeField] float maxDistance = 1f;
    float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0.0f)
        {
            float sdDistance = (followObject.position - agent.destination).sqrMagnitude;
            if (sdDistance > maxDistance * maxDistance)
            {
                agent.destination = followObject.position;
            }
            timer = maxTime;
        }
        animator.SetFloat("velocity", agent.velocity.magnitude);
    }
}
