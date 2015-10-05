using UnityEngine;
using System.Collections;

public class spawnColnSkripta : MonoBehaviour {

	// Use this for initialization
	public float min=50;
	public float med=70;
	public float max=90;

	public GameObject objekt;
	
	//public float zamik=70;
	public float speed=5;
	Collider terminator;
	float cas;
	

	GameObject prvi;
	public GameObject zadnji;
	
	void Awake(){


	}
	
	void Start () {
		//transform.position += transform.forward * Random.Range (-zamik/2, zamik/2);
		terminator = transform.FindChild ("terminator").GetComponent<Collider> ();
		GameObject zacasna;
		prvi = Instantiate(objekt) as GameObject;
		zacasna = prvi;
		Physics.IgnoreCollision(zacasna.GetComponent<Collider>(), terminator);
		zacasna.transform.rotation = transform.rotation;
		zacasna.transform.position = transform.position;
		zacasna.transform.SetParent(transform.parent);
		zacasna.GetComponent<SkriptaPotujNaprej>().speed = speed;
		zacasna.GetComponent<SkriptaPotujNaprej>().pozicija = zacasna.transform.localPosition;
		zacasna.SetActive(false);
		
		for (int i=0; i < 6; i++) {
			GameObject vozilo = Instantiate(objekt) as GameObject;
			Physics.IgnoreCollision(vozilo.GetComponent<Collider>(), terminator);
			vozilo.transform.rotation = transform.rotation;
			vozilo.transform.position = transform.position;
			vozilo.transform.SetParent(transform.parent);
			vozilo.GetComponent<SkriptaPotujNaprej>().speed = speed;
			vozilo.GetComponent<SkriptaPotujNaprej>().pozicija = vozilo.transform.localPosition;
			zacasna.GetComponent<SkriptaPotujNaprej>().nazaj = vozilo;
			zacasna = vozilo;
			zadnji = zacasna;
			zacasna.SetActive(false);
		}
		
		postaviVozila ();
		cas = vrniZamik() / speed;
		RandomCreatorSkripta.nalozeno++;
		transform.parent.gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		cas -= Time.deltaTime;
		if (cas <= 0) {
			GameObject zac = prvi;


			zac.transform.localPosition = zac.GetComponent<SkriptaPotujNaprej>().pozicija;
			prvi = zac.GetComponent<SkriptaPotujNaprej>().nazaj;
			
			zac.GetComponent<SkriptaPotujNaprej>().nazaj=null;
			zac.SetActive(true);
			Physics.IgnoreCollision(zac.GetComponent<Collider>(), terminator);
			cas = vrniZamik() / speed;
		}
		
		
	}
	
	public void postaviVozila(){
		float vsota = 0;
		for (int i=0; i < 3; i++) {
			vsota = i * vrniZamik();
			GameObject zac = prvi;


			zac.transform.localPosition = zac.GetComponent<SkriptaPotujNaprej>().pozicija;
			zac.transform.position += transform.forward*vsota;
			
			prvi = zac.GetComponent<SkriptaPotujNaprej>().nazaj;
			zac.SetActive(true);
			Physics.IgnoreCollision(zac.GetComponent<Collider>(), terminator);
			zac.GetComponent<SkriptaPotujNaprej>().nazaj=null;
			
			
		}
	}

	public float vrniZamik(){
		if (Random.Range (0, 100) <= 60) {
			return med;
		} else if (Random.Range (0, 2) == 0) {
			return min;
		} else {
			return max;
		}
		
	}
}
