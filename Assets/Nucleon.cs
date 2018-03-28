using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Nucleon : MonoBehaviour {

	public float attractionForce;

	Rigidbody body;

	public bool followPlayer;

	MeshRenderer mr;

	void Awake() {
		body = GetComponent<Rigidbody> ();
		mr = GetComponent<MeshRenderer> ();
	}
	
	void FixedUpdate () {
		body.AddForce (transform.localPosition * -attractionForce);
		mr.material.color = Random.ColorHSV (0, 1, 0.75f, 1);
	}

	public IEnumerator FollowPlayer(float delay){
		yield return new WaitForSeconds (delay);
		Transform pc = GameObject.FindGameObjectWithTag ("Player").transform;
		Vector3 dir = pc.position - transform.position;
		body.AddForce (dir * 100);
		if (followPlayer) {
			StartCoroutine(FollowPlayer(0.1f));
		}
	}
}
