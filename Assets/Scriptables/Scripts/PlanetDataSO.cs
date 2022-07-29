using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Planet", menuName = "ScriptableObjects/Celestial/Planet", order = 2)]
public class PlanetDataSO : CelestialDataSO
{
    public Vector3 _planetScale;
    
    public float _distanceToSun;

    public float _planetTurnSpeed;
    
    public float _planetOwnSpeed;
    
}
