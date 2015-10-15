using UnityEngine;
using System.Collections;

public class skriptazaVideo : MonoBehaviour {

    public Texture mTex;

    Object[] nizSlik;

    public static bool done = false;
 
    void Start()
    {
        StartCoroutine( PlayVideo(25, "SPLASHzelena"));
    }

    void Update()
    {

    }

    IEnumerator PlayVideo(int fps, string path)
    {
        int i  = 0;
        nizSlik = Resources.LoadAll(path, typeof(Texture));
        while (!done)
        {
            mTex = nizSlik[i] as Texture2D;
            i++;
            i = i % nizSlik.Length;
            yield return new WaitForSeconds(1 / fps);
        }
    }

    void OnGUI()
    {
        GUI.DrawTexture(new Rect(Screen.width / 2, 0, 100, 10), mTex);//480x360 is size of game in PlayerSettings.
                                                                        //check resolution by going to Edit>Project Settings>Player and look under Resolution
    }
}
