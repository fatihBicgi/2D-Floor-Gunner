using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingHealthBar : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] GameObject fillGameObject;
    Image image;

    [SerializeField] Gradient _healthBarGradient;

    private void Start()
    {
        image = fillGameObject.GetComponent<Image>();
    }

    public void UpdateHealthBar (float currentValue, float maxValue)
    {
        slider.value = currentValue / maxValue;
    }

    void Update()
    {
       image.color = _healthBarGradient.Evaluate(slider.value);


    }
}
