using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrab : MonoBehaviour {

    public Transform grabParent;

    private GameObject _objectGrabbed;
	public void Grab(GameObject objectGrabbed)
    {
        _objectGrabbed = objectGrabbed;

        _objectGrabbed.transform.parent = grabParent.transform;
        _objectGrabbed.transform.localPosition = Vector3.zero;
    }

    public void UnGrab()
    {
        if (_objectGrabbed == null)
            return;

        _objectGrabbed.transform.parent = null;
    }
}
