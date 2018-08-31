using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIAgentDirector : MonoBehaviour {

    public AIAgent agent;


	
	// Update is called once per frame
	void FixedUpdate () {

        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(camRay, out hit, 1000f))
        {
            agent.SetTarget(hit.point);
        }
	}
}
