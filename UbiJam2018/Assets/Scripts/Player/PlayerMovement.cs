using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public List<KeyCode> left;
    public List<KeyCode> right;
    public List<KeyCode> up;
    public List<KeyCode> down;
    public List<KeyCode> useBonus;

    public enum MovementState { NONE, IDLE, DASH, MOVE}
    public MovementState movementState;

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

        Vector2 _direction = new Vector2();
        if (inputManagerHorizontal > 0) {
            _direction.x = -transform.right.x;
            _rig2D.AddForce(-transform.right * playerSpeed, ForceMode2D.Force);
        } else if(inputManagerHorizontal < 0){
            _direction.x = transform.right.x;
            _rig2D.AddForce(transform.right * playerSpeed, ForceMode2D.Force);
        }

        if (inputManagerVertical > 0) {
            _direction.y = transform.up.y;
            _rig2D.AddForce(transform.up * playerSpeed, ForceMode2D.Force);
        } else if (inputManagerVertical < 0) {
            _direction.y = -transform.up.y;
            _rig2D.AddForce(-transform.up * playerSpeed, ForceMode2D.Force);
        }

        // Dashing
        if (Input.GetKeyDown(KeyCode.E) && !_isDashing) {
            _rig2D.AddForce(_direction * dashForce, ForceMode2D.Impulse);
        }

        if(_deltaTimeAdd > dashRecovery && _isDashing) {
            _deltaTimeAdd = 0f;
        }

        _MovementState(_rig2D.velocity);
    }

    private void _MovementState(Vector2 velocity)
    {
        if(velocity != Vector2.zero) {
            if(Mathf.Abs(velocity.x) > 10f || Mathf.Abs(velocity.y) > 10f) {
                movementState = MovementState.DASH;
            } else {
                movementState = MovementState.MOVE;
            }
        } else {
            movementState = MovementState.IDLE;
        }
    }
    
}
