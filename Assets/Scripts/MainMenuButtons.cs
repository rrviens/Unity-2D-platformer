using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuButtons : MonoBehaviour {

	public GameObject MainMenu;
	private AudioSource audioSrc;

	private bool mainMenu = true;
	public float musicVolume = 0.5f;

	void Start () {
		MainMenu.SetActive(true);
		audioSrc = GetComponent<AudioSource>();
		audioSrc.volume = PlayerPrefs.GetFloat("SliderVolumeLevel", audioSrc.volume);
	}

	public void Button(){
		Application.LoadLevel(1);
		SaveSliderValue();
	}

	public void ExitMain(){
		Application.Quit();
	}

	public void SelectLevels(){
		Application.LoadLevel(5);
	}

	public void Back(){
		Application.LoadLevel(4);
	}
	public void leveltwo(){
		Application.LoadLevel(2);
	}
	public void levelthree(){
		Application.LoadLevel(3);
	}

	public void SaveSliderValue()
 {
     PlayerPrefs.SetFloat("SliderVolumeLevel", musicVolume);
 }
}
