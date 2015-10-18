using UnityEngine;
using System.Collections;

public class orkanSkripta : MonoBehaviour {

	// Use this for initialization
	public float histrostVrtenja;
	public float speed = 3;
	public GameObject vOrkanu;
	Vector3 zacPoz;

	Transform raca;
	bool zatakni=false;

	public GameObject prvi;
	static public GameObject zadnji;

	public static Transform parent;

	void Awake(){
		parent = transform;
	}

	void Start () {
		raca = GameObject.Find ("raca").transform;
		zacPoz = transform.position;

		prvi = Instantiate (vOrkanu);
		prvi.SetActive (false);
		GameObject zac=prvi;
		for (int i=0; i < 60; i++) {
			zac.GetComponent<nazajSkripta>().nazaj = Instantiate(vOrkanu,Vector3.zero,Quaternion.Euler(0,0,0)) as GameObject;
			zac = zac.GetComponent<nazajSkripta>().nazaj;
			zac.SetActive(false);
		}
		zac = zac.GetComponent<nazajSkripta> ().nazaj = prvi;
		zadnji = zac;
	}
	
	// Update is called once per frame
	void Update () {
		if (InputKey.enableI) {
			if(raca.gameObject.activeSelf && (raca.position.z - transform.position.z < 0.2 || zatakni)){
				transform.position = Vector3.MoveTowards(transform.position,raca.position,speed*5*Time.deltaTime);
				zatakni=true;
			}else if(!zatakni){
				transform.position += Vector3.forward*speed*Time.deltaTime;
			}
		}
		transform.Rotate (0,histrostVrtenja*Time.deltaTime,0);


	}

	void OnTriggerEnter(Collider other) {
		if (other.CompareTag ("raca") || other.CompareTag ("otrok")) {
			/*GameObject game = Instantiate(glavnaRacaVOrkanu,Vector3.zero,Quaternion.Euler(0,0,0)) as GameObject;*/
			if (prvi != null) {
				GameObject game = sestavi (other.gameObject, gameObject);
				game.GetComponent<vOrkanuSkripta>().enable=true;
				//game.transform.position = other.transform.position - game.transform.position;
			}
			//game.transform.parent = transform;



		} else if (other.CompareTag ("drevo") || other.CompareTag ("vozilo")) {
			if (prvi != null) {
				GameObject game = sestavi (other.gameObject, gameObject);
				game.GetComponent<vOrkanuSkripta>().enable=true;
				//game.transform.position = other.transform.position - game.transform.position;
			}
			other.gameObject.SetActive (false);
		}
	}

	GameObject sestavi(GameObject obj, GameObject stars){
		GameObject game = prvi;
		prvi = prvi.GetComponent<nazajSkripta>().nazaj;

		game.GetComponent<vOrkanuSkripta> ().StartOrkan (obj.transform.position,obj.transform.rotation, stars);
		game.SetActive (true);


		if (obj.GetComponent<MeshFilter> ()) {
			game.GetComponent<MeshFilter> ().mesh = obj.GetComponent<MeshFilter> ().mesh;

		}
		if (obj.GetComponent<MeshRenderer> ()) {
			game.GetComponent<MeshRenderer> ().enabled=true;
			game.GetComponent<MeshRenderer> ().material = obj.GetComponent<MeshRenderer> ().material;

		} else {
			game.GetComponent<MeshRenderer> ().enabled=false;
		}

		//game.transform.localScale = obj.transform.localScale;
		for (int i=0; i < obj.transform.childCount; i++) {
			if(prvi != null){
				GameObject otrok = sestavi(obj.transform.GetChild(i).gameObject,game);
				otrok.GetComponent<vOrkanuSkripta>().enable=false;
				otrok.transform.localPosition = obj.transform.GetChild(i).transform.localPosition;
				otrok.transform.localRotation = obj.transform.GetChild(i).transform.localRotation;
				otrok.transform.localScale = obj.transform.GetChild(i).transform.localScale;
				//Debug.Log("delam otroke");
			}
		}

		return game;
	}

	public void Reset(){
		transform.position = zacPoz;
		zatakni = false;
	}
}
