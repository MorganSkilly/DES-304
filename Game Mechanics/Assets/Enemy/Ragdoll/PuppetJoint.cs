using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuppetJoint : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Inverts translated joint rotation on puppet")]
    private bool invertJoint = false;

    [SerializeField]
    [Tooltip("Character joint to control")]
    private ConfigurableJoint puppetJoint = null;

    [SerializeField]
    [Tooltip("Joint/bone to mirror on puppet")]
    private GameObject targetJoint = null;

    private Quaternion startingRotation;

    // Start is called before the first frame update
    void Start()
    {
    }

    void Awake()
    {
        if (puppetJoint == null)
            puppetJoint = GetComponent<ConfigurableJoint>();

        startingRotation = Quaternion.Inverse(puppetJoint.transform.localRotation);
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Update is called after the internal animation update in Unity
    void LateUpdate()
    {
        if (invertJoint)
            puppetJoint.targetRotation = Quaternion.Inverse(targetJoint.transform.localRotation *
            startingRotation);
        else
            puppetJoint.targetRotation = targetJoint.transform.localRotation * startingRotation;
    }
}
