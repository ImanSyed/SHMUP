using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternSpawner : MonoBehaviour {

	[SerializeField]
	GameObject enemy;

	void Start () {
		InvokeRepeating ("Pattern1", 1, 1);
	}

	void Pattern1 () {
		GameObject go = Instantiate (enemy, transform.position, Quaternion.identity);
		go.GetComponent<Rigidbody> ().AddForce (transform.forward * -2000);
	}
}
