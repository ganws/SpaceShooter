﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        GetComponent<Slider>().value =  UIControl.GameVolume;
    }
}
