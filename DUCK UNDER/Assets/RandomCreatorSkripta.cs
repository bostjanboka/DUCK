using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RandomCreatorSkripta : MonoBehaviour {

	// Use this for initialization
	GameObject raca;

	public GameObject kmetija;

	public GameObject crte;
	public int verCesta=0;
	public GameObject cesta;

	public int verZeleznica=0;
	public GameObject zeleznica;

	public GameObject travaSiroka;

	public GameObject trava;
	public GameObject leviBreg;
	public GameObject desniBreg;

	public GameObject prviCesta;
	public GameObject zadnjiCesta;

	public GameObject prviZeleznica;
	public GameObject zadnjiZeleznica;

	public GameObject prviSiroka;
	public GameObject zadnjiSiroka;

	public GameObject prviCrte;
	public GameObject zadnjiCrte;

	public GameObject prviTrava;
	public GameObject zadnjiTrava;
	


	public static int nalozeno=0;
    public static GameObject[] zadnjihX;
	GameObject prejsni;
	GameObject[] tabela;
	GameObject Kmetija;
	Vector3 vec;
	public List<GameObject> list;

	int stetjeTrave =0;
	int stTrav=0;


	bool vDelovanju=false;

	RandomVoziloSkripta randomVozilo;
    randomVlakSkripta randomVlak;
    public GameObject zaIzbrisatObjekt;
    public GameObject zaIzbrisatObjektZ;
    void Awake(){
        zadnjihX = new GameObject[5];
		int skupaj = verCesta + verZeleznica;
		int sestevek = 0;
		randomVozilo = transform.FindChild ("randomVozilo").GetComponent<RandomVoziloSkripta>();
        randomVlak = transform.FindChild("randomVlak").GetComponent<randomVlakSkripta>();
		
		raca = GameObject.Find ("raca");
		list = new List<GameObject>();
		vec = Vector3.zero;//transform.position;
		tabela = new GameObject[skupaj];
		for (int i=0; i < verCesta; i++) {
			tabela[i] = cesta;
			
		}
		sestevek += verCesta;

		for (int i=sestevek; i < sestevek+verZeleznica; i++) {
			tabela[i] = zeleznica;
			
		}
		sestevek += verZeleznica;

		prviCesta = Instantiate (cesta) as GameObject;
		prviCesta.transform.SetParent (transform);
		GameObject zacasna = prviCesta;

		for (int i=0; i < 10; i++) {
			GameObject inst = Instantiate(cesta) as GameObject;
			zacasna.GetComponent<nazajSkripta>().nazaj = inst;
			zacasna.GetComponent<nazajSkripta>().id = "cesta";
			inst.transform.SetParent(transform);
			zacasna = inst;

		}
		zacasna.GetComponent<nazajSkripta>().id = "cesta";
		zadnjiCesta = zacasna;



		prviZeleznica = Instantiate (zeleznica) as GameObject;
		prviZeleznica.transform.SetParent (transform);
		GameObject zacasna2 = prviZeleznica;

		for (int i=0; i < 10; i++) {
			GameObject inst = Instantiate(zeleznica) as GameObject;
			zacasna2.GetComponent<nazajSkripta>().nazaj = inst;
			zacasna2.GetComponent<nazajSkripta>().id = "zeleznica";
			inst.transform.SetParent(transform);
			zacasna2 = inst;

		}
		zacasna2.GetComponent<nazajSkripta>().id = "zeleznica";
		zadnjiZeleznica = zacasna2;

		prviSiroka = Instantiate (travaSiroka) as GameObject;
		prviSiroka.transform.SetParent (transform);
		GameObject zacasna3 = prviSiroka;

		for (int i=0; i < 10; i++) {
			GameObject inst = Instantiate(travaSiroka) as GameObject;
			zacasna3.GetComponent<nazajSkripta>().nazaj = inst;
			zacasna3.GetComponent<nazajSkripta>().id = "siroka";
			inst.transform.SetParent(transform);
			zacasna3 = inst;

		}
		zacasna3.GetComponent<nazajSkripta>().id = "siroka";
		zadnjiSiroka = zacasna3;

		prviCrte = Instantiate (crte) as GameObject;
		prviCrte.transform.SetParent (transform);
		GameObject zacasna4 = prviCrte;
		//zacasna4.SetActive (false);
		for (int i=0; i < 10; i++) {
			GameObject inst = Instantiate(crte) as GameObject;
			zacasna4.GetComponent<nazajSkripta>().nazaj = inst;
			zacasna4.GetComponent<nazajSkripta>().id = "crte";
			inst.transform.SetParent(transform);
			zacasna4 = inst;
			//zacasna4.SetActive (false);
		}
		zacasna4.GetComponent<nazajSkripta>().id = "crte";
		zadnjiCrte = zacasna4;

		prviTrava = Instantiate (trava) as GameObject;
		prviTrava.transform.SetParent (transform);
		GameObject zacasna5 = prviTrava;
		//zacasna5.SetActive (false);
		for (int i=0; i < 10; i++) {
			GameObject inst = Instantiate(trava) as GameObject;
			zacasna5.GetComponent<nazajSkripta>().nazaj = inst;
			zacasna5.GetComponent<nazajSkripta>().id = "trava";
			inst.transform.SetParent(transform);
			zacasna5 = inst;
			//zacasna5.SetActive (false);
		}
		zacasna5.GetComponent<nazajSkripta>().id = "trava";
		zadnjiTrava = zacasna5;

		Kmetija = Instantiate (kmetija);
		list.Add (Kmetija);
		nalozeno++;


	}

	
	// Update is called once per frame
	void Update () {
		//Debug.Log (nalozeno + " nalozilo");
        if(list.Count < 5 && nalozeno == 24)
        {
            dodajNoviElement();
        }
		else if (nalozeno == 23) {
			//StartPostavitev();
			nalozeno++;
		}
        if(zaIzbrisatObjekt != null && zaIzbrisatObjekt != list[0] && zaIzbrisatObjektZ != list[0])
        {
            pobrisiZadnjega();
        }
	}

	void dodajElement(GameObject spawn, GameObject spawnTabela){
		spawn.GetComponent<nazajSkripta>().setActiveObject(true);
		Mesh mesh = spawn.GetComponent<MeshFilter>().sharedMesh;
		Bounds bounds = mesh.bounds;
		vec.z+= bounds.size.z*spawn.transform.localScale.z;
		Vector3 pozicija = spawn.transform.position;
		pozicija.z = vec.z - bounds.size.z/2f*spawn.transform.localScale.z;
		spawn.transform.localPosition = pozicija;


		if(spawnTabela == cesta){
			spawn.GetComponent<izberiSpawnSkripta>().nastaviSpawnInHitrost(stTrav*2);
			spawn.GetComponent<izberiSpawnSkripta>().postaviVozila();
			prviCesta = spawn.GetComponent<nazajSkripta>().nazaj;
		}
		else if(spawnTabela == zeleznica){
			prviZeleznica = spawn.GetComponent<nazajSkripta>().nazaj;
		
		}else if(spawnTabela == travaSiroka){
			spawn.GetComponent<SirokaRandomSkripta>().postavi();
			prviSiroka = spawn.GetComponent<nazajSkripta>().nazaj;
		}else if(spawnTabela == crte){
			prviCrte = spawn.GetComponent<nazajSkripta>().nazaj;
		}else if(spawnTabela == trava){
			prviTrava = spawn.GetComponent<nazajSkripta>().nazaj;
		}
        spawn.GetComponent<nazajSkripta>().izbrisana = false;
        list.Add(spawn);
	}

	public void pobrisiVse(){
		vDelovanju = false;
		for (int i=0; i < list.Count; i++) {
			GameObject brisem = list[i];
			//Debug.Log("prisem primerek");
			string id = brisem.GetComponent<nazajSkripta>().id;

			if(id.Equals("cesta")){
				brisem.GetComponent<izberiSpawnSkripta>().pobrisiVozila();
				zadnjiCesta.GetComponent<nazajSkripta>().nazaj = brisem;
				zadnjiCesta = brisem;
			
			}else if(id.Equals("zeleznica")){
				zadnjiZeleznica.GetComponent<nazajSkripta>().nazaj = brisem;
				zadnjiZeleznica = brisem;
			}else if(id.Equals("siroka")){
				zadnjiSiroka.GetComponent<nazajSkripta>().nazaj = brisem;
				zadnjiSiroka = brisem;
				brisem.GetComponent<SirokaRandomSkripta>().reset();
			
			}else if(id.Equals("trava")){
				zadnjiTrava.GetComponent<nazajSkripta>().nazaj = brisem;
				zadnjiTrava = brisem;
			}else if(id.Equals("crte")){
				zadnjiCrte.GetComponent<nazajSkripta>().nazaj = brisem;
				zadnjiCrte = brisem;
			}
            brisem.GetComponent<nazajSkripta>().izbrisana = true;
            brisem.GetComponent<nazajSkripta>().setActiveObject(false);

        }
		list.Clear ();
        zadnjihX = new GameObject[5];
		vec = Vector3.zero;
		stTrav = 0;
		Kmetija.GetComponent<nazajSkripta>().setActiveObject(true); 
		list.Add (Kmetija);
		//StartPostavitev ();
        zaIzbrisatObjekt = null;
        zaIzbrisatObjektZ = null;

	}

	public GameObject vrniRandomVozilo(){
		return randomVozilo.vrniVozilo ();
	}

    public GameObject getRandomVlak()
    {
        return randomVlak.getRandomVlak();
    }

    
    public void pobrisiZadnjega()
    {
        
        GameObject brisem = list[0];
        
        brisem.GetComponent<nazajSkripta>().izbrisana = true;
        string id = brisem.GetComponent<nazajSkripta>().id;

        if (id.Equals("cesta"))
        {
            brisem.GetComponent<izberiSpawnSkripta>().pobrisiVozila();
            zadnjiCesta.GetComponent<nazajSkripta>().nazaj = brisem;
            zadnjiCesta = brisem;

        }
        else if (id.Equals("zeleznica"))
        {
            zadnjiZeleznica.GetComponent<nazajSkripta>().nazaj = brisem;
            zadnjiZeleznica = brisem;
        }
        else if (id.Equals("siroka"))
        {
            zadnjiSiroka.GetComponent<nazajSkripta>().nazaj = brisem;
            zadnjiSiroka = brisem;
            brisem.GetComponent<SirokaRandomSkripta>().reset();

        }
        else if (id.Equals("trava"))
        {
            zadnjiTrava.GetComponent<nazajSkripta>().nazaj = brisem;
            zadnjiTrava = brisem;
        }
        else if (id.Equals("crte"))
        {
            zadnjiCrte.GetComponent<nazajSkripta>().nazaj = brisem;
            zadnjiCrte = brisem;
        }

        addZadnjih(brisem);

        list.RemoveAt(0);
            
        brisem.GetComponent<nazajSkripta>().setActiveObject(false);
        

    }

    public void dodajNoviElement()
    {
        if (stetjeTrave >= 5)
        {
            stetjeTrave = 0;
            stTrav++;
            dodajElement(prviSiroka, travaSiroka);
            prejsni = travaSiroka;
        }
        else
        {
            GameObject spawn = tabela[Random.Range(0, tabela.Length)];
            stetjeTrave++;
            if (spawn == prejsni && spawn == travaSiroka)
            {
                spawn = cesta;
            }
            if (prejsni == spawn && spawn == cesta)
            {
                dodajElement(prviCrte, crte);

            }
            else if (prejsni == spawn && spawn == zeleznica)
            {
                dodajElement(prviTrava, trava);

            }
            else if (prejsni != travaSiroka && prejsni != spawn && spawn != travaSiroka)
            {
                dodajElement(prviTrava, trava);
            }

            if (spawn == cesta)
            {
                dodajElement(prviCesta, spawn);
            }
            else if (spawn == zeleznica)
            {
                dodajElement(prviZeleznica, spawn);

            }
            else
            { 
                dodajElement(prviSiroka, spawn);
            }
            prejsni = spawn;
        }
    }

    public void addZadnjih(GameObject brisem)
    {
        for(int i= zadnjihX.Length-1; i > 0; i--)
        {
            zadnjihX[i] = zadnjihX[i - 1];
        }
        zadnjihX[0] = brisem;
    }
}
