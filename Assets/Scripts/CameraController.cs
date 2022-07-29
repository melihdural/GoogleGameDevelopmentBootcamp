using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CameraController : MonoBehaviour
{

    [SerializeField]
    [Range(1, 10)]
    private float _mouseSensitivity;

    private bool _isMoving = false;

    private float _timer = 3;

    private float _speedCoef = 0.5f;

    private float _scrollSpeed = 5;


    private void Start()
    {
        //Start Camera Movement
        StartCoroutine(MoveCamera());
    }


    // ReSharper disable Unity.PerformanceAnalysis
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

            if (Input.GetMouseButton(0))
            {
                RotateWithMouse();
                _isMoving = false;
                _timer = 3;
                yield return new WaitForEndOfFrame();
            }

            else
            {
                if (_isMoving)
                {
                    //Reset Timer
                    _timer = 0;

                    //Start Camera Movement Around Target Object
                    transform.RotateAround(Vector3.zero, Vector3.up, _speedCoef * Time.deltaTime);

                    //Lock Camera Position to Target Object
                    transform.LookAt(Vector3.zero);

                    yield return new WaitForEndOfFrame();
                }
                else
                {
                    yield return new WaitForSeconds(_timer);

                    //Set Camera to Moving
                    _isMoving = true;

                    //Set Timer
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
        transform.RotateAround(Vector3.zero, Vector3.up, mouseX * _mouseSensitivity);

        //Lock Camera Position to Target Object
        transform.LookAt(Vector3.zero);
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
