using UnityEngine;
using System.Collections;

public class postaviJaske : MonoBehaviour {

    // Use this for initialization
    public GameObject jaskek;
    static GameObject[] jaski;
    static int stevec = 0;
	void Start () {
        jaski = new GameObject[60];
        for(int i=0; i < jaski.Length; i++)
        {
            jaski[i] = Instantiate(jaskek) as GameObject;
        }
	}
	
    static public GameObject getJasek()
    {
        jaski[(stevec++) % jaski.Length].GetComponent<JasekSkripta>().enabled = true;
        jaski[(stevec) % jaski.Length].GetComponent<JasekSkripta>().setEnable(true);
        return jaski[(stevec) % jaski.Length];
    }
}
