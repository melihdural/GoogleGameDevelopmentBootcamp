using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour
{
    public static event Action<DataHandler> SpawnMeteor;
    public static event Action OnCelestialSelected; 
    private void Update()
    {
        KeyCodeSpace();
        OnMouseLeftButtonDown();
    }
    
    private void KeyCodeSpace()
    {
        var IsPressing = Input.GetKeyDown(KeyCode.Space);
        if (!IsPressing) 
            return;
        
        SpawnMeteor?.Invoke(GetComponent<DataHandler>());
    }
    
    private void OnMouseLeftButtonDown()
    {
        var isPressing = Input.GetMouseButtonDown(0);
        if (!isPressing)
            return;
        
        OnCelestialSelected?.Invoke();
    }
    
}
