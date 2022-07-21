using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ScriptableObjectArchitecture;

public class HealthBar : MonoBehaviour
{

    [SerializeField]
    private FloatReference currentHealth = null;
    [SerializeField]
    private FloatReference maxHealth = null;
    [SerializeField] private Image _image;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void UpdateHealth()
    {
        _image.fillAmount = currentHealth.Value / maxHealth.Value;
    }
}
