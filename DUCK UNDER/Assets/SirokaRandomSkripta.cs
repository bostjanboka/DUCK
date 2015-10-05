using UnityEngine;
using System.Collections;

public class SirokaRandomSkripta : MonoBehaviour {

	// Use this for initialization
	public GameObject r1;
	public GameObject r2;
	public GameObject r3;
	public GameObject r4;
	public GameObject r5;
	public GameObject r6;
	public GameObject r7;
	public GameObject r8;
	public GameObject r9;

	GameObject[] tabela;
	void Start () {
		tabela = new GameObject[9];
		tabela [0] = r1;
		tabela [1] = r2;
		tabela [2] = r3;
		tabela [3] = r4;
		tabela [4] = r5;
		tabela [5] = r6;
		tabela [6] = r7;
		tabela [7] = r8;
		tabela [8] = r9;
		Vector3 poz = Vector3.zero;
		for (int i=0; i < 4; i++) {
			GameObject zac = Instantiate(tabela[Random.Range(0,9)],Vector3.zero,Quaternion.Euler(0,0,0)) as GameObject;
			Transform rot = zac.transform.FindChild("rot");
			rot.rotation = Quaternion.Euler(0,Random.Range(0,4)*90,0);
			zac.transform.parent = transform;
			Mesh mesh = zac.GetComponent<MeshFilter>().sharedMesh;
			Bounds bounds = mesh.bounds;
			poz.x = i*bounds.size.x * zac.transform.localScale.x - bounds.size.x * zac.transform.localScale.x;
			zac.transform.localPosition = poz;
			//zac.GetComponent<SpawnRackeSkripta>().postavi();
		}
		gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void reset(){
		SpawnRackeSkripta[] comp = transform.GetComponentsInChildren<SpawnRackeSkripta> ();
		for (int i=0; i < comp.Length; i++) {
			comp[i].pocisti();
		}
	}

	public void postavi(){
		SpawnRackeSkripta[] comp = transform.GetComponentsInChildren<SpawnRackeSkripta> ();
		for (int i=0; i < 2; i++) {
			comp[i].postavi();
		}
	}
}
