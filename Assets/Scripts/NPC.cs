using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC : MonoBehaviour
{
    public List<Transform> checkpoints;
    public NavMeshAgent agent;

    public float idleDuration;
    public float huntStartDistance;
    public float huntStopDistance;
    [HideInInspector] public Transform player;

    private Animator animator;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, player.position) <= huntStartDistance)
        {
            animator.SetBool("isHunting", true);
        }
    }
}
