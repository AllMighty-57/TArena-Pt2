using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioSettngs : MonoBehaviour
{
    public string _volumeParameter = "MasterVolume";
    public AudioMixer _mixer;
    public Slider _slider;
    public float _multipler = 30f;
    public Toggle _muteToggle;
    private bool _disableToggleEvent;
    private float setVolSave;

    private void Awake()
    {
        _slider.onValueChanged.AddListener(SliderValueChanged);
        _muteToggle.onValueChanged.AddListener(ToggleValueChanged);
    }

    private void ToggleValueChanged(bool enableSound)
    {
        if (_disableToggleEvent)
            return;

        if(_slider.value > _slider.minValue) 
            setVolSave = _slider.value;

        if (enableSound) 
            _slider.value = setVolSave;
        else
            _slider.value = _slider.minValue;
    }
    private void OnDisable()
    {
        PlayerPrefs.SetFloat(_volumeParameter, _slider.value);
    }

    private void SliderValueChanged(float value)
    {
        _mixer.SetFloat(_volumeParameter, Mathf.Log10(value) * _multipler);
        _disableToggleEvent = true;
        _muteToggle.isOn = _slider.value > _slider.minValue;
        _disableToggleEvent = false;
    }

    private void Start()
    {
        _slider.value = PlayerPrefs.GetFloat(_volumeParameter, _slider.value);
    }
}
