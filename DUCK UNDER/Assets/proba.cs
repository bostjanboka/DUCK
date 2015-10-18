using UnityEngine;
using System.Collections;

public class proba : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Physics.IgnoreLayerCollision(8,8, true);
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnTriggerEnter(Collider other) {
		if (other.CompareTag ("voda")) {
			//Debug.Log("dela kolider ampak nocem");
		}
	}
}
