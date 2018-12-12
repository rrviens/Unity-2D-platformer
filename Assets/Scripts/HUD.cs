using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;							 										// library leidžia accessint elementus esančius Unity programoj

public class HUD : MonoBehaviour {

	public Sprite[] HeartSprites;
	public Image HealthUI;

	private Player player;

void Start(){

	player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

}

void Update(){

	if(player.currentHealth > player.maxHealth){
		player.currentHealth = player.maxHealth;
	}

	if(player.currentHealth <= 0){
		player.currentHealth = 0;
	}

	HealthUI.sprite = HeartSprites[player.currentHealth];

}


}

