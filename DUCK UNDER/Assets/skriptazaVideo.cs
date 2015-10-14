using UnityEngine;
using System.Collections;

public class skriptazaVideo : MonoBehaviour {

    public Texture2D mTex;
 
    void Start()
    {
        PlayVideo(30, "LaytProductsSplash", 4, "MainMenu");
    }

    void Update()
    {

    }

    IEnumerator PlayVideo(int fps, string path, int numberDigits, string levelAfter)
    {
        int i  = 0;
        bool done = false;
        int allImages = Resources.LoadAll(path,  typeof( Texture2D)).Length - 1;
        print(allImages.ToString());
        while (!done)
        {
            string digits="";
            if (i > allImages)
            {
                done = true;
                break;
            }
            if (i < 10 && i >= 0){
                for (int w = 0; w < numberDigits - 1; w++){
                    digits = digits + "0";
                }
                digits = digits + i;
            }
            if (i < 100 && i >= 10){
                for (int x = 0; x < numberDigits - 2; x++){
                    digits = digits + "0";
                }
                digits = digits + i;
            }
            if (i < 1000 && i >= 100){
                for (int y = 0; y < numberDigits - 3; y++){
                    digits = digits + "0";
                }
                digits = digits + i;
            }
            if (i < 10000 && i >= 1000){
                for (int z = 0; z < numberDigits - 4; z++){
                    digits = digits + "0";
                }
                digits = digits + i;
            }
            string currentFile = path + "/" + path + digits;
            print(currentFile);
            Texture2D videoTexture = Resources.Load(currentFile) as Texture2D;

            mTex = videoTexture;
            i++;
            yield return new WaitForSeconds(1 / fps);
        }
        Application.LoadLevel(levelAfter);
    }

    void OnGUI()
    {
        GUI.DrawTexture(new Rect(0, 0, 480, 360), mTex);//480x360 is size of game in PlayerSettings.
                                                    //check resolution by going to Edit>Project Settings>Player and look under Resolution
    }
}
