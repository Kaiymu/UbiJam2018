using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour {

    public Player player;
    private PlayerGrab _playerGrab;
    private PlayerMovement _playerMovement;

    private void Awake()
    {
        _playerGrab = player.GetComponent<PlayerGrab>();
        _playerMovement = player.GetComponent<PlayerMovement>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player" && _playerMovement.movementState == PlayerMovement.MovementState.DASH) {
            collision.gameObject.GetComponent<PlayerMovement>().stun = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Animals") {
            if(_playerMovement.movementState == PlayerMovement.MovementState.DASH) {
                _playerGrab.Grab(collision.gameObject);
            }
        }

        if (collision.gameObject.tag == "Farm") {
            var farmingZone = collision.gameObject.GetComponent<FarmingZone>();

            if (farmingZone != null && farmingZone.playersFarm == player.playerType) {
                farmingZone.AddAnimalsInFarm(_playerGrab.objectGrabbed.GetComponent<Animal>());
                _playerGrab.UnGrab();
            }
        }
    }

}
