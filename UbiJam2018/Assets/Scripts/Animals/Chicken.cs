using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : Animal {


    public Chicken()
    {
        points = 1;
    }

    protected override void Move()
    {
        if (Random.value > 0.5)
        {
            _rig2D.AddForce(-transform.right * _velocity, ForceMode2D.Force);
        }
        else
        {
            _rig2D.AddForce(transform.right * _velocity, ForceMode2D.Force);
        }

        if (Random.value > 0.5)
        {
            _rig2D.AddForce(transform.up * _velocity, ForceMode2D.Force);
        }
        else
        {
            _rig2D.AddForce(-transform.up * _velocity, ForceMode2D.Force);
        }
        _nextChangeOfDirection = Time.time + intervalChangeDirectionInSec;
    }

    protected override void changeDirection(bool up, bool down, bool right, bool left)
    {
        if (up)
        {
            _rig2D.AddForce(transform.up * _velocity, ForceMode2D.Force);
        }
        if (down)
        {
            _rig2D.AddForce(-transform.up * _velocity, ForceMode2D.Force);
        }
        if (right)
        {
            _rig2D.AddForce(transform.right * _velocity, ForceMode2D.Force);
        }
        if (left)
        {
            _rig2D.AddForce(-transform.right * _velocity, ForceMode2D.Force);
        }
        _nextChangeOfDirection = Time.time + intervalChangeDirectionInSec;
    }

    public override void AnimalGrabbed(PlayerMovement playerMovement)
    {
        base.AnimalGrabbed(playerMovement);
        playerMovement.dashRecovery = playerMovement.dashRecovery * dashPlayerGrabbedReduce;
    }
}
