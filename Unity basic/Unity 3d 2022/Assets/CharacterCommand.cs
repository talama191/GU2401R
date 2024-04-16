using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class CharacterCommand : MonoBehaviour
{
    private NavMeshAgent agent;
    private Animator animator;
    private bool isAttacking;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, LayerMask.GetMask("Ground")))
            {
                agent.SetDestination(hit.point);
            }
        }
        float movementSpeed = agent.velocity.magnitude;
        animator.SetFloat("movement_speed", movementSpeed);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            isAttacking = true;
        }
        animator.SetBool("is_attacking", isAttacking);
    }

    public void OnAttackHit()
    {
        Debug.Log("Hit");
    }

    public void OnAttackFinished()
    {
        isAttacking = false;
    }
}
