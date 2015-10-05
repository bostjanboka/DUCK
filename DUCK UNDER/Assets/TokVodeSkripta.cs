using UnityEngine;
using System.Collections;

public class TokVodeSkripta : MonoBehaviour {

	// Use this for initialization
	public float silaToka = 3;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay(Collider other) {
		/*if (other.tag.Equals ("raca") || other.tag.Equals("tocka") || other.tag.Equals("osamljena")) {
			other.gameObject.transform.position += transform.forward * silaToka * Time.deltaTime;
		}*/
	}
}
