using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstreoidsTurn : MonoBehaviour
{
    private float turnSpeed = 0.5f;

    private void Start()
    {
        //Start the movement function
        StartCoroutine(RotationOwnAxis());
    }
    IEnumerator RotationOwnAxis()
    {
        while (true)
        {
            //It turns the actreoids on their own axis.
            transform.Rotate(Vector3.forward, turnSpeed * Time.deltaTime);
        
            //End of Frame
            yield return new WaitForEndOfFrame();
        }
    }
}
