using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Animal : MonoBehaviour {

    [Header("Animal")]
    [Range(0, 100)]
    public float probability;

    public float _velocity;
    public int intervalChangeDirectionInSec;
    public int points;
    public int velocityModifier;

    protected float _nextChangeOfDirection;
    protected Rigidbody2D _rig2D;

    public bool isGrabbed;
    public bool isInFarm;

    public bool CanBeGrabbed()
    {
        return (!isGrabbed && !isInFarm);
    }

    protected abstract void Move();

    void Start()
    {
        _rig2D = GetComponent<Rigidbody2D>();
        _nextChangeOfDirection = Time.time;
    }

    void Update()
    {
        if (Time.time > _nextChangeOfDirection && CanBeGrabbed())
        {
            Move();
        }
    }
}
