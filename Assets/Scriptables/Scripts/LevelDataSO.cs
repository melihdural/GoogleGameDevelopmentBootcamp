using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "Level", menuName = "ScriptableObjects/Level Data/Level", order = 1)]
public class LevelDataSO : ScriptableObject
{
    
    public List<SunGroup> SunGroups;

    public GameObject _ghostPlanet;
    
    public ParticleSystem _explosionParticleSystem;
    

    [System.Serializable]
    public class PlanetData
    {
        public PlanetDataSO Planet;
        public List<MoonData> Moons;
    }

    [System.Serializable]
    public class MoonData
    {
        public MoonDataSO Moon;
    }

    [System.Serializable]
    public class CelestialData
    {
        public AsteroidsDataSO Asteroids;
    }

    [System.Serializable]
    public class SunGroup
    {
        //public GameObject CameraTarget;
        public SunDataSO Sun;
        public List<PlanetData> Planets;
        public List<CelestialData> CelestialDatas;
    }
}
