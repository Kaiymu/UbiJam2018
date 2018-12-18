using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrab : MonoBehaviour {

    public Transform grabParent;

    [HideInInspector]
    public GameObject objectGrabbed;
	public void Grab(GameObject objectGrabbed)
    {
        this.objectGrabbed = objectGrabbed;

        this.objectGrabbed.transform.parent = grabParent.transform;
        this.objectGrabbed.transform.localPosition = Vector3.zero;
    }

    public void UnGrab()
    {
        if (objectGrabbed == null)
            return;

        objectGrabbed.transform.parent = null;
    }
}
