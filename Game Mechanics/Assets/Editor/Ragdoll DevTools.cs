using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class RagdollDevTools : MonoBehaviour
{
	[MenuItem("Tools/Ragdoll Dev Tools/Kill All")]
	static void KillAll()
	{
		GameObject[] enemies;
		enemies = GameObject.FindGameObjectsWithTag("Enemy");
		foreach (GameObject enemy in enemies)
		{
			if (!enemy.GetComponent<EnemyController>().kill)
				enemy.GetComponent<EnemyController>().kill = true;
		}
	}
	
	[MenuItem("Tools/Ragdoll Dev Tools/Cull")]
	static void Cull()
	{
		GameObject[] enemies;
		enemies = GameObject.FindGameObjectsWithTag("Enemy");
		foreach (GameObject enemy in enemies)
		{
			Destroy(enemy);
		}
	}
}
