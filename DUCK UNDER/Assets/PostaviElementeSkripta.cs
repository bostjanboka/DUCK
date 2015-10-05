using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PostaviElementeSkripta : MonoBehaviour {

	// Use this for initialization
	public GameObject jablana;
	public GameObject drevo;
	public GameObject smreka;

	public GameObject nazaj;
	Bounds bounds;

	GameObject[] tabela;
	void Start () {
		tabela = new GameObject[3];
		tabela [0] = jablana;
		tabela [1] = drevo;
		tabela [2] = smreka;
		Mesh mesh = GetComponent<MeshFilter>().sharedMesh;
		bounds = mesh.bounds;
		Bounds jabkaSize = jablana.GetComponent<MeshFilter> ().sharedMesh.bounds;

		int velikostX = (int)((bounds.size.x * transform.localScale.x) / (jabkaSize.size.x * jablana.transform.localScale.x));
		int velikostZ = (int)((bounds.size.z * transform.localScale.z) / (jabkaSize.size.z * jablana.transform.localScale.z));

		float zamikX = transform.position.x - (bounds.size.x * transform.localScale.x / 2);
		float zamikZ = transform.position.z - (bounds.size.z * transform.localScale.z / 2);

		for (int i=0; i < 50; i++) {
			float x = Random.Range(0,velikostX)*jabkaSize.size.x * jablana.transform.localScale.x;
			float z = Random.Range(0,velikostZ)*jabkaSize.size.z * jablana.transform.localScale.z;
			GameObject otrok = Instantiate(tabela[Random.Range(0,tabela.Length)],new Vector3(x+zamikX,0,z+zamikZ), Quaternion.Euler(0,0,0)) as GameObject;
			otrok.transform.SetParent(transform);
			
		}
		gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
