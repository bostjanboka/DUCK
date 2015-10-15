using UnityEngine;
using System.Collections;

public class SPLASHskripta : MonoBehaviour {

    public Texture2D zelena;
    Texture2D zelena2;

    void Start () {
        //PlayVideo();
        zelena2 = Resources.Load("cipresa") as Texture2D;
        StartCoroutine("PlayVideo");
    }
	
	void Update () {
        
	}

    IEnumerator PlayVideo()
    {

        yield return new WaitForSeconds(1);
        zelena = zelena2;
    }
    void OnGUI()
    {
        GUI.DrawTexture(new Rect(Screen.width / 2, 0, 100, 10), zelena);
    }
}