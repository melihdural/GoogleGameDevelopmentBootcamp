using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MoveToTargetPlanet : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private Vector3 _targetPosition;
    private Vector3 _distanceToTarget;
    private float _speedCoef  = 1f;
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _targetPosition = Vector3.zero;
    }

    private void Update()
    {
        _distanceToTarget = _targetPosition - transform.position;
        _distanceToTarget.Normalize();
        _rigidbody.AddForce(_distanceToTarget* _speedCoef);
    }

    
}
