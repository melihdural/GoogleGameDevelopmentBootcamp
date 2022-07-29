using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "Asteroid", menuName = "ScriptableObjects/Celestial/Asteroid", order = 4)]
public class AsteroidsDataSO : CelestialDataSO
{
    public Quaternion _asteroidRotation;
    
    private Vector3 _asteroidPosition;

    private Vector3 _asteroidScale;
    
    private float _asteroidSpeed;
    

    
}
