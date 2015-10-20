using UnityEngine;
using System.Collections;

public class SpawnGameObjectSkripta : MonoBehaviour {

	// Use this for initialization

	float min=15;
	float med=35;
	float max=45;

	//public float zamik=45;
	public float speed=5;

	
	float cas;
	RandomCreatorSkripta mapCreator;
	public GameObject prvi;
	//public GameObject zadnji;

	float prejsni;

    int nalozeniAvti = 0;
    int stAvtov = 12;
    float dolgaCesta = 175;

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
	
		GameObject zacasna;
		prvi = Instantiate(mapCreator.vrniRandomVozilo()) as GameObject;
		zacasna = prvi;
		
		zacasna.transform.rotation = transform.rotation;
		zacasna.transform.position = transform.position;
		zacasna.transform.SetParent(transform.parent);
		zacasna.GetComponent<SkriptaPotujNaprej>().speed = speed;
		zacasna.GetComponent<SkriptaPotujNaprej>().pozicija = zacasna.transform.localPosition;
		//zacasna.SetActive(false);
		for (int i=0; i < stAvtov; i++) {
			GameObject vozilo = Instantiate(mapCreator.vrniRandomVozilo()) as GameObject;
			
			vozilo.transform.rotation = transform.rotation;
			vozilo.transform.position = transform.position;
			vozilo.transform.SetParent(transform.parent);
			vozilo.GetComponent<SkriptaPotujNaprej>().speed = speed;
			vozilo.GetComponent<SkriptaPotujNaprej>().pozicija = vozilo.transform.localPosition;
			zacasna.GetComponent<SkriptaPotujNaprej>().nazaj = vozilo;
			zacasna = vozilo;

		}
		zacasna.GetComponent<SkriptaPotujNaprej> ().nazaj = prvi;

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
                zac.GetComponent<SkriptaPotujNaprej>().postaviSe(speed, dolgaCesta/speed);
                prvi = zac.GetComponent<SkriptaPotujNaprej>().nazaj;
                
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

			
			zac.transform.localPosition = zac.GetComponent<SkriptaPotujNaprej>().pozicija;
			zac.transform.position += transform.forward*vsota;
            zac.GetComponent<SkriptaPotujNaprej>().postaviSe(speed, dolgaCesta/speed - vsota/speed);
            prvi = zac.GetComponent<SkriptaPotujNaprej>().nazaj;
            cas = vrniZamik(prvi) / speed;

		}
        cas = minimalniZamik(prvi)/speed;
	}

	public float minimalniZamik(GameObject vozilo){
		float minzamik = prejsni + vozilo.GetComponent<SkriptaPotujNaprej> ().vrniZamikPrvi();
		prejsni = vozilo.GetComponent<SkriptaPotujNaprej>().vrniZamikZadnji();
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
