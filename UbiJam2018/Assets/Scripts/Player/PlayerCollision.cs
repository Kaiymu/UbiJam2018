using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour {


    private PlayerGrab _playerGrab;
    private void Awake()
    {
        _playerGrab = GetComponent<PlayerGrab>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.LogError(collision.gameObject.tag);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Animals") {
            if(Input.GetKeyDown(KeyCode.A)) {
                _playerGrab.Grab(collision.gameObject);
            }
        }
    }

}
