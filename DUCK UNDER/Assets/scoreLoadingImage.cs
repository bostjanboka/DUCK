using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class scoreLoadingImage : MonoBehaviour {

    public Image slika;
    public GameObject Racka;
    public RackaSkripta skript;
    public Text scoreText;
    public Text multiplayer;
    public static int score;


	void Start ()
    {
        slika = GetComponent<Image>();
        skript = Racka.GetComponent<RackaSkripta>();
    }
	
	void Update ()
    {
        int stRack = RackaSkripta.stRack;
        if(slika.fillAmount == 1f)
        {
            slika.fillAmount = 0f;
            score++;
        }
        else
        {
            slika.fillAmount += 0.0025f * stRack;
        }
        scoreText.text = score + "";
        multiplayer.text = "x" + stRack;

    }
}
