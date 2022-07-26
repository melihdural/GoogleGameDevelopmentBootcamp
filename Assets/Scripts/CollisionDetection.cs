using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CollisionDetection : MonoBehaviour
{
        private void OnTriggerEnter(Collider other)
        {
                //If the Meteor hits the planet
                if (other.gameObject.CompareTag("Planet"))
                {
                       //Start the explosion particles
                        gameObject.GetComponent<ParticleSystem>().Play();
                        
                        //Destroy the meteor Trail
                        gameObject.GetComponent<TrailRenderer>().enabled = false;
                        
                        //Destroy the meteor after the explosion particles have finished
                        StartCoroutine(DestroyMeteor(10f));
                }
        }
        
        IEnumerator DestroyMeteor(float delay)
        {
                yield return new WaitForSeconds(delay);
                Destroy(this.gameObject);
        }
}
