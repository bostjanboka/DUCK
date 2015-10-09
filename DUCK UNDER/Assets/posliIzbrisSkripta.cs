using UnityEngine;
using System.Collections;

public class posliIzbrisSkripta : MonoBehaviour {

    // Use this for initialization
    public GameObject objekt;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("unicevalka"))
        {
            if (other.gameObject.name.Equals("unicevalka"))
            {
                other.gameObject.GetComponent<unicevalkaSkripta>().pobrisiZadnjega(objekt);
            }
            else
            {
                other.gameObject.GetComponent<unicevalkaSkripta>().pobrisiZadnjegaZ(objekt);
            }
        }

    }
}
