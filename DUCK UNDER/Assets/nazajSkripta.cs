using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class nazajSkripta : MonoBehaviour {

    // Use this for initialization
    public List<Renderer> list;
    public List<Collider> listColiderjev;
    
    public GameObject nazaj;

	public string id;

    public bool izbrisana = true;

    public bool jeAktivna = false;
	void Start(){
		//gameObject.SetActive (false);
        
        list = new List<Renderer>();
        listColiderjev = new List<Collider>();
        napolniListRec(transform,0);
        if (id.Equals("trava") || id.Equals("crte"))
        {
            //gameObject.SetActive(false);
            setActiveObject(false);
        }
    }

    public void napolniListRec(Transform x, int stevec)
    {
        if(stevec == 0 || x.gameObject.GetComponent<nazajSkripta>() == null && x.gameObject.GetComponent<SkriptaPotujNaprej>() == null)
        {
            if (x.gameObject.GetComponent<Renderer>() != null)
            {
                list.Add(x.gameObject.GetComponent<Renderer>());
            }
            if(x.gameObject.GetComponent<Collider>() != null)
            {
                listColiderjev.Add(x.gameObject.GetComponent<Collider>());
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
        foreach (Collider i in listColiderjev)
        {
            i.enabled = active;
        }
        jeAktivna = active;
        
    }

    void Update()
    {

    }


}
