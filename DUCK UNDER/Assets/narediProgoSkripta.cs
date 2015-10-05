using UnityEngine;
using System.Collections;

public class narediProgoSkripta : MonoBehaviour {

	// Use this for initialization
	public GameObject spawn;
	public float stevilo;

	Vector3 vec;
	void Start () {
		vec = Vector3.zero;
		for (int i = 0; i < stevilo; i++) {
			Mesh mesh = spawn.GetComponent<MeshFilter> ().sharedMesh;
			Bounds bounds = mesh.bounds;
			vec.x += bounds.size.x * spawn.transform.localScale.x * transform.localScale.x;
			Vector3 pozicija = spawn.transform.position;
			pozicija.x = vec.x - bounds.size.x / 2f * spawn.transform.localScale.x * transform.localScale.x;
			GameObject crta = Instantiate (spawn, Vector3.zero, Quaternion.Euler (0, 0, 0)) as GameObject;
			Vector3 scale = crta.transform.localScale;
			scale.z = transform.localScale.z * crta.transform.localScale.z;
			crta.transform.localScale = scale;
			crta.transform.parent = transform;
			crta.transform.localPosition = pozicija;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
