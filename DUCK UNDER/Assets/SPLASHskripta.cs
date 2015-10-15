using UnityEngine;
using System.Collections;

public class SPLASHskripta : MonoBehaviour {

    public Texture2D zelena;

	void Start () {
        PlayVideo();
	}
	
	void Update () {
        
	}

    IEnumerator PlayVideo()
    {


        Texture2D zelena = Resources.Load("cipresa") as Texture2D;
        
        
        yield return new WaitForSeconds(1);
    }
    void OnGUI()
    {
        GUI.DrawTexture(new Rect(Screen.width / 2, 0, 100, 10), zelena);
    }
}