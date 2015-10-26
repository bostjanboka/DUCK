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
    Collider sfera;
	void Awake(){
		povozenOtrok = Instantiate (povozenaRaca) as GameObject;
		audio2 = GameObject.Find("Audio").GetComponent<AudioSkripta>();
	}
	void Start () {
		smer = Vector3.zero;
		//if(zasleduj)
			//zasleduj.GetComponent<ZasledujeMeSkripta> ().ZasledujeMe = gameObject;
        raca = GameObject.Find("raca");
        //ubijSe();
        speed += Random.Range(-3f, 1f);
        sfera = transform.FindChild("GameObject").GetComponent<Collider>();
	}
	
	// Update is called once per frame
	void Update () {
		smer = raca.transform.position;
        smer.y = transform.position.y;
		float step = speed*Time.deltaTime;

		Vector3 newDir = Vector3.RotateTowards(transform.position,smer,60,0f);
        transform.rotation = Quaternion.LookRotation(zasleduj.transform.position-transform.position,Vector3.up);
            
        
        //pos.y = transform.position.y;
        
        if(Vector3.Distance(zasleduj.transform.position,transform.position) > 1f)
        {
            Vector3 pos = Vector3.MoveTowards(transform.position, zasleduj.transform.position, step);
            transform.position = pos;
            if (!sfera.enabled)
            {
               // sfera.enabled = true;
            }
        }
        else
        {
           // sfera.enabled = false;
        }
		
	}



	void OnTriggerEnter(Collider other) {
		if (other.CompareTag ("kolo")) {
			povozenOtrok.transform.position = transform.position;
			povozenOtrok.transform.rotation = transform.rotation;
			povozenOtrok.SetActive(true);
            //audio2.povozi();
            ubijSe();
			
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

    public void ubijSe(){
        raca.GetComponent<RackaSkripta>().mrtveRacke.Add(gameObject);
        gameObject.SetActive(false);
	}
}
