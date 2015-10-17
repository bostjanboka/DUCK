using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SkriptaPotujNaprej : MonoBehaviour {

    // Use this for initialization
    public Collider[] kolesa;
    public Collider vozilo;
	public float speed=4;
	public GameObject nazaj;
	public Vector3 pozicija;

	public float size=0;
	public float zamik;
    public List<Renderer> list;

    float speedEnable = 1;

    void Start () {
        vozilo = gameObject.GetComponent<Collider>();
        Transform sence = transform.FindChild ("SENCE");
		if (sence) {
			if(transform.localEulerAngles.y < 200){
				sence.FindChild("DOL").gameObject.SetActive(false);
			}else{
				sence.FindChild("GOR").gameObject.SetActive(false);
			}
		}
        int i = ++transform.parent.gameObject.GetComponent<izberiSpawnSkripta>().nalozeniAvti;
        list = new List<Renderer>();
        napolniListRec(transform, 0);
        if (i == transform.parent.gameObject.GetComponent<izberiSpawnSkripta>().stAvtov)
        {
            RandomCreatorSkripta.nalozeno++;
            setActiveObject(false);
            transform.parent.gameObject.SetActive(false);
        }
        else
        {
            setActiveObject(false);
        }
        

    }
	
	// Update is called once per frame
	void Update () {
		transform.position+= (transform.forward * speed * Time.deltaTime*speedEnable);


	}

    void napolniListRec(Transform x, int stevec)
    {
        if (stevec == 0 || x.gameObject.GetComponent<nazajSkripta>() == null && x.gameObject.GetComponent<SkriptaPotujNaprej>() == null)
        {
            if (x.gameObject.GetComponent<Renderer>() != null)
            {
                list.Add(x.gameObject.GetComponent<Renderer>());
            }
            for (int i = 0; i < x.childCount; i++)
            {
                napolniListRec(x.GetChild(i), stevec++);
            }
        }

    }

    public void setActiveObject(bool active)
    {
        foreach (Renderer i in list)
        {
            i.enabled = active;
        }
        vozilo.enabled = active;
        for(int i=0; i < kolesa.Length; i++)
        {
            kolesa[i].enabled = active;
        }
        if (active)
        {
            speedEnable = 1;
        }
        else
        {
            speedEnable = 0;
        }
    }

    public float vrniZamikPrvi(){
		if (size == 0) {
			BoxCollider colider = gameObject.GetComponent<BoxCollider> ();
			size = Mathf.Abs(colider.size.z);
			zamik = colider.center.z;
		}
		return size/2f + zamik;
	}
	public float vrniZamikZadnji(){
		return size / 2f - zamik;
	}
}
