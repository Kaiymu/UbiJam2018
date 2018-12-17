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

    [Header("Dash")]
    public float dashForce = 10f;
    public float dashRecovery = 2f;

    private float _deltaTimeAdd;

    private Rigidbody2D _rig2D;

    private bool _isDashing = false;

    private void Awake()
    {
        _rig2D = GetComponent<Rigidbody2D>();
    }

    public void FixedUpdate()
    {
        _deltaTimeAdd += Time.deltaTime;

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

        // Dashing
        if (Input.GetKeyDown(KeyCode.E) && !_isDashing) {
            _isDashing = true;
            _rig2D.AddForce(velocity * dashForce, ForceMode2D.Impulse);
        }

        if(_deltaTimeAdd > dashRecovery && _isDashing) {
            _deltaTimeAdd = 0f;
            _isDashing = false;
        }

    }

}
