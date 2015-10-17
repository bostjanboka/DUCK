using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class nazajSkripta : MonoBehaviour {

    // Use this for initialization
    public List<Renderer> list;
    public GameObject nazaj;

	public string id;

    public bool izbrisana = true;
    public bool pobrisi = false;
    bool brisi = false;

	void Start(){
		//gameObject.SetActive (false);
        if(id.Equals("trava") || id.Equals("crte"))
        {
            gameObject.SetActive(false);
        }
        list = new List<Renderer>();
        napolniListRec(transform,0);

    }

    void napolniListRec(Transform x, int stevec)
    {
        if(stevec == 0 || x.gameObject.GetComponent<nazajSkripta>() == null && x.gameObject.GetComponent<SkriptaPotujNaprej>() == null)
        {
            if (x.gameObject.GetComponent<Renderer>() != null)
            {
                list.Add(x.gameObject.GetComponent<Renderer>());
            }
            for (int i = 0; i < x.childCount; i++)
            {
                napolniListRec(x.GetChild(i),stevec++);
            }
        }

    }

    public void setActiveObject(bool active)
    {
        foreach (Renderer i in list)
        {
            i.enabled = active;
        }
    }

    void Update()
    {
        if (brisi != pobrisi)
        {
            setActiveObject(pobrisi);
        }
        brisi = pobrisi;
    }


}
