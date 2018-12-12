using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

	public GameObject PauseUI;

	private bool paused = false;

	void Start(){
		PauseUI.SetActive(false); 									// Neveikia by default
	}

	void Update(){
	if(Input.GetButtonDown("Pause")){
			paused = !paused; 										//pauzės toggle
		}

	if(paused){
		PauseUI.SetActive(true);
		Time.timeScale = 0; 										// sustabdomas judėsys
	}

	if(!paused){
		PauseUI.SetActive(false); 									// pratęsiamas judėsys
		Time.timeScale = 1;
	}
}

// MYGTUKŲ REIKŠMĖS
public void Resume(){
	paused = false; 												//išjugnia pauzę 
}

 public void Restart(){
 	Application.LoadLevel(Application.loadedLevel); 				// loadina dabartinį levelį
}

public void MainMenu(){
	Application.LoadLevel(0); 										//pirmojo indekso sceną, aka Main Menu, arba kas nors kito
}

public void Quit(){
	Application.Quit(); 											//išjungia 
}

}
