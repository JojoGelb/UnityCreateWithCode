using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeChanger : MonoBehaviour
{
    private Slider slider;
    public AudioSource music;

    private void Start()
    {
        slider = GetComponent<Slider>();
        slider.value = music.volume;
    }

    public void ValueChangeCheck()
    {
        music.volume = slider.value;
    }
}
