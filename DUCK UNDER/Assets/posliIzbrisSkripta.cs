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
            other.gameObject.GetComponent<unicevalkaSkripta>().pobrisiZadnjega(objekt);
        }

    }
}
