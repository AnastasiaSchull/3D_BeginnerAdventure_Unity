using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolBetweenPoints : MonoBehaviour
{
    [SerializeField] private List<Transform> checkpoints; 
    [SerializeField] private float waitTimeAtCheckpoint = 6f; 
    private NavMeshAgent agent;
    private int currentCheckpointIndex = 0;
    private bool waiting = false;
    private Animator animator;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>(); 

        if (checkpoints == null || checkpoints.Count == 0)
        {
            return;
        }
        MoveToNextCheckpoint();
    }


    private void Update()
    {
        if (agent.remainingDistance <= agent.stoppingDistance && !waiting)
        {
            Debug.Log("Reached checkpoint, waiting...");
            StartCoroutine(WaitAndMoveToNextCheckpoint());
        }
    }


    private IEnumerator WaitAndMoveToNextCheckpoint()
    {
        waiting = true;
        animator.SetBool("isIdle", true); 
        yield return new WaitForSeconds(waitTimeAtCheckpoint);
        animator.SetBool("isIdle", false); 
        waiting = false;

        MoveToNextCheckpoint();
    }

    private void MoveToNextCheckpoint()
    {
        if (checkpoints.Count == 0) return;

        Debug.Log($"Moving to checkpoint: {checkpoints[currentCheckpointIndex].name}");
        agent.SetDestination(checkpoints[currentCheckpointIndex].position);

        currentCheckpointIndex = (currentCheckpointIndex + 1) % checkpoints.Count;
    }

}
