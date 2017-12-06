using CnControls;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour {
    
    public Transform parentTarget;
    public Transform target;
    public float RotationSpeed = 15f;

    public ControlType control;
    public GameEvent shoot;

    private Action controller;
    private bool rotate = true;
        
    private void Start()
    {
        InitControl(control);
    }

    public void InitControl(ControlType type)
    {
        if (type != control)
        {
            control = type;
        }
        switch (control)
        {
            case ControlType.AllScene:
                controller = AllArea;
                break;
            case ControlType.Touchpad:
                controller = Touchpad;
                break;
            case ControlType.Joystick:
                controller = Joystick;
                break;
            case ControlType.Auto:
                controller = Auto;
                break;
        }
    }

    void Update () {
        if (rotate)
        {
            controller();
        }
    }

    public void BlockRotate()
    {
        rotate = false;
    }

    public void UnblockRotate()
    {
        rotate = true;
    }

    private void AllArea()
    {
        target.position = -Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonUp(0))
        {
            shoot.Raise();
        }
    }

    private void Touchpad()
    {
        //var horizontalMovement = CnInputManager.GetAxis("Horizontal");
        var verticalMovement = CnInputManager.GetAxis("Vertical");

        //parentTarget.Rotate(Vector3.forward, horizontalMovement * Time.deltaTime * RotationSpeed);        
        parentTarget.Rotate(Vector3.forward, verticalMovement * Time.deltaTime * RotationSpeed);

        if (Input.GetMouseButtonUp(0))
        {
            shoot.Raise();
        }
    }

    private void Joystick()
    {
        Vector2 inputVector = new Vector2(CnInputManager.GetAxis("Horizontal"), CnInputManager.GetAxis("Vertical")).normalized;
        float angle = Mathf.Rad2Deg * Mathf.Atan(inputVector.x / inputVector.y);
        angle = inputVector.y > 0 ? -angle : 180 - angle;
        if (!float.IsNaN(angle))
        {
            parentTarget.eulerAngles = new Vector3(0, 0, angle);
        }
    }

    private void Auto()
    {
        parentTarget.Rotate(Vector3.forward, Time.deltaTime * RotationSpeed);        
    }
}

[System.Serializable]
public enum ControlType
{
    AllScene,
    Touchpad,
    Joystick,
    Auto
}
