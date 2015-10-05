using UnityEngine;
using System.Collections;

public class SencaRotacijaSkripta : MonoBehaviour {

	// Use this for initialization
	public static float rot=0;
	void Start () {
		transform.rotation = Quaternion.Euler (0,rot,0);
	}

}
