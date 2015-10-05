using UnityEngine;
using System.Collections;

public class KovanecSkripta : MonoBehaviour {

    // Use this for initialization
    GameObject animacija;
    Animator ani;
    AudioSource k;
	void Start () {
        animacija = transform.parent.FindChild("COIN točke").gameObject;
        animacija.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {

	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Equals("raca"))
        {

            animacija.SetActive(true);
            animacija.GetComponent<AudioSource>().Play();
            gameObject.SetActive(false);
        }
    }
}
