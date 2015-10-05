using UnityEngine;
using System.Collections;

public class RandomVoziloSkripta : MonoBehaviour {



	public GameObject[] tabela;

    public static bool[] kovanciBool;
	
	void Awake(){
        kovanciBool = new bool[20];
        kovanciBool[0] = true;
        for(int i=1; i < 20; i++)
        {
            kovanciBool[i] = false;
        }
	}
	void Start () {



	}
	
	public GameObject vrniVozilo(){
		return tabela[Random.Range(0,tabela.Length)];
	}

    public static bool vrniRandomKovanec()
    {
        return kovanciBool[Random.Range(0, 20)];
    }
}
