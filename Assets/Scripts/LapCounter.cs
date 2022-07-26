using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class LapCounter : MonoBehaviour
{
    private int _lap;
    private void Awake()
    {
        //Turns off the gravity feature in the rigidbody component before the game starts.
        gameObject.GetComponent<Rigidbody>().useGravity = false;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        //If the invisible start object in the scene is touched, it increases the number of rounds and prints it on the screen.
        if (other.CompareTag("Start"))
        {
            //Increases lap count.
            _lap++;
            
            //Prints the number of laps on the Console.
            Debug.Log($"{gameObject.name} has completed one full orbit around the sun. Its {_lap} round. ", gameObject);
        }
    }
}
