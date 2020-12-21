using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
	[SerializeField]
	public float radius = 10.0F;
	[SerializeField]
	public float power = 1000.0F;
	[SerializeField]
	public bool trigger = false;
	
	void Update()
	{
		if (trigger)
		{
			Explode();
		}
		trigger = false;
	}
	
	void Explode()
    {
	    Vector3 explosionPos = transform.position;
	    Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
	    foreach (Collider hit in colliders)
	    {
		    Rigidbody rb = hit.GetComponent<Rigidbody>();

		    if (rb != null)
			    rb.AddExplosionForce(power, explosionPos, radius, 3.0F);
	    }
    }
}
