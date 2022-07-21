using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using ScriptableObjectArchitecture;

public class CounterText : MonoBehaviour
{
    [SerializeField] private TMP_Text _counterText;
    [SerializeField] private GameObjectCollection collection;
    // Start is called before the first frame update
    private void OnEnable()
    {
        Cube.OnCubeChanged += UpdateText;
    }
    private void OnDisable()
    {
        Cube.OnCubeChanged -= UpdateText;
    }
    void Start()
    {
        UpdateText();
    }
    public void UpdateText()
    {
        _counterText.text = "There are " + collection.Count + " cubes left.";
    }
}
