﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [Header("Player inputs")]
    public List<KeyCode> left;
    public List<KeyCode> right;
    public List<KeyCode> up;
    public List<KeyCode> down;
    public List<KeyCode> useBonus;

    public enum MovementState { NONE, IDLE, DASH, MOVE }
    public MovementState movementState;

    [Header("Speed")]
    public float playerSpeed = 50f;

    [Header("Dash")]
    public float dashForce = 10f;
    public float dashRecovery = 2f;

    [Header("Stun")]
    public float stunTime = 0.3f;
    private float _stunTime = 0f;

    private float _deltaTimeAdd;

    private Rigidbody2D _rig2D;

    private bool _isDashing = false;

    private Player _player;

    private Animator _animator;

    private SpriteRenderer _spriteRenderer;

    private PlayerGrab _playerGrab;

    private float _dashRecovery;
    private float _playerSpeed;

    public AudioClip dashSound;
    public AudioClip stunSound;

    private AudioSource _audioSource;

    [HideInInspector]
    public bool _stun;

    public bool stun
    {
        get { return _stun; }
        set
        {
            _stun = value;
            if (value) {
                _audioSource.PlayOneShot(stunSound);
            }
        }
    }

    private void Awake()
    {
        _rig2D = GetComponent<Rigidbody2D>();
        _player = GetComponent<Player>();
        _audioSource = GetComponent<AudioSource>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _playerGrab = GetComponent<PlayerGrab>();

        _dashRecovery = dashRecovery;
        _playerSpeed = playerSpeed;
    }

    public void FixedUpdate()
    {
        if (GameManager.Instance.gameState != GameManager.GameState.PLAY)
            return;

        if (stun)
        {
            _stunTime += Time.deltaTime;
            _animator.SetInteger("Action", 3);
            if (_stunTime > stunTime)
            {
                stun = false;
                _stunTime = 0f;
            }

            return;
        }


        var inputManager = InputManager.Instance;
        var inputKeyboardHorizontal = inputManager.GoHorizontal(left, right);
        var inputKeyboardVertical = inputManager.GoVertical(up, down);

        var inputJoystickHorizontal = inputManager.GetJoystickHorizontalFromPlayer(_player.playerType);
        var inputJoystickVertical = inputManager.GetJoystickVerticalFromPlayer(_player.playerType);

        Vector2 _direction = new Vector2();
        if (inputKeyboardHorizontal > 0 || inputJoystickHorizontal > 0)
        {
            _direction.x = -transform.right.x;
        }
        else if (inputKeyboardHorizontal < 0 || inputJoystickHorizontal < 0)
        {
            _direction.x = transform.right.x;
        }

        if (inputKeyboardVertical > 0 || inputJoystickVertical > 0)
        {
            _direction.y = transform.up.y;
        }
        else if (inputKeyboardVertical < 0 || inputJoystickVertical < 0)
        {
            _direction.y = -transform.up.y;
        }

        _rig2D.AddForce(_direction.normalized * playerSpeed, ForceMode2D.Force);

        // Dashing
        if ((Input.GetKeyDown(KeyCode.E) || inputManager.GetJoystickSubmit(_player.playerType)) && !_isDashing)
        {
            _isDashing = true;
            _audioSource.PlayOneShot(dashSound);
            _rig2D.AddForce(_direction.normalized * dashForce, ForceMode2D.Impulse);
        }

        if (_isDashing)
            _deltaTimeAdd += Time.deltaTime;

        if (_deltaTimeAdd > dashRecovery && _isDashing)
        {
            _deltaTimeAdd = 0f;
            _isDashing = false;
        }

        _MovementState(_rig2D.velocity);
    }

    private void _MovementState(Vector2 velocity)
    {
        if (velocity.magnitude > 2)
        {
            if (Mathf.Abs(velocity.x) > 10f || Mathf.Abs(velocity.y) > 10f)
            {
                movementState = MovementState.DASH;
                _animator.SetInteger("Action", 4);
            }
            else
            {
                movementState = MovementState.MOVE;
                _spriteRenderer.flipX = velocity.x > 0;

                if (_playerGrab.animalHold == null)
                {
                    _animator.SetInteger("Action", 1);
                }
                else
                {
                    _animator.SetInteger("Action", 2);
                }
            }
        }
        else
        {
            if (movementState != MovementState.IDLE)
            {
                movementState = MovementState.IDLE;
                _animator.SetInteger("Action", 0);
            }
        }
    }

    public void ResetMovementValue()
    {
        dashRecovery = _dashRecovery;
        playerSpeed = _playerSpeed;
    }

}
