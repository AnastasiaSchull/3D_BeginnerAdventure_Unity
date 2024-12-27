using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentTest : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Camera plCamera;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = plCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                agent.SetDestination(hit.point);//в какую точку кликнем, в такую агент и пойдет
            }
        }

        //if (Input.GetMouseButtonDown(0))
        //{
        //    agent.SetDestination(plCamera.transform.position);//при нажатии мышки агент движется за нами
        //}
        
    }

}
