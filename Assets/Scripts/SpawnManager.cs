using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    [HideInInspector]
    public static GameObject ghostPlanet;
    

    private void Awake()
    {
        LevelInitializer.SpawnLevel += SpawnLevel;
        InputManager.SpawnMeteor += SpawnMeteor;
    }
    
    private void OnDestroy()
    {
        InputManager.SpawnMeteor -= SpawnMeteor;
        LevelInitializer.SpawnLevel -= SpawnLevel;
    }
    
    
    public static void SpawnMeteor(DataHandler data)
    {
        float randomTetha = Random.Range(0f, 360f);
        Vector3 randomMetorPosition = GetRandomPositionOnOrbit(randomTetha, Random.Range(-50f, 50f));
       
        var meteorObject = Instantiate(data.MeteorData.CelestialPrefab, randomMetorPosition , Quaternion.identity);
    }
    
    void SpawnLevel(DataHandler data)
    {
        var levelData = data.LevelData;
        
        foreach (var sun in levelData.SunGroups)
        {
            Vector3 sunSpawnPosition = sun.Sun._sunPosition;
            var sunObject = Instantiate(sun.Sun.CelestialPrefab, sunSpawnPosition, Quaternion.identity);
            
            foreach (var asteroid in sun.CelestialDatas)
            {
                Vector3 asteroidSpawnPosition = sun.Sun._sunPosition;
                var asteroidObject = Instantiate(asteroid.Asteroids.CelestialPrefab, asteroidSpawnPosition, asteroid.Asteroids._asteroidRotation);
            }
            
            foreach (var planet in sun.Planets)
            {
                float randomTetha = Random.Range(0f, 360f);
                Vector3 randomOrbitPosition = sunSpawnPosition + GetRandomPositionOnOrbit(randomTetha, planet.Planet._distanceToSun);
                
                var planetObject = Instantiate(planet.Planet.CelestialPrefab, randomOrbitPosition, Quaternion.identity);
                
                ghostPlanet = Instantiate(levelData._ghostPlanet, planetObject.transform.position, Quaternion.identity);
                
                if (planetObject.GetComponent<RotateAround>() != null)
                {
                    planetObject.GetComponent<RotateAround>().TargetObject = sunObject;
                }

                foreach (var moon in planet.Moons)
                {
                    randomTetha = Random.Range(0f, 360f);
                    randomOrbitPosition = planetObject.transform.position + GetRandomPositionOnOrbit(randomTetha, moon.Moon.distanceToPlanet);
                    
                    var moonObject = Instantiate(moon.Moon.CelestialPrefab, randomOrbitPosition, Quaternion.identity);
                    
                    moonObject.transform.parent = planetObject.transform;
                    
                    if (moonObject.GetComponent<RotateAround>() != null)
                    {
                        moonObject.GetComponent<RotateAround>().TargetObject = planetObject;
                    }
                }
            }
        }
    }
    
    
    private static Vector3 GetRandomPositionOnOrbit(float tetha, float radius)
    {
        return new Vector3(Mathf.Cos(tetha * Mathf.Deg2Rad) * radius, 0, Mathf.Sin(tetha * Mathf.Deg2Rad) * radius);
    }

}
