using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Moon", menuName = "ScriptableObjects/Celestial/Moon", order = 3)]
public class MoonDataSO : CelestialDataSO
{
    public Vector3 _moonScale;
    
    public float distanceToPlanet;
    
    public float _moonTurnSpeed;
    
    public float _moonOwnSpeed;
    
}
