using UnityEngine;
using System.Collections;

public class narediXavtov : MonoBehaviour {

    // Use this for initialization
    public int x;
    public GameObject avto;
	void Start () {
	    for(int i=0; i < x; i++)
        {
            Instantiate(avto, transform.position + transform.forward * i,transform.rotation);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
