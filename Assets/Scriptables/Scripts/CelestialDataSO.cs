using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public abstract class CelestialDataSO : ScriptableObject
{
    public string CelestialName;
    
    public string CelestialDescription;
    
    public GameObject CelestialPrefab;

    public GameObject[] CelestialTarget;

}
