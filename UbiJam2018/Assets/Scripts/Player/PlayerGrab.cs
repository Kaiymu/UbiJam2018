using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrab : MonoBehaviour {

    public Transform grabParent;
    public FXFumee fxFumee;

    private PlayerMovement _playerMovement;

    private void Awake()
    {
        _playerMovement = GetComponent<PlayerMovement>();
    }

    [HideInInspector]
    public GameObject animalHold;
	public void Grab(GameObject animalGrabbed)
    {
        if (animalHold != null)
            return;

        animalHold = animalGrabbed;

        animalHold.transform.parent = grabParent.transform;
        animalHold.transform.localPosition = Vector3.zero;

        animalHold.GetComponent<Animal>().AnimalGrabbed(_playerMovement);
        animalHold.GetComponent<Rigidbody2D>().simulated = false;
    }

    public void UnGrab()
    {
        if (animalHold == null)
            return;

        Instantiate(fxFumee, animalHold.transform.position, Quaternion.identity);
        _playerMovement.ResetMovementValue();
        Destroy(animalHold);
    }

    public void StealAnimal()
    {
        animalHold = null;
        _playerMovement.ResetMovementValue();
        _playerMovement.stun = true;
    }

    public void DropAnimal()
    {
        animalHold.GetComponent<Animal>().AnimalDropped();
        animalHold.GetComponent<Rigidbody2D>().simulated = true;
        animalHold.transform.parent = null;

        _playerMovement.ResetMovementValue();
        _playerMovement.stun = true;

        animalHold = null;

    }
}
