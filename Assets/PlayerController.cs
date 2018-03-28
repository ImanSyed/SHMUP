using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	[SerializeField]
	float speed = 1;


	void Update () {
		Controls ();
	}

	void Controls (){
		Vector2 rotation;
		rotation.x = Input.GetAxis ("Vertical") * speed;
		rotation.y = -Input.GetAxis ("Horizontal") * speed;
		transform.Rotate (rotation);
	}
}
