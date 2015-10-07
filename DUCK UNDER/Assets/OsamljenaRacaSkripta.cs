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
			GameObject[] tocke = other.gameObject.GetComponent<RackaSkripta>().tocke;
            other.gameObject.GetComponent<RackaSkripta>().rackaPreckala(true, null);
			for(int i=0; i < tocke.Length; i++){
				if(!tocke[i].GetComponent<ZasledujeMeSkripta>().ZasledujeMe.activeSelf){
					GameObject zac = tocke[i].GetComponent<ZasledujeMeSkripta>().ZasledujeMe;
					zac.transform.position = transform.position;
					zac.transform.rotation = transform.rotation;
					zac.GetComponent<OtrokSkripta>().povozena = false;
					zac.SetActive(true);
					gameObject.SetActive(false);
					RackaSkripta.stRack++;
					break;
				}
			}

		}
	}
}
