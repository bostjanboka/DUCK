using UnityEngine;
using System.Collections;

public class SpawnRackeSkripta : MonoBehaviour {

	// Use this for initialization
	public GameObject osamljena;
	public float proc=20;

	Transform[] spawni;
	GameObject[] race;

	void Awake(){
		spawni = new Transform[4];
		race = new GameObject[4];
		Transform rot = transform.FindChild ("rot");
		spawni[0] = rot.FindChild ("SPAWN 1");
		spawni[1] = rot.FindChild ("SPAWN 2");
		spawni[2] = rot.FindChild ("SPAWN 3");
		spawni[3] = rot.FindChild ("SPAWN 4");
		naredi ();
	}
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void naredi(){
		for (int i=0; i < 4; i++) {
			race[i] = Instantiate(osamljena,spawni[i].position,spawni[i].rotation) as GameObject;
			race[i].transform.SetParent(transform);
			race[i].SetActive(false);
		}
	}

	public void pocisti(){
		for (int i=0; i < 4; i++) {
			race[i].gameObject.SetActive(false);
		}
	}

	public void postavi(){
		for (int i=0; i < 4; i++) {
			if(Random.Range(0,100) < proc){
				race[i].gameObject.SetActive(true);
			}
		}
	}
}
