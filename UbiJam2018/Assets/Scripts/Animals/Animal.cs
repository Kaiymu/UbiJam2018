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
    public GameObject animalZone;

    protected Vector2 zoneTopLeft;
    protected Vector2 zoneBottomRight;
    protected float _nextChangeOfDirection;
    protected Rigidbody2D _rig2D;
    protected Collider2D animalZoneCollider;

    public bool isGrabbed;
    public bool isInFarm;

    private bool firstUpdateDone = false;

    public bool CanBeGrabbed()
    {
        return (!isGrabbed && !isInFarm);
    }

    protected abstract void Move();

    protected abstract void changeDirection(bool up, bool down, bool right, bool left);

    private void Awake()
    {
        _rig2D = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        animalZoneCollider = animalZone.GetComponent<Collider2D>();

        _nextChangeOfDirection = Time.time;
    }

    public void setBoundSize(Vector2 topLeft, Vector2 bottomRight)
    {
        zoneTopLeft = topLeft;
        zoneBottomRight = bottomRight;
    }

    protected bool isOutOfBounds()
    {
        return false;

        if (_rig2D.transform.position.x <= zoneTopLeft.x)
        {
            if (_rig2D.transform.position.y >= zoneTopLeft.y)
            {
                changeDirection(false, true, true, false);
                return true;
            } else if(_rig2D.transform.position.y <= zoneBottomRight.y)
            {
                changeDirection(true, false, true, false);
                return true;
            }
            else
            {
                changeDirection(false, false, true, false);
                return true;
            }
        }
        else if (_rig2D.transform.position.x >= zoneBottomRight.x)
        {
            if (_rig2D.transform.position.y >= zoneTopLeft.y)
            {
                changeDirection(false, true, false, true);
                return true;
            }
            else if (_rig2D.transform.position.y <= zoneBottomRight.y)
            {
                changeDirection(true, false, false, true);
                return true;
            } else
            {
                changeDirection(false, false, false, true);
                return true;
            }
        } else
        {
            return false;
        }
    }

    void Update()
    {
        isOutOfBounds();
        if (Time.time > _nextChangeOfDirection && CanBeGrabbed())
        {
            //_rig2D.velocity = Vector2.zero;
            Move();
        }
    }
}
