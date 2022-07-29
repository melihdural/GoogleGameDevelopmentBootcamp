using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class RotateAround : MonoBehaviour
{
    [SerializeField] private GameObject _targetObject; 
    [SerializeField] private float _turnSpeed;
    public GameObject TargetObject {get => _targetObject; set => _targetObject = value;}
   
    
    private void Start()
     {
         //Start the movement function
        StartCoroutine(PlanetRotation());
     }
     
     IEnumerator PlanetRotation()
     {
         while (true)
         {
             //Guarding Clause
             if (!_targetObject)
                yield break;
            
             //It rotates the planets on the axis of the sun.
             transform.RotateAround(_targetObject.transform.position, Vector3.up, _turnSpeed * Time.deltaTime);
         
             //End of frame
             yield return new WaitForEndOfFrame();
         }
     }
     
}
