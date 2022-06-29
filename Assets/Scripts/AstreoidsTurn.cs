using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstreoidsTurn : MonoBehaviour
{
    [SerializeField] private float turnSpeed;

    private void Start()
    {
        //Start the movement function
        StartCoroutine(RotationOwnAxis());
    }
    IEnumerator RotationOwnAxis()
    {
        //It turns the actreoids on their own axis.
        transform.Rotate(Vector3.forward, turnSpeed);
        
        //End of Frame
        yield return new WaitForEndOfFrame();
        
        //Start again the movement function
        StartCoroutine(RotationOwnAxis());
    }
}
