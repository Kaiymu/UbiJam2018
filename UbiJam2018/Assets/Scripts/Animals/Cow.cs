using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cow : Animal
{

    public Cow() : base()
    {
        points = 5;
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
}
