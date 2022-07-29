using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LapCounter : MonoBehaviour
{
    private DataHandler dataHandler;
    private int _lap;

    private void OnTriggerEnter(Collider other)
    {
        //If the invisible start object in the scene is touched, it increases the number of rounds and prints it on the screen.
        if (other.gameObject.CompareTag("Planet"))
        {
            if (_lap>0)
            {
                //Prints the number of laps on the Console.
                Debug.Log($"{other.gameObject.name} has completed one full orbit around the sun. Its {_lap} round. ", other.gameObject);
            }
            
            _lap++;

        }
       
    }
}
