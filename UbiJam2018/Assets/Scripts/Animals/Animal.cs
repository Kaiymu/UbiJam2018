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
        _nextChangeOfDirection = Time.time;
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
            //_rig2D.velocity = Vector2.zero;
            Move();
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        // Collision.gameobject => ton player
        if (collision.gameObject.tag == "TriggerFleeAnimal") {
            
        }
    }
}
