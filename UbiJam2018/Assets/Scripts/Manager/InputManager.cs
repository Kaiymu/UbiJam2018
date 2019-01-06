using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;

    void Awake()
    {
        if (Instance == null) {
            Instance = this;
        } else {
            Destroy(this.gameObject);
        }
    }

    public bool UseAnyKey(List<KeyCode> keycodeList)
    {
        for (int i = 0; i < keycodeList.Count; i++) {
            var leftKey = keycodeList[i];

            if (Input.GetKey(leftKey)) {
                return true;
            }
        }

        return false;
    }

    public float GetJoystickHorizontalFromPlayer(GameManager.Players players) {

        return Input.GetAxis("Horizontal" + PlayerAxisName(players));
    }

    public float GetJoystickVerticalFromPlayer(GameManager.Players players)
    {
        return Input.GetAxis("Vertical" + PlayerAxisName(players));
    }

    public bool GetJoystickSubmit(GameManager.Players players)
    {
        if (players == GameManager.Players.PLAYER_ONE) {
            return Input.GetKeyDown(KeyCode.Joystick1Button5);
        } else if (players == GameManager.Players.PLAYER_TWO) {
            return Input.GetKeyDown(KeyCode.Joystick2Button5);
        } else if (players == GameManager.Players.PLAYER_THREE) {
            return Input.GetKeyDown(KeyCode.Joystick1Button4);
        } else if (players == GameManager.Players.PLAYER_FOUR) {
            return Input.GetKeyDown(KeyCode.Joystick2Button5);
        }

        return false;
    }

    public string PlayerAxisName(GameManager.Players players)
    {
        if (players == GameManager.Players.PLAYER_ONE) {
            return "P1";
        } else if (players == GameManager.Players.PLAYER_TWO) {
            return "P2";
        } else if (players == GameManager.Players.PLAYER_THREE) {
            return "P3";
        } else if (players == GameManager.Players.PLAYER_FOUR) {
            return "P4";
        }

        return string.Empty;
    }

    public int GoHorizontal()
    {
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
            return 1;
        }

        if (Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) {
            return -1;
        }

        return 0;
    }

    public float GoHorizontal(List<KeyCode> left, List<KeyCode> right)
    {
        for (int i = 0; i < left.Count; i++) {
            var leftKey = left[i];

            if (Input.GetKey(leftKey)) {
                return 1f;
            }
        }

        for (int i = 0; i < right.Count; i++) {
            var rightKey = right[i];

            if (Input.GetKey(rightKey)) {
                return -1f;
            }
        }

        return 0f;
    }

    public int GoHorizontal(List<string> left, List<string> right)
    {
        for (int i = 0; i < left.Count; i++) {
            var leftKey = left[i];

            if (Input.GetKey(leftKey)) {
                return 1;
            }
        }

        for (int i = 0; i < right.Count; i++) {
            var rightKey = right[i];

            if (Input.GetKey(rightKey)) {
                return -1;
            }
        }

        return 0;
    }

    public bool IsGoingLeft()
    {
        if (Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) {
            return true;
        }

        return false;
    }

    public bool isGoingRight()
    {
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
            return true;
        }

        return false;
    }

    public bool IsGoingHorizontal()
    {
        if (isGoingRight() || IsGoingLeft())
            return true;

        return false;
    }


    // VERTICAl
    public int GoVertical()
    {
        if (Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) {
            return 1;
        }

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) {
            return -1;
        }

        return 0;
    }

    public int GoVertical(List<KeyCode> top, List<KeyCode> down)
    {
        for (int i = 0; i < top.Count; i++) {
            var leftKey = top[i];

            if (Input.GetKey(leftKey)) {
                return 1;
            }
        }

        for (int i = 0; i < down.Count; i++) {
            var rightKey = down[i];

            if (Input.GetKey(rightKey)) {
                return -1;
            }
        }

        return 0;
    }

    public bool IsGoingUp()
    {
        if (Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) {
            return true;
        }
        return false;
    }

    public bool IsGoingDown()
    {
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) {
            return true;
        }

        return false;

    }

    public bool IsGoingVertical()
    {
        if (IsGoingDown() || IsGoingUp())
            return true;

        return false;
    }
}