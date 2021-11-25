using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GradientHealth : Attributes
{
    public Gradient gradient;
    public Canvas enemyhealthDisplay;
    Transform cam;

    public virtual void Start()
    {
        cam = Camera.main.transform;
    }
    public virtual void Update()
    {
        SetHealth();
        enemyhealthDisplay.transform.LookAt(enemyhealthDisplay.transform.position + cam.forward);
    }
    public void SetHealth()
    {
        attributes[0].displayImage.fillAmount = Mathf.Clamp01(attributes[0].currentValue / attributes[0].maxValue);
        attributes[0].displayImage.color = gradient.Evaluate(attributes[0].displayImage.fillAmount);
    }
}
