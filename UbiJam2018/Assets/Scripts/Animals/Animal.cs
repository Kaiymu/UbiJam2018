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

    protected Vector2 zoneTopLeft;
    protected Vector2 zoneBottomRight;
    protected float _nextChangeOfDirection;
    protected Rigidbody2D _rig2D;

    [HideInInspector]
    public bool isGrabbed;
    [HideInInspector]
    public bool isInFarm;

    public float speedPlayerGrabbedReduce = 1.5f;
    public float dashPlayerGrabbedReduce = 2f;
    
    public bool CanBeGrabbed()
    {
        return (!isGrabbed && !isInFarm);
    }

    protected abstract void Move();

    protected abstract void changeDirection(bool up, bool down, bool right, bool left);

    private void Awake()
    {
        _rig2D = GetComponent<Rigidbody2D>();
        _nextChangeOfDirection = Time.time;
    }

    void Start()
    {
    }

    public void setBoundSize(Vector2 topLeft, Vector2 bottomRight)
    {
        zoneTopLeft = topLeft;
        zoneBottomRight = bottomRight;
    }

    void Update()
    {
        if (Time.time > _nextChangeOfDirection && CanBeGrabbed())
        {
            Move();
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        // Collision.gameobject.transform.parent.gameobject // Le player parent.
        if (collision.gameObject.tag == "TriggerFleeAnimal") {
            var playerPosition = collision.gameObject.transform.position;
            bool up = false;
            bool down = false;
            bool right = false;
            bool left = false;
            if (playerPosition.x > _rig2D.transform.position.x)
            {
                left = true;
            } else
            {
                right = true;
            }
            if (playerPosition.y > _rig2D.transform.position.y)
            {
                down = true;
            }
            else
            {
                up = true;
            }
            changeDirection(up, down, right, left);
        }
    }

    public virtual void AnimalGrabbed(PlayerMovement playerMovement)
    {
        isGrabbed = true;
    }
}
