using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    
    [SerializeField] private GameObject _uiPlaceholder;
    [SerializeField] private GameObject _planetName;
    [SerializeField] private GameObject _closeButton;
    
    private string planetNameText;

    public string PlanetNameText
    {
        get => planetNameText;
        set => planetNameText = value;
    }

    private void Start()
    {
        //Instance
        instance = this;
    }
    private void Update()
    {
        //Type the planet name
        if (ClickableObjects.instance.IsClicked) 
        { 
            TypePlanetNameText(planetNameText);
        }
        
        //If the player clicks on close button,
        if (!_closeButton.GetComponent<Toggle>().isOn)
        {
            ClosePlaceholder();
            
            //Set the clicked planets boolean to false
            ClickableObjects.instance.IsClicked = false;
            
            //Set the camera movable when the UI is closed
            CameraController.instance.IsMoving = true;
        }
    }
    
    private void TypePlanetNameText(string text)
    {
        //Open the UI placeholder
        _uiPlaceholder.SetActive(true);
        
        //Set the text of the placeholder as the planet name which is clicked on the scene
        _planetName.GetComponent<TMP_Text>().text = text;
    }
    
    public void ClosePlaceholder() 
    {
        //Close the UI placeholder
        _uiPlaceholder.SetActive(false);
        
        //Set the close button UI toggle to true
        _closeButton.GetComponent<Toggle>().isOn = true;
    }
}
