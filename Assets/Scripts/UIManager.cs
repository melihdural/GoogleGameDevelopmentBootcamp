using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _uiPlaceholder;
    [SerializeField] private GameObject _planetName;
    [SerializeField] private GameObject _closeButton;
    
    private void Awake()
    {
        InputManager.OnCelestialSelected += OnCelestialSelected;
    }
    
    private void OnDestroy()
    {
        InputManager.OnCelestialSelected -= OnCelestialSelected;
    }
    
    private void OnCelestialSelected()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out var hit))
        {
            if (hit.transform == null)
                return;

            _uiPlaceholder.SetActive(true);
            _planetName.GetComponent<TextMeshProUGUI>().text = hit.transform.name;

            _closeButton.GetComponent<Button>().onClick.AddListener(() =>
            {
                _uiPlaceholder.SetActive(false);
            });
        }
    }
}
