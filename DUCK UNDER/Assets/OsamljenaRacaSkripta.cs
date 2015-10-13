using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OsamljenaRacaSkripta : MonoBehaviour {

	// Use this for initialization
	public GameObject NavadnaRacka;


	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (0, 180 * Time.deltaTime, 0);


	}

	void OnTriggerEnter(Collider other) {
		if (other.CompareTag ("raca") && gameObject.activeSelf) {
            if(other.gameObject.GetComponent<RackaSkripta>().oziviRacko(transform.position, transform.rotation))
            {
                other.gameObject.GetComponent<RackaSkripta>().rackaPreckala(true, null);
                gameObject.SetActive(false);
            }
            

		}
	}
}
