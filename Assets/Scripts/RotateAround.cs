using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAround : MonoBehaviour
{
    [SerializeField] private Transform sunTransform;

    [SerializeField] private float turnSpeed;

    private float moonOffset = 1.78f;

    private Vector3 earthPosition;

    private Vector3 moonPosition;

    private void Awake()
    {
        //Records the starting positions of the earth and the moon.
        earthPosition = GameObject.Find("Earth").transform.position;
        moonPosition = GameObject.Find("Moon").transform.position;

    }
    private void Start()
    {
        //Start the movement function
        StartCoroutine(PlanetRotation());
    }
    IEnumerator PlanetRotation()
    {
        //Guarding Clause
        if (!sunTransform)
        {
            yield break;
        }
        
        //It rotates the planets on the axis of the sun.
        transform.RotateAround(sunTransform.position, Vector3.up, turnSpeed*Time.deltaTime);
        
        //Keeps the moon stable around the earth
        moonPosition.x = earthPosition.x - moonOffset;
        
        //End of frame
        yield return new WaitForEndOfFrame();
        
        //Start again the movement function
        StartCoroutine(PlanetRotation());
    }
    
}
