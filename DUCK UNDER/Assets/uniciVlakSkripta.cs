using UnityEngine;
using System.Collections;

public class uniciVlakSkripta : MonoBehaviour {

	// Use this for initialization
	spawnVlakSkripta spawn;
	
	void Awake(){
		spawnVlakSkripta[] zac = transform.parent.parent.GetComponentsInChildren<spawnVlakSkripta> ();
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
		if (other.CompareTag ("vozilo")) {
			Debug.Log("unici");
			spawn.zadnji.GetComponent<SkriptaPotujNaprej>().nazaj = other.gameObject;
			other.gameObject.SetActive(false);
			spawn.zadnji = other.gameObject;
		}
	}
}
