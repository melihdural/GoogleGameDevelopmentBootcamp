using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MoveToTargetPlanet : MonoBehaviour
{
    [SerializeField] private float _speedCoef;
    private GameObject[] _targets;
    private Vector3 _startPosition;
    private float _journeyLength;
    private float _distanceCovered;
    private int _targetIndex;

    private void Awake()
    {
        //Set the targets array from the planets in the hierarchy
        _targets = SpawnManager.instance.Planets;
    }
    
    private void Start()
    {
        //Set a Random Planet as a target
        _targetIndex = GetRandomTargetIndex();
        Debug.Log("A meteor is approaching " + _targets[_targetIndex].name);
        
        //Set the start position of the meteor
        _startPosition = transform.position;
        
        //Calculate the journey length
        _journeyLength = Vector3.Distance(_startPosition, _targets[_targetIndex].transform.position);
    }

    private void Update()
    {
        //Calculate the distance covered
        _distanceCovered += _speedCoef * Time.deltaTime;
        
        //Calculate the percentage of the journey completed
        float _fractionOfJourney = _distanceCovered / _journeyLength;
        
        //Move the meteor towards the target planet
        transform.position = Vector3.Lerp(_startPosition, _targets[_targetIndex].transform.position, _fractionOfJourney);
        
    }

    private int GetRandomTargetIndex()
    {
        return Random.Range(0, _targets.Length);
    }
}
