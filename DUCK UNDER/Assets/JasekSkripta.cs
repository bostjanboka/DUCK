using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class JasekSkripta : MonoBehaviour {

    // Use this for initialization
    GameObject coliderji;
    float cas = 0;
    Collider main;
    Renderer render;
    void Start () {
        coliderji = transform.FindChild("col").gameObject;
        coliderji.SetActive(false);
        main = gameObject.GetComponent<Collider>();
        render = transform.FindChild("Model").GetComponent<Renderer>();
        setEnable(false);

	}
	
	// Update is called once per frame
	void Update () {
	   if(cas <= 0 && coliderji.activeSelf)
        {
            coliderji.SetActive(false);
        }
        else
        {
            cas -= Time.deltaTime;
        }
	}

    void OnTriggerEnter(Collider other)
    {
        if(cas <= 0)
        {
            coliderji.SetActive(true);
            cas = 1;
        }
    }

    public void setEnable(bool kaj)
    {
        main.enabled = kaj;
        render.enabled = kaj;
        if (!kaj)
        {
            enabled = false;
        }
    }

    
}
