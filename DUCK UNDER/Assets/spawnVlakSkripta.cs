﻿using UnityEngine;
using System.Collections;

public class spawnVlakSkripta : MonoBehaviour {

	// Use this for initialization
	public float min=3;
	public float max=12;
	public GameObject objekt;
	

	public float speed=5;
    float dolgaCesta = 380;
	float cas;
	
	
	GameObject prvi;
    RandomCreatorSkripta mapCreator;
	public GameObject zadnji;
    int nalozeniAvti = 0;
    int stAvtov = 12;
    nazajSkripta nazajSkrip;
    void Awake(){
        
        stAvtov = transform.parent.gameObject.GetComponent<izberiSpawnSkripta>().stAvtov;
        //transform.position += transform.forward * Random.Range (-zamik/2, zamik/2);
        nazajSkrip = transform.parent.gameObject.GetComponent<nazajSkripta>();

    }
	
	void Start () {
        mapCreator = GameObject.Find("MapCreator").GetComponent<RandomCreatorSkripta>();
		
		GameObject zacasna;
		prvi = Instantiate(mapCreator.getRandomVlak()) as GameObject;
		zacasna = prvi;
		
		zacasna.transform.rotation = transform.rotation;
		zacasna.transform.position = transform.position;
		zacasna.transform.SetParent(transform.parent);
		zacasna.GetComponent<SkriptaPotujNaprej>().speed = speed;
		zacasna.GetComponent<SkriptaPotujNaprej>().pozicija = zacasna.transform.localPosition;
		//zacasna.SetActive(false);
		
		for (int i=1; i < stAvtov; i++) {
			GameObject vozilo = Instantiate(mapCreator.getRandomVlak()) as GameObject;
			
			vozilo.transform.rotation = transform.rotation;
			vozilo.transform.position = transform.position;
			vozilo.transform.SetParent(transform.parent);
			vozilo.GetComponent<SkriptaPotujNaprej>().speed = speed;
			vozilo.GetComponent<SkriptaPotujNaprej>().pozicija = vozilo.transform.localPosition;
			zacasna.GetComponent<SkriptaPotujNaprej>().nazaj = vozilo;
			zacasna = vozilo;
			zadnji = zacasna;
			
		}
        zadnji.GetComponent<SkriptaPotujNaprej>().nazaj = prvi;
		//postaviVozila ();
		cas = vrniCas();
		
	}
	
	// Update is called once per frame
	void Update () {
        if (nazajSkrip.jeAktivna)
        {
            cas -= Time.deltaTime;
            if (cas <= 0)
            {
                GameObject zac = prvi;

                zac.GetComponent<SkriptaPotujNaprej>().enabled = true;
                zac.transform.localPosition = zac.GetComponent<SkriptaPotujNaprej>().pozicija;
                prvi = zac.GetComponent<SkriptaPotujNaprej>().nazaj;

                //zac.GetComponent<SkriptaPotujNaprej>().nazaj=null;
                cas = vrniCas();
                zac.GetComponent<SkriptaPotujNaprej>().setActiveObject(true);
                zac.GetComponent<SkriptaPotujNaprej>().postaviSe(speed, dolgaCesta / speed);

            }
        }
		
		
	}
	
	public void postaviVozila(){
		float vsota = 0;
        
		for (int i=0; i < 1; i++) {
			vsota = i * vrniCas();
			GameObject zac = prvi;
            zac.GetComponent<SkriptaPotujNaprej>().enabled = true;
            zac.transform.localPosition = zac.GetComponent<SkriptaPotujNaprej>().pozicija;
			zac.transform.position += transform.forward*vsota;
			
			prvi = zac.GetComponent<SkriptaPotujNaprej>().nazaj;
			zac.GetComponent<SkriptaPotujNaprej>().setActiveObject(true);
            zac.GetComponent<SkriptaPotujNaprej>().postaviSe(speed, dolgaCesta / speed);
            //zac.GetComponent<SkriptaPotujNaprej>().nazaj=null;


        }
	}

	public float vrniCas(){
		return Random.Range (min,max);
	}
}
