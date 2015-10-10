using UnityEngine;
using System.Collections;

public class JasekSkripta : MonoBehaviour {

    // Use this for initialization
    int stEnter;
    GameObject coliderji;
    public GameObject[] racka;
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
        
	}
	
	// Update is called once per frame
	void Update () {
	   
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
        if(stEnter == 0)
        {
            coliderji.SetActive(false);
        }
    }
}
