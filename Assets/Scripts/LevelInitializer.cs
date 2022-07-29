using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LevelInitializer : MonoBehaviour
{
    public static event Action<DataHandler> SpawnLevel;
    
    private void Start()
    {
        SpawnLevelGameObjets();
    }
    
    public void SpawnLevelGameObjets()
    {
        SpawnLevel?.Invoke(GetComponent<DataHandler>());
    }
    
    
}
