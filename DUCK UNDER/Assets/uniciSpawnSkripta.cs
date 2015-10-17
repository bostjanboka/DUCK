using UnityEngine;
using System.Collections;

public class uniciSpawnSkripta : MonoBehaviour {

	void Awake(){
		

	}
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerExit(Collider other) {
		if (other.gameObject.CompareTag ("vozilo")) {
			Debug.Log("unici");
            //other.gameObject.SetActive(false);
            other.gameObject.GetComponent<SkriptaPotujNaprej>().setActiveObject(false);
		}
	}
}
