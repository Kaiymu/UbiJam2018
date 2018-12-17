using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public List<KeyCode> left;
    public List<KeyCode> right;
    public List<KeyCode> up;
    public List<KeyCode> down;
    public List<KeyCode> useBonus;

    [Header("Speed")]
    public float playerSpeed = 50f;

    private Rigidbody2D _rig2D;

    private void Awake()
    {
        _rig2D = GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
        var inputManagerHorizontal = InputManager.Instance.GoHorizontal(left, right);
        var inputManagerVertical = InputManager.Instance.GoVertical(up, down);

        Vector2 velocity = new Vector2();
        if (inputManagerHorizontal > 0) {
            velocity.x = (-transform.right * playerSpeed).x;
            Debug.Log("Going left");
        } else if(inputManagerHorizontal < 0){
            velocity.x = (transform.right * playerSpeed).x;
        }

        if (inputManagerVertical > 0) {
            velocity.y = (transform.up * playerSpeed).y;
        } else if (inputManagerVertical < 0) {
            velocity.y = (-transform.up * playerSpeed).y;
        }

        _rig2D.velocity = velocity;
    }

}
