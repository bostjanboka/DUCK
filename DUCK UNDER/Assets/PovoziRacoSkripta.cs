using UnityEngine;
using System.Collections;

public class PovoziRacoSkripta : MonoBehaviour {

	// Use this for initialization
	RackaSkripta skripta;
	void Start () {
		skripta = transform.parent.GetComponent<RackaSkripta> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if (other.CompareTag ("kolo")) {
			skripta.povoziRaco ();
		}
	}
}
