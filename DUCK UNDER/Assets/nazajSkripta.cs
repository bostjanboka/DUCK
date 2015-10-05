using UnityEngine;
using System.Collections;

public class nazajSkripta : MonoBehaviour {

	// Use this for initialization
	public GameObject nazaj;

	public string id;

    public bool izbrisana = true;

	void Start(){
		//gameObject.SetActive (false);
        if(id.Equals("trava") || id.Equals("crte"))
        {
            gameObject.SetActive(false);
        }

	}

    
}
