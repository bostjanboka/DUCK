using UnityEngine;
using System.Collections;

public class postaviNazajSkripta : MonoBehaviour {

    // Use this for initialization
    Vector3 zacPoz;
    Vector3 zamik;
    GameObject kameraPoz;
	void Start () {
        zacPoz = transform.position;
        kameraPoz = GameObject.Find("Main Camera");

        zamik = kameraPoz.transform.position - zacPoz;
	}

    void Update()
    {
        transform.position = kameraPoz.transform.position - zamik;

    }

    public void Reset()
    {
        transform.position = zacPoz;
    }
	

}
