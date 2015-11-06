using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

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
    public GameObject perfect;

    //julijan
    public GameObject ScoreText;
    public scoreLoadingImage ScoreTextScripta;
    //julijan

	public static int stRack;
	Vector3 smer;

	GameObject valovi;
	GameObject povozena;
	public GameObject[] tocke;

	Vector3 startPoz;

	public bool zgubil=false;
	float cas=0;

	public float maxScale=2;
	public float casScale=2;
	Transform tocket;

    int stRackPreckalo = 0;

    GameObject[] otroci;
    public List<GameObject> mrtveRacke;

    void Awake(){
        tocket = transform.FindChild("tocke");
        tocke = new GameObject[tocket.childCount];
		

        for (int i=0; i < tocket.childCount; i++)
        {
            tocke[i] = tocket.GetChild(i).gameObject;
        }
        startPoz = transform.position;
        otroci = new GameObject[tocke.Length];
        postaviOtroke();
		povozena = Instantiate (povozenaRaca) as GameObject;
        mrtveRacke = new List<GameObject>(tocke.Length);
	}

	void Start () {

		//valovi = transform.FindChild ("valovi").gameObject;
        perfect.SetActive(false);

        //julijan
        ScoreTextScripta = ScoreText.GetComponent<scoreLoadingImage>();
        //julijan
    }
	
	// Update is called once per frame
	void Update () {

		if (InputKey.tocka.activeSelf) {
            stRack = otroci.Length - mrtveRacke.Count;
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
			/*if (tocket.localScale.z < maxScale) {
				Vector3 zacS = tocket.localScale;
				zacS.z += 1 / casScale * Time.deltaTime;
				tocket.localScale = zacS;
			}*/
		} else {
			/*if (tocket.localScale.z > 1) {
				Vector3 zacS = tocket.localScale;
				zacS.z -= 1 * Time.deltaTime;
				tocket.localScale = zacS;
			}*/
		}


		if (zgubil) {
			if(cas <= 0.1f){
				cas += Time.deltaTime;
			}
			else{
				meni.lost();
			}
		}
		

	}

	void OnTriggerStay(Collider other) {

	}

	void OnTriggerEnter(Collider other) {
		/*if (other.CompareTag ("voda")) {
			valovi.SetActive (true);
		} else if (other.CompareTag ("orkan")) {
			meni.lost ();
			gameObject.SetActive (false);
		} */
	}

	public void povoziRaco(){
		povozena.SetActive(true);
		povozena.transform.position = transform.position;
		povozena.transform.rotation = transform.rotation;
		meni.lost();
		gameObject.SetActive(false);
        zgubil = true;
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
        for(int i=0; i < otroci.Length; i++)
        {
            if (otroci[i] && otroci[i].activeSelf)
            {
                otroci[i].GetComponent<OtrokSkripta>().ubijSe();
            }
        }
        
        gameObject.SetActive (true);
		povozena.SetActive (false);
        
		transform.position = startPoz;
        postaviOtroke();
        kamera.Reset ();
		meni.play ();
		
		orkan.Reset ();
		stRack = 10;
		zgubil = false;
		cas = 0;
        stRackPreckalo = 0;
        teren.pobrisiVse();
        scoreLoadingImage.score = 0;


    }

	void postaviOtroke(){
		for(int i =0; i < tocke.Length; i++)
        {
            if (tocke[i].activeSelf)
            {
                otroci[i] = Instantiate(otrok, tocke[i].transform.position, transform.rotation) as GameObject;
                otroci[i].GetComponent<OtrokSkripta>().zasleduj = tocke[i];
            }
            
        }
	}

    public bool oziviRacko(Vector3 pos, Quaternion rot)
    {
        if(mrtveRacke.Count > 0)
        {
            mrtveRacke[0].transform.position = pos;
            mrtveRacke[0].transform.rotation = rot;
            mrtveRacke[0].SetActive(true);
            mrtveRacke.RemoveAt(0);
            return true;
        }
        return false;
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
                    perfect.transform.position =  siroka.GetComponent<posliIzbrisSkripta>().objekt.GetComponent<SirokaRandomSkripta>().getPerfect();
                    perfect.SetActive(false);
                    perfect.SetActive(true);
                }
            }
        }
    }

    void OnBecameInvisible()
    {
        zgubil = true;
    }




}
