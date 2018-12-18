using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighscoreGet : MonoBehaviour {


public InputField InputField;

void Start(){
	//InputField.onValueChange.AddListener(delegate {ValueChangeCheck(); });
	}

 
 void Update() {
     if(InputField.isFocused && InputField.text != "" && Input.GetKey(KeyCode.Return)) {
     name = GUILayout.TextField(InputField.text);
     }
}

  public void ValueChangeCheck()
     {
        Debug.Log("Value Changed");
     }
}