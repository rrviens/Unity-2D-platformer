using System.Collections;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	private Vector2 velocity;

	public float smoothY;
	public float smoothX;

	public GameObject player;

	public bool bounds;

	public Vector3 minCameraPosition;
	public Vector3 maxCameraPosition;

	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
	}


	void FixedUpdate(){

		float positionX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref velocity.x, smoothX); 			//x pozicija kameros //KAMEROS SEKIMAS
		float positionY = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref velocity.y, smoothY); 			//y pozicija kameros

		transform.position = new Vector3(positionX, positionY, transform.position.z); 												// kameros judėsys

		if(bounds){ 																												// configurable Unity kameros restrictionai
			transform.position = new Vector3(Mathf.Clamp(transform.position.x, minCameraPosition.x, maxCameraPosition.x), 
			Mathf.Clamp(transform.position.y, minCameraPosition.y, maxCameraPosition.y),
			Mathf.Clamp(transform.position.z, minCameraPosition.z, maxCameraPosition.z));
		}
	}
}
