using UnityEngine;
using System.Collections;

public class IzberiSencoSkripta : MonoBehaviour {

	// Use this for initialization


	void Start () {
		int rot;
		Transform parent = transform;
		while(!parent.parent.name.Equals("rot")){
			parent = parent.parent;
		}
		parent = parent.parent;
		rot = Mathf.RoundToInt((SencaRotacijaSkripta.rot + parent.localRotation.eulerAngles.y) / 90);
		rot = rot % 4;

		for (int i=0; i < transform.childCount; i++) {
			if(!transform.GetChild(i).name.Equals(rot+"")){
				transform.GetChild(i).gameObject.SetActive(false);
			}

		}

	}
	

}
