using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;
using UnityEngine.InputSystem;
using System;

public class Cube : MonoBehaviour
{
    [SerializeField] private GameObjectCollection collection;
    [SerializeField] private InputActionReference _deleteCube;
    public static event Action OnCubeChanged;

    private void OnEnable()
    {
        collection.Add(gameObject);
        _deleteCube.action.started += DeleteCube;
        OnCubeChanged?.Invoke();
    }
    private void DeleteCube(InputAction.CallbackContext obj)
    {
        if (obj.started) 
        { 
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue()), out RaycastHit hit))
            {
                Destroy(hit.collider.gameObject);
            }
        }
    }
    private void OnDisable()
    {
        collection.Remove(gameObject);
        _deleteCube.action.started -= DeleteCube;
        OnCubeChanged?.Invoke();
    }
}
