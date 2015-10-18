using UnityEngine;
using System.Collections;

public class uniciColnSkripta : MonoBehaviour {

	// Use this for initialization
	spawnColnSkripta spawn;
	
	void Awake(){
		spawnColnSkripta[] zac = transform.parent.parent.GetComponentsInChildren<spawnColnSkripta> ();
		if (zac [0].enabled) {
			spawn = zac [0];
		} else {
			spawn = zac[1];
		}
	}
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter(Collider other) {
		if (other.CompareTag ("coln")) {
			//Debug.Log("unici");
			spawn.zadnji.GetComponent<SkriptaPotujNaprej>().nazaj = other.gameObject;
			other.gameObject.SetActive(false);
			spawn.zadnji = other.gameObject;
		}
	}
}
