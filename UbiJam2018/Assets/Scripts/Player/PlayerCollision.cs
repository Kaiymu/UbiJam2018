using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour {

    private PlayerGrab _playerGrab;
    private Player _player;

    private void Awake()
    {
        _playerGrab = GetComponent<PlayerGrab>();
        _player = GetComponent<Player>();
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

        if (collision.gameObject.tag == "Farm") {
            var farmingZone = collision.gameObject.GetComponent<FarmingZone>();

            if (Input.GetKeyDown(KeyCode.A) && farmingZone != null && farmingZone.playersFarm == _player.playerType) {
                _playerGrab.UnGrab();
            }
        }
    }

}
