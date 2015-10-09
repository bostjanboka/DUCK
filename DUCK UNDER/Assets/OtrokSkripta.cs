using UnityEngine;
using System.Collections;

public class OtrokSkripta : MonoBehaviour {

	// Use this for initialization
	public GameObject zasleduj;
	public GameObject zasledujeMe;
	public GameObject povozenaRaca;
	public GameObject osamljenaRaca;
	Vector3 smer;
	public float speed;

	public bool povozena=false;
	GameObject povozenOtrok;
	AudioSkripta audio2;

    GameObject raca;
    GameObject sirokaExit;
	void Awake(){
		povozenOtrok = Instantiate (povozenaRaca) as GameObject;
		//povozenOtrok.SetActive (false);
		audio2 = GameObject.Find("Audio").GetComponent<AudioSkripta>();
	}
	void Start () {
		smer = Vector3.zero;
		if(zasleduj)
			zasleduj.GetComponent<ZasledujeMeSkripta> ().ZasledujeMe = gameObject;
        raca = GameObject.Find("raca");
	}
	
	// Update is called once per frame
	void Update () {
		if (zasleduj) {

			smer = raca.transform.position;
            smer.y = transform.position.y;
			float step = speed*Time.deltaTime;

			Vector3 newDir = Vector3.RotateTowards(transform.position,smer,60,1.0f);
			transform.rotation = Quaternion.LookRotation(newDir);
            
            Vector3 pos = Vector3.MoveTowards(transform.position,zasleduj.transform.position,step);
            pos.y = transform.position.y;
            transform.position = pos;
		}
	}



	void OnTriggerEnter(Collider other) {
		if (other.CompareTag ("kolo")) {
			if(!povozena){
				RackaSkripta.stRack--;
				povozena=true;
				povozenOtrok.transform.position = transform.position;
				povozenOtrok.transform.rotation = transform.rotation;
				povozenOtrok.SetActive(true);
				//audio2.povozi();
				gameObject.SetActive(false);
			}
		}else if (other.CompareTag("siroka"))
        {
            if(sirokaExit != null && sirokaExit != other.gameObject)
            {
                raca.GetComponent<RackaSkripta>().rackaPreckala(false, other.gameObject);
            }
        }
	}

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("siroka"))
        {
            sirokaExit = other.gameObject;
            raca.GetComponent<RackaSkripta>().rackaPreckala(true, null);
        }
    }

    public void uniciOtroka(){
		Destroy (povozenOtrok);
	}
}
