using UnityEngine;
using System.Collections;

public class randomVlakSkripta : MonoBehaviour {

    // Use this for initialization
    public GameObject[] vlaki;
	void Start () {
	
	}
	

    public GameObject getRandomVlak()
    {
        return vlaki[Random.Range(0,vlaki.Length)];
    }
}
