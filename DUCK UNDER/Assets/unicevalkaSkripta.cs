using UnityEngine;
using System.Collections;

public class unicevalkaSkripta : MonoBehaviour {

	// Use this for initialization
    public RandomCreatorSkripta mapCreator;
    
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

   

    public void pobrisiZadnjega(GameObject objekt)
    {
        mapCreator.zaIzbrisatObjekt = objekt;
    }

    public void pobrisiZadnjegaZ(GameObject objekt)
    {
        mapCreator.zaIzbrisatObjektZ = objekt;
    }
}
