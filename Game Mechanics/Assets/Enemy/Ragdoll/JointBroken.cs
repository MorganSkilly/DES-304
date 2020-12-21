using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JointBroken : MonoBehaviour
{
	public bool broken = false;
	[SerializeField]
	public GameObject manager;
	
	void OnJointBreak(float breakForce)
	{
		Debug.Log("Joint Broke!, force: " + breakForce);
		manager.GetComponent<EnemyController>().kill = true;
	}
}
