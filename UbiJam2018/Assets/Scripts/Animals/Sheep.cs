﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sheep : Animal
{

    public Sheep() : base()
    {
        points = 2;
    }

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
}