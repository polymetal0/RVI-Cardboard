using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode()]
public class Progressbar : MonoBehaviour
{
    public float max;
    public float current;
    public Image mask;

    void Update()
    {
        GetCurrentFill();
    }

    private void GetCurrentFill()
    {
        float fillAmount = current / max;
        mask.fillAmount = fillAmount;
    }
}
