using UnityEngine;
using System.Collections;

public class NaloziGameSkripta : MonoBehaviour {

    // Use this for initialization
    bool loading = false;
    public GameObject mapCreator;
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
	    if(loading == false)
        {
            loading = true;
            Instantiate(mapCreator);
        }
	}

    public void loadLevel()
    {
        Application.LoadLevel("svetBB");      
    }
}
