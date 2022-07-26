using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class TurnOwnAxis : MonoBehaviour
{
    [SerializeField] private float _turnSpeed;

    private void Start()
    {
        //Start the movement function
        StartCoroutine(RotationOwnAxis());
    }
    IEnumerator RotationOwnAxis()
    {
        while (true)
        {

            //It turns the planets on their own axis.
            transform.Rotate(Vector3.up, _turnSpeed * Time.deltaTime);
        
            //End of Frame
            yield return new WaitForEndOfFrame();
        }
    }
}
