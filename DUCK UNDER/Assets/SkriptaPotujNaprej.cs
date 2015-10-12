using UnityEngine;
using System.Collections;

public class SkriptaPotujNaprej : MonoBehaviour {

    // Use this for initialization
    public Collider[] kolesa;
	public float speed=4;
	public GameObject nazaj;
	public Vector3 pozicija;

	public float size=0;
	public float zamik;


	void Start () {
		Transform sence = transform.FindChild ("SENCE");
		if (sence) {
			if(transform.localEulerAngles.y < 200){
				sence.FindChild("DOL").gameObject.SetActive(false);
			}else{
				sence.FindChild("GOR").gameObject.SetActive(false);
			}
		}
        int i = ++transform.parent.gameObject.GetComponent<izberiSpawnSkripta>().nalozeniAvti;
        if(i == transform.parent.gameObject.GetComponent<izberiSpawnSkripta>().stAvtov)
        {
            RandomCreatorSkripta.nalozeno++;
            gameObject.SetActive(false);
            transform.parent.gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(false);
        }
        
	}
	
	// Update is called once per frame
	void Update () {
		transform.position+= (transform.forward * speed * Time.deltaTime);


	}

	public float vrniZamikPrvi(){
		if (size == 0) {
			BoxCollider colider = gameObject.GetComponent<BoxCollider> ();
			size = Mathf.Abs(colider.size.z);
			zamik = colider.center.z;
		}
		return size/2f + zamik;
	}
	public float vrniZamikZadnji(){
		return size / 2f - zamik;
	}
}
