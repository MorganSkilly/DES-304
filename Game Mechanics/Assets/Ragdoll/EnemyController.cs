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
	
    // Update is called once per frame
    void Update()
	{
		agent.SetDestination(destin.transform.position);
    }
}
