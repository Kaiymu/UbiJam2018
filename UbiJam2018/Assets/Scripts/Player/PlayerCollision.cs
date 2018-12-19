using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

    public Player player;
    private PlayerGrab _playerGrab;
    private PlayerMovement _playerMovement;

    private void Awake()
    {
        _playerGrab = player.GetComponent<PlayerGrab>();
        _playerMovement = player.GetComponent<PlayerMovement>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Animals")
        {
            if (_playerMovement.movementState == PlayerMovement.MovementState.DASH)
            {
                _playerGrab.Grab(collision.gameObject);
            }
        }

        if (collision.gameObject.tag == "Farm")
        {
            var farmingZone = collision.gameObject.GetComponent<FarmingZone>();

            if (farmingZone != null && farmingZone.playersFarm == player.playerType && _playerGrab.animalHold != null)
            {
                Animal animal = _playerGrab.animalHold.GetComponent<Animal>();
                farmingZone.AddAnimalsInFarm(animal);
                _playerGrab.UnGrab();
                GameManager.addPoints(player.playerType, animal);
            }
        }

        if (collision.gameObject.tag == "TriggerPlayer" && _playerMovement.movementState == PlayerMovement.MovementState.DASH)
        {
            var playerEnnemy = collision.transform.parent.gameObject;


            }
        }
    }

}
