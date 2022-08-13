using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityProject1.Managers;
using UnityProject1.Movements;
 using UnityEngine.UI;


namespace UnityProject1.UI
{
public class FuelSlider : MonoBehaviour
{
    Slider _slider;
    Fuel _fuel;
    
    private void Awake() {
        _slider = GetComponent<Slider>();
        _fuel = FindObjectOfType<Fuel>();
    }
    private void Update() {
        _slider.value = _fuel.CurrentFuel;
    }
}
}