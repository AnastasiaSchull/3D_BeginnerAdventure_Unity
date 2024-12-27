using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuntBehaviour : StateMachineBehaviour
{
    private NPC npc;
    private bool isSetup = false;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!isSetup)
        {
            npc = animator.GetComponent<NPC>();
            isSetup = true;
        }
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        npc.agent.SetDestination(npc.player.position);

        float dist = Vector3.Distance(npc.transform.position, npc.player.position);

        if (dist <= npc.huntStopDistance)
        {
            animator.SetBool("isHunting", false);
            animator.SetBool("isRunning", false);
        }
    }


    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        npc.agent.SetDestination(animator.transform.position);
    }
}
