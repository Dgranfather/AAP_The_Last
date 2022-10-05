using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public Text maxHealthValue;
    public Text currentHealthValue;

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetValue(int health)
    {
        slider.value = health;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    public void SetMaxHealthText(int value)
    {
        maxHealthValue.text = value.ToString();
    }

    public void SetCurrentHealthText(int value)
    {
        currentHealthValue.text = value.ToString();
    }
}
