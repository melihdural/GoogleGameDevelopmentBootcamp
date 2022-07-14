using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class RotateAround : MonoBehaviour
{
    [SerializeField] private Transform _sunTransform;
    [SerializeField] private float _turnSpeed;
    [SerializeField] private GameObject _earth;
    [SerializeField] private GameObject _moon;

    private float _moonOffset = 1.78f;

    private Vector3 _earthPosition;

    private Vector3 _moonPosition;

    private void Awake()
    {
        //Records the starting positions of the earth and the moon.
        _earthPosition = GameObject.Find("Earth").transform.position;
        _moonPosition = GameObject.Find("Moon").transform.position;

    }
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
            if (!_sunTransform)
            {
                yield break;
            }
        
            //It rotates the planets on the axis of the sun.
            transform.RotateAround(_sunTransform.position, Vector3.up, _turnSpeed*Time.deltaTime);
        
            //Keeps the moon stable around the earth
            _moonPosition.x = _earthPosition.x - _moonOffset;
        
            //End of frame
            yield return new WaitForEndOfFrame();
        }
    }
    
}
