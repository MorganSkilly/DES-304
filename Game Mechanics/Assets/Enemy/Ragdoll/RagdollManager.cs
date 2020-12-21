using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollManager : MonoBehaviour
{
	
	public enum AnimState
	{
		crawl,
		walk,
		die
	}
	
	public enum State
	{
		fullRagdoll,
		regularAnim,
		otherAnim
	}
	
	[SerializeField]
	public AnimState animState;
	
	[SerializeField]
	public GameObject[] Joint;
	
	[SerializeField]
	public GameObject PuppetContainerJoint;
	
	[SerializeField]
	public GameObject PuppetMasterAnimator;
	
	private ConfigurableJoint[] JointDefaults;
	
	
    // Start is called before the first frame update
    void Start()
	{
	}

    // Update is called once per frame
    void Update()
	{
		if (animState == AnimState.crawl)
			Switch(State.otherAnim);
		else if (animState == AnimState.walk) 
			Switch(State.regularAnim);
		else if (animState == AnimState.die) 
			Switch(State.fullRagdoll);
	}
    
	public void Switch(State state)
	{
		if (state == State.fullRagdoll)
			setFullRagdoll();
		else if (state == State.regularAnim) 
			setRegularAnim();
		else if (state == State.otherAnim) 
			setOtherAnim();
	}
	
	void setFullRagdoll()
	{
		PuppetMasterAnimator.GetComponent<Animator>().SetInteger("AnimState", 3);
		Destroy(PuppetContainerJoint.GetComponent<FixedJoint>());
		Destroy(GetComponent<CapsuleCollider>());
		
		foreach (GameObject joint in Joint)
		{
			JointDrive drive = new JointDrive();
			drive.positionDamper = 0;
			drive.positionSpring = 10;
			drive.maximumForce = 3.402823e+38f;
			
			joint.GetComponent<ConfigurableJoint>().angularYZDrive = drive;
			joint.GetComponent<ConfigurableJoint>().angularXDrive = drive;
		}
	}
	
	void setRegularAnim()
	{
		PuppetMasterAnimator.GetComponent<Animator>().SetInteger("AnimState", 2);
		
		foreach (GameObject joint in Joint)
		{
			JointDrive drive = new JointDrive();
			drive.positionDamper = 0;
			drive.positionSpring = 10000000000;
			drive.maximumForce = 3.402823e+38f;
			
			joint.GetComponent<ConfigurableJoint>().angularYZDrive = drive;
			joint.GetComponent<ConfigurableJoint>().angularXDrive = drive;
		}
	}
	
	void setOtherAnim()
	{
		PuppetMasterAnimator.GetComponent<Animator>().SetInteger("AnimState", 1);
		Destroy(PuppetContainerJoint.GetComponent<FixedJoint>());
		
		foreach (GameObject joint in Joint)
		{
			JointDrive drive = new JointDrive();
			drive.positionDamper = 0;
			drive.positionSpring = 1000;
			drive.maximumForce = 3.402823e+38f;
			
			joint.GetComponent<ConfigurableJoint>().angularYZDrive = drive;
			joint.GetComponent<ConfigurableJoint>().angularXDrive = drive;
		}
		
	}
}
