using UnityEngine;
using System.Collections;

public class SpawnGameObjectSkripta : MonoBehaviour {

	// Use this for initialization

	float min=15;
	float med=35;
	float max=45;

	//public float zamik=45;
	public float speed=5;

	Collider terminator;
	float cas;
	RandomCreatorSkripta mapCreator;
	public GameObject prvi;
	//public GameObject zadnji;

	float prejsni;

    int nalozeniAvti = 0;
    int stAvtov = 12;

    nazajSkripta nazajSkrip;

	void Awake(){
		prejsni = 0;
        stAvtov = transform.parent.gameObject.GetComponent<izberiSpawnSkripta>().stAvtov;
        nazajSkrip = transform.parent.gameObject.GetComponent<nazajSkripta>();
	}


	void Start () {
		Transform mc = transform.parent;
		while (mc.parent != null) {
			mc = mc.parent;
		}
		mapCreator = mc.gameObject.GetComponent<RandomCreatorSkripta>();
		//transform.position += transform.forward * Random.Range (-zamik/2, zamik/2);
		terminator = transform.FindChild ("terminator").GetComponent<Collider> ();
		GameObject zacasna;
		prvi = Instantiate(mapCreator.vrniRandomVozilo()) as GameObject;
		zacasna = prvi;
		Physics.IgnoreCollision(zacasna.GetComponent<Collider>(), terminator);
		zacasna.transform.rotation = transform.rotation;
		zacasna.transform.position = transform.position;
		zacasna.transform.SetParent(transform.parent);
		zacasna.GetComponent<SkriptaPotujNaprej>().speed = speed;
		zacasna.GetComponent<SkriptaPotujNaprej>().pozicija = zacasna.transform.localPosition;
		//zacasna.SetActive(false);
		for (int i=0; i < stAvtov; i++) {
			GameObject vozilo = Instantiate(mapCreator.vrniRandomVozilo()) as GameObject;
			Physics.IgnoreCollision(vozilo.GetComponent<Collider>(), terminator);
			vozilo.transform.rotation = transform.rotation;
			vozilo.transform.position = transform.position;
			vozilo.transform.SetParent(transform.parent);
			vozilo.GetComponent<SkriptaPotujNaprej>().speed = speed;
			vozilo.GetComponent<SkriptaPotujNaprej>().pozicija = vozilo.transform.localPosition;
			zacasna.GetComponent<SkriptaPotujNaprej>().nazaj = vozilo;
			zacasna = vozilo;
			//zadnji = zacasna;
			//zacasna.SetActive(false);
		}
		zacasna.GetComponent<SkriptaPotujNaprej> ().nazaj = prvi;
		//postaviVozila ();
		//cas = vrniZamik(prvi) / speed;
		//cas = 4;
		
		//Debug.Log ("set active");
	}
	
	// Update is called once per frame
	void Update () {
        if (nazajSkrip.jeAktivna)
        {
            cas -= Time.deltaTime;
            if (cas <= 0 && prvi.GetComponent<SkriptaPotujNaprej>().nazaj)
            {
                GameObject zac = prvi;

                zac.transform.localPosition = zac.GetComponent<SkriptaPotujNaprej>().pozicija;
                zac.GetComponent<SkriptaPotujNaprej>().speed = speed;
                prvi = zac.GetComponent<SkriptaPotujNaprej>().nazaj;
                //zac.SetActive(true);
                zac.GetComponent<SkriptaPotujNaprej>().setActiveObject(true);
                Physics.IgnoreCollision(zac.GetComponent<Collider>(), terminator);
                //zac.GetComponent<SkriptaPotujNaprej>().nazaj=null;
                cas = vrniZamik(prvi) / speed;
            }
        }
	}

	public void pospraviVse(int st,GameObject x){
		//x.SetActive (false);
        x.GetComponent<SkriptaPotujNaprej>().setActiveObject(false);
        if (st > 0) {
			pospraviVse (st-1,x.GetComponent<SkriptaPotujNaprej> ().nazaj);
		}
	}

	public void postaviVozila(){
		float vsota = 0;
        
		for (int i=0; i < 3; i++) {
			GameObject zac = prvi;
			vsota += vrniZamik(zac);

			zac.GetComponent<SkriptaPotujNaprej>().speed=speed;
			zac.transform.localPosition = zac.GetComponent<SkriptaPotujNaprej>().pozicija;
			zac.transform.position += transform.forward*vsota;
            
            prvi = zac.GetComponent<SkriptaPotujNaprej>().nazaj;
            zac.GetComponent<SkriptaPotujNaprej>().setActiveObject(true);
            Physics.IgnoreCollision(zac.GetComponent<Collider>(), terminator);
            
            //zac.GetComponent<SkriptaPotujNaprej>().nazaj=null;
            cas = vrniZamik(prvi) / speed;

		}
	}

	public float minimalniZamik(GameObject vozilo){
		float minzamik = prejsni + vozilo.GetComponent<SkriptaPotujNaprej> ().vrniZamikPrvi();
		prejsni = vozilo.GetComponent<SkriptaPotujNaprej>().vrniZamikZadnji();
		//Debug.Log ("prvi" + vozilo.GetComponent<SkriptaPotujNaprej> ().vrniZamikPrvi()+ " --- " +minzamik * 175 + " zamik "+minzamik);
		return minzamik * 175*vozilo.transform.localScale.z;

	}

	public float vrniZamik(GameObject zac){
		if (Random.Range (0, 100) <= 60) {
			return med+minimalniZamik(zac);
		} else if (Random.Range (0, 2) == 0) {
			return min+minimalniZamik(zac);
		} else {
			return max+minimalniZamik(zac);
		}

	}
}
