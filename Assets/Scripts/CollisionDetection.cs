using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Object = UnityEngine.Object;

public class CollisionDetection : MonoBehaviour
{
        private DataHandler _dataHandler;
        public ParticleSystem _explosionParticles;
        private float _meteorLifeTime = 30f;

        
        private void Start()
        {
                StartCoroutine(DestroyMeteorWithoutCollision(_meteorLifeTime));
        }

        private void OnTriggerEnter(Collider other)
        {
                //If the Meteor hits the planet
                if (other.gameObject.CompareTag("Planet"))
                {
                        this.gameObject.SetActive(false);
                        
                        //Start the explosion particles
                        Instantiate(_explosionParticles, other.transform.position, Quaternion.identity);
                        
                        //Destroy the meteor Trail
                        gameObject.GetComponent<TrailRenderer>().enabled = false;
                        
                        //Destroy the meteor after the explosion particles have finished
                        Destroy(this.gameObject);
                }
        }
        
        
        IEnumerator DestroyMeteorWithoutCollision(float meteorLifeTime)
        {
                yield return new WaitForSeconds(meteorLifeTime);
                
                //Destroy the meteor Trail
                gameObject.GetComponent<TrailRenderer>().enabled = false;

                //Destroy the meteor
                Destroy(this.gameObject);
        }

}
