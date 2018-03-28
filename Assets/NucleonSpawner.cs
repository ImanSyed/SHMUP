using System.Collections;
using UnityEngine;

public class NucleonSpawner : MonoBehaviour {

	public float timeBetweenSpawns;

	public float spawnDistance;

	public Nucleon[] nucleonPrefabs;

	float timeSinceLastSpawn;

	int counter, nucCounter;

	public int spawnLimit = 30;

	bool explode;

	Nucleon[] nucs;


	void FixedUpdate(){
		if (counter < spawnLimit) {
			timeSinceLastSpawn += Time.deltaTime;
			if (timeSinceLastSpawn >= timeBetweenSpawns) {
				timeSinceLastSpawn -= timeBetweenSpawns;
				SpawnNucleon ();
				counter++;
			}
		} else if(counter >= spawnLimit == !explode) {
			explode = true;
			nucs = FindObjectsOfType<Nucleon> ();

			StartCoroutine (ExplodeOneByOne ());
		}
	}

	IEnumerator ExplodeTogether(){
		yield return new WaitForSeconds (0.1f);
		foreach (Nucleon n in nucs) {
			n.attractionForce = -10f;
		}
	}

	IEnumerator ExplodeOneByOne(){
		yield return new WaitForSeconds (0.1f);
		nucs [nucCounter].attractionForce = -10;
		nucs [nucCounter].followPlayer = true;

		StartCoroutine(nucs [nucCounter].FollowPlayer (0.1f));
		if (nucs [nucCounter] != null) {
			StartCoroutine (DestroyNucleon (nucs [nucCounter].gameObject));
		}
		if (nucCounter < nucs .Length - 1 ){
			nucCounter++;
		}
		StartCoroutine (ExplodeOneByOne ());
	}

	IEnumerator DestroyNucleon(GameObject obj){
		yield return new WaitForSeconds (3f);
		Destroy (obj);
	}

	void SpawnNucleon(){
		Nucleon prefab = nucleonPrefabs [Random.Range (0, nucleonPrefabs.Length)];
		Nucleon spawn = Instantiate<Nucleon> (prefab);
		spawn.transform.localPosition = Random.onUnitSphere * spawnDistance;
	}


}
