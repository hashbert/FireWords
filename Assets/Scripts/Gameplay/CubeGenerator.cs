using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class CubeGenerator : MonoBehaviour
{
    [SerializeField] private InputActionReference _addCube;
    [SerializeField] private GameObject _cubePrefab;
    private Camera cam;
    private void OnEnable()
    {
        _addCube.action.started += CreateCube;
    }
    void Start()
    {
        cam = Camera.main;
    }
    private void OnDisable()
    {
        _addCube.action.started -= CreateCube;
    }

    private void CreateCube(InputAction.CallbackContext obj)
    {
        if (obj.started)
        {
            Vector2 mousePosition = Mouse.current.position.ReadValue();
            Vector3 mousePos = new Vector3(mousePosition.x, mousePosition.y, 5.0f);
            Vector3 objectPos = cam.ScreenToWorldPoint(mousePos);
            Instantiate(_cubePrefab, objectPos, Quaternion.identity);
        }
    }
}
