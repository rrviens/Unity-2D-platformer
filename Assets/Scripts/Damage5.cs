using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage5 : MonoBehaviour {

	private Player player;

	void Start(){
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
	}

	void OnTriggerEnter2D(Collider2D col){

		if(col.CompareTag("Player"))
		{
			player.Damage(5);
			StartCoroutine(player.Knockback(0.02f, 350, player.transform.position));
		}
	}
}
