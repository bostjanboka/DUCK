using UnityEngine;
using System.Collections;

public class ResetkaSkripta : MonoBehaviour {

    // Use this for initialization
    
    int indeks;
    void Start () {
 
        indeks = int.Parse("" + gameObject.name[gameObject.name.Length - 1]);

        if (gameObject.name[gameObject.name.Length - 2] != '_')
        {
            indeks += 10;
        }
        indeks--;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (!transform.parent.parent.GetComponent<JasekSkripta>().racka[indeks].activeSelf && other.gameObject.CompareTag("otrok"))
        {
            other.gameObject.SetActive(false);
            RackaSkripta.stRack--;
            transform.parent.parent.GetComponent<JasekSkripta>().dodajRacko(indeks);
        }
    }
}
