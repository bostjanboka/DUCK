using UnityEngine;
using System.Collections;

public class AudioSkripta : MonoBehaviour {

	// Use this for initialization
	GameObject raca;
	public AudioClip povozena;
	AudioSource source;
	void Start () {
		raca = GameObject.Find ("raca");
		source = gameObject.GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = raca.transform.position;
		transform.rotation = raca.transform.rotation;
	}

	public void povozi(){
		if (!source.isPlaying) {
			source.clip = povozena;
			source.Play();
		}
	}
}
