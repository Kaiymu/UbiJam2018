using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sheep : Animal
{

    new int points = 5;

    protected override void Move()
    {

        Vector2 _direction = new Vector2();
        if (Random.value > 0.5)
        {
            _direction.x = -transform.right.x;
        }
        else
        {
            _direction.x = transform.right.x;
        }

        if (Random.value > 0.5)
        {
            _direction.y = transform.up.y;
        }
        else
        {
            _direction.y = -transform.up.y;
        }
        _rig2D.AddForce(_direction * _velocity, ForceMode2D.Impulse);
        _nextChangeOfDirection = Time.time + intervalChangeDirectionInSec;
    }
    protected override void changeDirection(bool up, bool down, bool right, bool left)
    {
        Vector2 _direction = new Vector2();
        if (up)
        {
            _direction.y = transform.up.y;
        }
        if (down)
        {
            _direction.y = -transform.up.y;
        }
        if (right)
        {
            _direction.x = transform.right.x;
        }
        if (left)
        {
            _direction.x = -transform.right.x;
        }
        _rig2D.AddForce(_direction * _velocity, ForceMode2D.Impulse);
        _nextChangeOfDirection = Time.time + intervalChangeDirectionInSec;
    }

    public override void AnimalGrabbed(PlayerMovement playerMovement)
    {
        base.AnimalGrabbed(playerMovement);
        playerMovement.dashRecovery = playerMovement.dashRecovery *dashPlayerGrabbedReduce;
        playerMovement.playerSpeed = playerMovement.playerSpeed / speedPlayerGrabbedReduce;
    }
}