using UnityEngine;
using System.Collections;

public class vOrkanuSkripta : MonoBehaviour {

	// Use this for initialization
	public float kot;
	public float speed;
	public float trajanje = 7;
	public bool enable=true;

	Vector3 smer = Vector3.up;

	public void StartOrkan (Vector3 pos, Quaternion rot, GameObject stars) {

			//transform.Rotate (kot, 0, 0);
		smer = Quaternion.Euler(kot,0,0)*smer;
		
		enable = false;
		transform.position = pos;
		transform.rotation = rot;
		transform.SetParent (stars.transform);
		trajanje = 10;

	}
	
	// Update is called once per frame
	void Update () {
		trajanje -= Time.deltaTime;
		if (trajanje < 6 && !enable) {
			sirota();
		}
		if (transform.position.y > 25) {
			orkanSkripta.zadnji.GetComponent<nazajSkripta>().nazaj = gameObject;
			orkanSkripta.zadnji = gameObject;
			gameObject.SetActive(false);
		}
		if (enable) {
			transform.position += smer * speed * Time.deltaTime;
		}
	}

	void sirota(){
		//Debug.Log ("sirota");
		transform.parent = orkanSkripta.parent;
		enable = true;
		speed = Random.Range (1.0f, 3.1f);
	}


}
