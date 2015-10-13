using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class izberiSpawnSkripta : MonoBehaviour {

	// Use this for initialization
	public GameObject nazaj;
	int izbira;

    public int stAvtov = 12;
    public int nalozeniAvti = 0;
    GameObject[] kovanci;
    public List<GameObject> listResetk;
    void Awake(){
        listResetk = new List<GameObject>();
        kovanci = new GameObject[6];
		SpawnGameObjectSkripta[] spawn1 = GetComponentsInChildren<SpawnGameObjectSkripta> ();
		if (spawn1.Length > 0) {
			spawn1[0].enabled=false;
			spawn1[1].enabled=false;
			izbira = Random.Range (0, 2);
			spawn1 [izbira].enabled = true;
		} else {
			spawnVlakSkripta[] spawn3 = GetComponentsInChildren<spawnVlakSkripta> ();
			spawn3 [Random.Range (1, 2)].enabled = false;
		}
        if(stAvtov > 5)
        {
            kovanci[0] = transform.FindChild("SPAWN 1").gameObject;
            kovanci[1] = transform.FindChild("SPAWN 2").gameObject;
            kovanci[2] = transform.FindChild("SPAWN 3").gameObject;
            kovanci[3] = transform.FindChild("SPAWN 4").gameObject;
            kovanci[4] = transform.FindChild("SPAWN 5").gameObject;
            kovanci[5] = transform.FindChild("SPAWN 6").gameObject;
        }
        
        
    }

	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
	
	}

	public void nastaviSpawnInHitrost(float povecava){
		SpawnGameObjectSkripta[] spawn1 = GetComponentsInChildren<SpawnGameObjectSkripta> ();
		spawn1[izbira].speed+= povecava;
	}

	public void pobrisiVozila(){
		SpawnGameObjectSkripta[] spawn1 = GetComponentsInChildren<SpawnGameObjectSkripta> ();
		spawn1 [izbira].pospraviVse (12,spawn1 [izbira].prvi);
        kovanci[0].SetActive(false);
        kovanci[1].SetActive(false);
        kovanci[2].SetActive(false);
        kovanci[3].SetActive(false);
        kovanci[4].SetActive(false);
        kovanci[5].SetActive(false);
        foreach(GameObject i in listResetk)
        {
            i.SetActive(false);
        }
        listResetk.Clear();
    }

	public void postaviVozila(){
		SpawnGameObjectSkripta[] spawn1 = GetComponentsInChildren<SpawnGameObjectSkripta> ();
		spawn1 [izbira].postaviVozila ();
        kovanci[0].SetActive(RandomVoziloSkripta.vrniRandomKovanec());
        kovanci[1].SetActive(RandomVoziloSkripta.vrniRandomKovanec());
        kovanci[2].SetActive(RandomVoziloSkripta.vrniRandomKovanec());
        kovanci[3].SetActive(RandomVoziloSkripta.vrniRandomKovanec());
        kovanci[4].SetActive(RandomVoziloSkripta.vrniRandomKovanec());
        kovanci[5].SetActive(RandomVoziloSkripta.vrniRandomKovanec());
    }
}
