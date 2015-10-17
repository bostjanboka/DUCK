using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class testzaunicenje : MonoBehaviour {

    // Use this for initialization
    public List<Renderer> list;
    public bool brisi = false;
    bool staraB = false;
    int i;
    void Start () {
        list = new List<Renderer>();
        napolniListRec(transform);
	}

    void napolniListRec(Transform x)
    {
        if (x.gameObject.GetComponent<Renderer>() != null)
        {
            list.Add(x.gameObject.GetComponent<Renderer>());
        }
        for(int i=0; i < x.childCount; i++)
        {
            napolniListRec(x.GetChild(i));
        }
        
        
    }

    public void setActiveObject(bool active)
    {
        foreach (Renderer i in list)
        {
            i.enabled = active;
        }
    }
	
	// Update is called once per frame
	void Update () {
        
	}


}
