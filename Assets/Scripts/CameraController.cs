using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CameraController : MonoBehaviour
{
    public static CameraController instance;
    
    [SerializeField] private Transform _targetObj;
    [SerializeField] [Range(1,10)]private float _mouseSensitivity ;
    
    private bool _isMoving = false;
    private float _timer = 3;
    private float _speedCoef = 0.5f;
    private float _scrollSpeed = 5;

    public bool IsMoving
    {
        get => _isMoving;
        set => _isMoving = value;
    }
    
    private void Start()
    { 
        //Instance
        instance = this;
        
        //Start Camera Movement
        StartCoroutine(MoveCamera());
    }
    

    IEnumerator MoveCamera()
    {
        while (true)
        {
            //Zoom In&Out Effect
            if (Input.GetAxis("Mouse ScrollWheel") != 0)
            {
                ChangeProjectionSize();
                yield return new WaitForEndOfFrame();
            }
            
            //Rotate Camera Manually
            if (Input.GetMouseButton(0))
            {
                RotateWithMouse();
                _timer = 3;
                yield return new WaitForEndOfFrame();
            }
            
            else
            {
                //If the camera is idle
                if (_isMoving || !ClickableObjects.instance.IsClicked) 
                {
                    //If the if condition use IsClicked boolean to enter this block set the moving condition true
                    if (!_isMoving)
                    {
                        _isMoving = true;
                    }
                    
                    //Wait for 3 seconds to Start Camera Movement
                    yield return new WaitForSeconds(_timer);
                    
                    //Reset Timer
                    _timer = 0;
                    
                    //Start Camera Movement Around Target Object
                    transform.RotateAround(_targetObj.position, Vector3.up, _speedCoef * Time.deltaTime);
                    
                    //Lock Camera Position to Target Object
                    transform.LookAt(_targetObj.transform);
                    
                }
                else 
                { 
                    yield return new WaitForEndOfFrame();
                    
                    //Set timer
                    _timer = 3;
                }
            }
        }
    }
    
    private void RotateWithMouse()
    {
        if (_isMoving) 
        { 
            //Stop Camera Movement
            _isMoving = false;
        }
        
        //Get input from the mouse
        float mouseX = Input.GetAxis("Mouse X");
        
        //Rotate camera with mouse input
        transform.RotateAround(_targetObj.position, Vector3.up, mouseX * _mouseSensitivity);
        
        //Lock Camera Position to Target Object
        transform.LookAt(_targetObj.position);
    }
    
    private void ChangeProjectionSize()
    {
        //Set new camera projection size like zoom effect using scroll wheel
        float projectionSize = Camera.main.orthographicSize - Input.GetAxis("Mouse ScrollWheel") * _scrollSpeed;
        
        if (projectionSize > 5 && projectionSize < 45)
        {
            Camera.main.orthographicSize = projectionSize;
        }
    }
}
