using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager instance;
    
    [SerializeField] private GameObject _meteorPrefab;
    [SerializeField] private GameObject[] _planets;
    private Vector3 _meteorSpawnPos;

    private float xRange = 45;
    private float yRange = 50;
    private float zRange = 30;
    
    public GameObject[] Planets
    {
        get => _planets;
    }

    private void Start()
    {
        //Instance
        instance = this;
    }

    private void Update()
    {
        //When pressing space, spawn meteor
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnMeteor();
        }
    }
    

    private void SpawnMeteor()
    {
        //Set random spawn position
        _meteorSpawnPos = new Vector3(Random.Range(-xRange, xRange), Random.Range(-yRange, yRange), Random.Range(-zRange, zRange));
        
        //Spawn meteor
        Instantiate(_meteorPrefab, _meteorSpawnPos, Quaternion.identity); 
    }
}
