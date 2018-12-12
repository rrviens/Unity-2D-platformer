using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextLevel : MonoBehaviour {

public int LevelToLoad;
private CounterGame cg;

	void Start(){
		cg = GameObject.FindGameObjectWithTag("CounterGame").GetComponent<CounterGame>();
	}


	void OnTriggerEnter2D(Collider2D col){
		if(col.CompareTag("Player")){
			cg.InputNext.text = ("E to Enter");
			if(Input.GetKeyDown("e")){

				saveScore();
				Application.LoadLevel(LevelToLoad);
			}
		}
	}

	void OnTriggerStay2D(Collider2D col){
		if(col.CompareTag("Player")){
			if(Input.GetKeyDown("e")){
				saveScore();
				Application.LoadLevel(LevelToLoad);
			}
			
		}
	}

	void OnTriggerExit2D(Collider2D col){
		if(col.CompareTag("Player")){
		cg.InputNext.text = (" ");
		}

	}

	void saveScore(){
		PlayerPrefs.SetInt("score", cg.points);
	}


}
