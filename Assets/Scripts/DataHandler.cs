using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataHandler : MonoBehaviour
{
    public LevelDataSO LevelData;
    
    [HideInInspector]
    public AsteroidsDataSO MeteorData;
    
    public CelestialDataSO CelestialData => _celestialData;
    
    private CelestialDataSO _celestialData;
   

    
}
