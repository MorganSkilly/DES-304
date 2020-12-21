using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
	[SerializeField]
	public NavMeshAgent agent;
	
	[SerializeField]
	public GameObject destin;
	
	
	[SerializeField]
	public bool kill;
	
    // Update is called once per frame
    void Update()
	{
		if (destin != null)
			agent.SetDestination(destin.transform.position);
		else
			destin = GameObject.FindGameObjectsWithTag("AI Target")[0];
			
		if (kill)
			Kill();
	}
    
	void Kill()
	{
		GetComponent<RagdollManager>().animState = RagdollManager.AnimState.die;
		agent.Stop();
	}
}
