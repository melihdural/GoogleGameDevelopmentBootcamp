using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Sun", menuName = "ScriptableObjects/Celestial/Sun", order = 1)]
public class SunDataSO : CelestialDataSO
{
    public Vector3 _sunPosition;

    public Vector3 _sunScale;
    
    public float _sunTurnSpeed;
}
