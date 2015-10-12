using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class JasekSkripta : MonoBehaviour {

    // Use this for initialization
    public int stEnter;
    GameObject coliderji;
    public GameObject[] racka;
    List<GameObject> list;
    void Start () {
        stEnter = 0;
        coliderji = transform.FindChild("COLIDERS").gameObject;
        coliderji.SetActive(false);
        racka = new GameObject[16];
        Transform crna = transform.FindChild("CRNA");
        for(int i=0; i < racka.Length; i++)
        {
            racka[i] = crna.GetChild(i).GetChild(0).gameObject;
            racka[i].SetActive(false);
        }
        list = transform.parent.parent.GetComponent<izberiSpawnSkripta>().listResetk;
        
	}
	
	// Update is called once per frame
	void Update () {
	   if(stEnter <= 0)
        {
            coliderji.SetActive(false);
        }
	}

    void OnTriggerEnter(Collider other)
    {
        if(stEnter == 0)
        {
            coliderji.SetActive(true);
        }
        stEnter++;
    }

    void OnTriggerExit(Collider other)
    {
        stEnter--;
        if(stEnter <= 0)
        {
            coliderji.SetActive(false);
        }
    }

    public void dodajRacko(int i)
    {
        stEnter--;
        racka[i].SetActive(true);
        list.Add(racka[i]);
    }
}
