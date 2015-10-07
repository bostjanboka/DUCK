using UnityEngine;
using System.Collections;

public class RackaSkripta : MonoBehaviour {

	// Use this for initialization


	public RandomCreatorSkripta teren;
	public SlediRaciSkripta kamera;
	public MeniSkripta meni;
	public orkanSkripta orkan;
	public float speed;
	public GameObject zasledujeMe;
	public GameObject otrok;
	public GameObject povozenaRaca;

	public static int stRack=10;
	Vector3 smer;

	GameObject valovi;
	GameObject povozena;
	public GameObject[] tocke;

	Vector3 startPoz;

	bool zgubil=false;
	float cas=0;

	public float maxScale=2;
	public float casScale=2;
	Transform tocket;

    int stRackPreckalo = 0;

	void Awake(){
		tocke = new GameObject[10];
		tocket = transform.FindChild("tocke");

		tocke[0] = tocket.FindChild ("t0").gameObject;
		tocke[1] = tocket.FindChild ("t1").gameObject;
		tocke[2] = tocket.FindChild ("t2").gameObject;
		tocke[3] = tocket.FindChild ("t3").gameObject;
		tocke[4] = tocket.FindChild ("t4").gameObject;
		tocke[5] = tocket.FindChild ("t5").gameObject;
		tocke[6] = tocket.FindChild ("t6").gameObject;
		tocke[7] = tocket.FindChild ("t7").gameObject;
		tocke[8] = tocket.FindChild ("t8").gameObject;
		tocke[9] = tocket.FindChild ("t9").gameObject;
		startPoz = transform.position;
		postaviOtroke ();
		povozena = Instantiate (povozenaRaca) as GameObject;
		//povozena.SetActive (false);
	}

	void Start () {

		valovi = transform.FindChild ("valovi").gameObject;

	}
	
	// Update is called once per frame
	void Update () {

		if (InputKey.tocka.activeSelf) {
			Vector3 zac = InputKey.tocka.transform.position;
			zac.y = transform.position.y;
			//InputKey.tocka.transform.position = zac;

			smer = zac - transform.position;
			float step = speed * Time.deltaTime;
		
			Vector3 newDir = Vector3.RotateTowards (transform.forward, smer, step * 3, 0.0f);
			transform.rotation = Quaternion.LookRotation (newDir);
			if (Vector3.Distance (transform.position, zac) > 0.6f) {
				transform.position += transform.forward * step;
				//Debug.Log("cudno"+transform.position);
			} else {
				InputKey.tocka.SetActive(false);
			}
			if (tocket.localScale.z < maxScale) {
				Vector3 zacS = tocket.localScale;
				zacS.z += 1 / casScale * Time.deltaTime;
				tocket.localScale = zacS;
			}
		} else {
			if (tocket.localScale.z > 1) {
				Vector3 zacS = tocket.localScale;
				zacS.z -= 1 * Time.deltaTime;
				tocket.localScale = zacS;
			}
		}


		if (zgubil) {
			if(cas <= 1f){
				cas += Time.deltaTime;
			}
			else{
				meni.lost();
			}
		}
		else if (stRack < 1) {
			zgubil = true;
		}

	}

	void OnTriggerStay(Collider other) {

	}

	void OnTriggerEnter(Collider other) {
		if (other.CompareTag ("voda")) {
			valovi.SetActive (true);
		} else if (other.CompareTag ("orkan")) {
			meni.lost ();
			gameObject.SetActive (false);
		} 
	}

	public void povoziRaco(){
		povozena.SetActive(true);
		povozena.transform.position = transform.position;
		povozena.transform.rotation = transform.rotation;
		meni.lost();
		gameObject.SetActive(false);
	}

	void OnTriggerExit(Collider other) {
		if (other.CompareTag ("voda")) {
			valovi.SetActive (false);
		}
	}

	public void postaviNazaj(){
		if (InputKey.tocka.activeSelf) {
			InputKey.tocka.SetActive(false);
		}
		gameObject.SetActive (true);
		povozena.SetActive (false);
		teren.pobrisiVse ();
		transform.position = startPoz;
		kamera.Reset ();
		meni.play ();
		postaviOtroke ();
		orkan.Reset ();
		stRack = 10;
		zgubil = false;
		cas = 0;
        stRackPreckalo = 0;
        
	}

	void postaviOtroke(){
		for (int i=0; i < tocke.Length; i++) {
			if(tocke[i].GetComponent<ZasledujeMeSkripta>().ZasledujeMe){
				tocke[i].GetComponent<ZasledujeMeSkripta>().ZasledujeMe.GetComponent<OtrokSkripta>().uniciOtroka();
			}

			Destroy(tocke[i].GetComponent<ZasledujeMeSkripta>().ZasledujeMe);
			Debug.Log("postavitev otrok");
			GameObject game = Instantiate(otrok,tocke[i].transform.position,transform.rotation) as GameObject;
			game.GetComponent<OtrokSkripta>().zasleduj = tocke[i];
			tocke[i].GetComponent<ZasledujeMeSkripta>().ZasledujeMe = game;
		}
	}

    public void rackaPreckala(bool reset, GameObject siroka)
    {
        if (reset)
        {
            stRackPreckalo = 0;
        }
        else
        {
            stRackPreckalo++;
            if (stRackPreckalo >= 10)
            {
                stRackPreckalo = 0;
                if(siroka != null)
                {
                    siroka.GetComponent<posliIzbrisSkripta>().objekt.GetComponent<SirokaRandomSkripta>().setPerfect();
                }
            }
        }
    }




}
