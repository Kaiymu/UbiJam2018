using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrab : MonoBehaviour {

    public Transform grabParent;

    [HideInInspector]
    public GameObject animalHold;
	public void Grab(GameObject animalGrabbed)
    {
        if (animalHold != null)
            return;

        animalHold = animalGrabbed;

        animalHold.transform.parent = grabParent.transform;
        animalHold.transform.localPosition = Vector3.zero;

        animalHold.GetComponent<Animal>().isGrabbed = true;
        animalHold.GetComponent<Rigidbody2D>().simulated = false;
    }

    public void UnGrab()
    {
        if (animalHold == null)
            return;

        Destroy(animalHold);
    }
}
