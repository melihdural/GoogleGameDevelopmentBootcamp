using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ClickableObjects : MonoBehaviour
{
   public static ClickableObjects instance;
   private bool isClicked = false;

   public bool IsClicked
   {
      get => isClicked;
      set => isClicked = value;
   }

   private void Start()
   {
      //Instance
      instance = this;
   }
   
   private void Update()
   {
      //If the player clicks
      if (Input.GetMouseButtonDown(0))
      {
         //Get the mouse position
         RaycastHit hit;
         
         //Raycast from the camera to the mouse position
         Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
         
         if (Physics.Raycast(ray, out hit, 100.0f))
         {
            //Check the ray hits the object
            if (hit.transform != null)
            {
               //If the player clicks on the planet object, set the isClicked variable to true
               isClicked = true;
               
               //Set the main camera's isMoving variable to false, for stopping the camera movement
               CameraController.instance.IsMoving = false;
               
               //Set the UI text to the planet's name
               UIManager.instance.PlanetNameText = hit.transform.gameObject.name;
               
               //Write the planet's name to the console
               Debug.Log(hit.transform.gameObject.name);
            }
         }
      }
   }
}
