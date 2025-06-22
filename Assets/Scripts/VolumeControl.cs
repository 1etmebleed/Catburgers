using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    public string volumeParametr = "MasterVolume";
    public AudioMixer mixer;
    public Slider slider;

    public AudioMixerGroup mixerGroup;

    private const float _multiplier = 20f;

    private void Awake()
    {
        slider.minValue = 0.0001f;
        slider.maxValue = 1f;

        slider.onValueChanged.AddListener(HandleSliderValueChanged);
    }
    private void HandleSliderValueChanged(float value)
    {
        var volumeValue = Mathf.Log10(value) * _multiplier;
        mixer.SetFloat(volumeParametr, volumeValue);

        if(volumeValue == 0)
        {
            volumeValue = 0.00001f;
        }
    }
    public void SaveChanged()
    {

    }

}
