using UnityEngine;
using System.Collections;

public class InputKey : MonoBehaviour {

	// Use this for initialization
	public AudioClip quack;
	public AudioClip quack2;

	static public bool w;
	static public bool a;
	static public bool s;
	static public bool d;

	public GameObject instTocka;
	public static GameObject tocka;

	public static bool enableI;

	Vector3 racaPos;

	void Awake(){
		enableI = false;
	}
	void Start () {
		tocka = Instantiate (instTocka, Vector3.zero, Quaternion.Euler (90, 0, 0)) as GameObject;
		tocka.SetActive (false);
		racaPos = GameObject.Find ("raca").transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (enableI) {
			w = Input.GetKey ("w");

			a = Input.GetKey ("a");

			s = Input.GetKey ("s");

			d = Input.GetKey ("d");

			foreach (Touch touch in Input.touches) {
				if (touch.phase.Equals (TouchPhase.Began)) {
					Ray ray = SlediRaciSkripta.kamera.ScreenPointToRay (Input.mousePosition);

					RaycastHit[] hit;
					hit = Physics.RaycastAll (ray);
					for (int i=0; i < hit.Length; i++) {
						if (hit [i].point != null && hit [i].collider.gameObject.CompareTag ("teren") || hit [i].collider.gameObject.CompareTag ("tla") || hit [i].collider.gameObject.CompareTag ("voda")) {
							tocka.transform.position = hit [i].point;
                            tocka.SetActive(false);
							tocka.SetActive(true);
							Zvok();
						}
					}

				}
			}

			if (Input.GetMouseButtonDown (0)) {
				Ray ray = SlediRaciSkripta.kamera.ScreenPointToRay (Input.mousePosition);
				RaycastHit[] hit;
				hit = Physics.RaycastAll (ray);
				for (int i=0; i < hit.Length; i++) {
					if (hit [i].point != null && hit [i].collider.gameObject.CompareTag ("teren") || hit [i].collider.gameObject.CompareTag ("tla") || hit [i].collider.gameObject.CompareTag ("voda")) {
						tocka.transform.position = hit [i].point;
                        tocka.SetActive(false);
                        tocka.SetActive(true);
						Zvok();
					}
				}


			}

            
        }
	}

	public void Zvok(){
		if (Random.Range (0, 100) < 50) {
			if(Random.Range(0,100) < 20){
				AudioSource.PlayClipAtPoint(quack2,racaPos);
			}else{
				AudioSource.PlayClipAtPoint(quack,racaPos);
			}
		}
	}
}
