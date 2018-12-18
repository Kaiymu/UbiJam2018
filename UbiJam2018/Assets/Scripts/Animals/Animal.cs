using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour {

    [Header("Animal")]
    [Range(0, 100)]
    public float probability;

    public float _velocity;
    public int intervalChangeDirectionInSec;

    private float _nextChangeOfDirection;
    private Rigidbody2D _rig2D;

    void MoveRandomly()
    {
        if (Random.value > 0.5)
        {
            _rig2D.AddForce(-transform.right * _velocity, ForceMode2D.Force);
        } else
        {
            _rig2D.AddForce(transform.right * _velocity, ForceMode2D.Force);
        }

        if (Random.value > 0.5)
        {
            _rig2D.AddForce(transform.up * _velocity, ForceMode2D.Force);
        } else
        {
            _rig2D.AddForce(-transform.up * _velocity, ForceMode2D.Force);
        }
        _nextChangeOfDirection = Time.time + intervalChangeDirectionInSec;
    }

    void Start()
    {
        _rig2D = GetComponent<Rigidbody2D>();
        _nextChangeOfDirection = Time.time;
    }

    void Update()
    {
        if (Time.time > _nextChangeOfDirection)
        {
            MoveRandomly();
        }
    }
}
