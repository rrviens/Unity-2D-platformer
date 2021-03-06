﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSlider : MonoBehaviour {

    private AudioSource audioSrc;
    public float musicVolume = 0.1f;

	void Start () {
        audioSrc = GetComponent<AudioSource>();
	}

	void Update () {
        audioSrc.volume = musicVolume;
	}

    public void SetVolume(float vol)
    {
        musicVolume = vol;
    }

	public void SaveSliderValue()
 {
     PlayerPrefs.SetFloat("SliderVolumeLevel", musicVolume);
 }

}