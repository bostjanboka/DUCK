using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MeniSkripta : MonoBehaviour {

	// Use this for initialization
	public static bool stejTocke=false;
	public static bool posodobiLeader = false;
	public GameObject kamera;
	public GameObject meni;
	public GameObject hud;
	public GameObject loose;
	public GameObject signUpCanvas;
	public GameObject leader;

	public Text bestScore;
	public Text Score;
	public Text stRack;
	public Text userRankText;

    public Text bestMenu;
    public Text bestLost;
    public Text scoreLost;
	
	public Text[] imeR;
	public Text[] scoreR;

	public InputField input;

	float tocke;
	float deltaTocke;
	GameObject raca;
	GameObject skladLeader;
	void Awake(){
		hud.SetActive (false);
		loose.SetActive (false);
		deltaTocke = kamera.transform.position.z;
		tocke = 0;
		raca = GameObject.Find ("raca");
	}
	void Start () {
		bestScore.text = PlayerPrefs.GetInt ("score")+"";
        bestMenu.text = "BEST: "+PlayerPrefs.GetInt("score") + "";
    }
	
	// Update is called once per frame
	void Update () {
		stRack.text = RackaSkripta.stRack+" / 10";
		if(stejTocke){
			tocke += (RackaSkripta.stRack / 10f)*(kamera.transform.position.z-deltaTocke);
		}
		deltaTocke = kamera.transform.position.z;

		Score.text = Mathf.RoundToInt (tocke)+"";
		if (leader.activeSelf) {
			if(PlayerPrefs.HasKey("rank"))
				userRankText.text=PlayerPrefs.GetInt("rank")+"";

			if(leaderSkripta.imeR != null && posodobiLeader){
				posodobiLeader=false;
				for(int i=0; i < leaderSkripta.imeR.Length; i++){
					if(leaderSkripta.imeR[i] != null){
						imeR[i].text = leaderSkripta.imeR[i];
						scoreR[i].text = leaderSkripta.scoreR[i];
					}
				}

			}

		}
		else if (Input.GetKey (KeyCode.Escape) && leader.activeSelf) {
			leader.SetActive(false);
		}

	}


	public void play(){
		tocke = 0;
		deltaTocke = kamera.transform.position.z;
		meni.SetActive (false);
		hud.SetActive (true);
		loose.SetActive (false);
		InputKey.enableI = true;
	}

	public void reset(){
		raca.SetActive (true);
		InputKey.enableI = false;
		hud.SetActive (false);
		loose.SetActive (false);
		meni.SetActive (true);
	}

	public void lost(){
		InputKey.enableI = false;
		hud.SetActive (false);
		loose.SetActive (true);
		if (!PlayerPrefs.HasKey ("score") || PlayerPrefs.GetInt ("score") < Mathf.RoundToInt (tocke)) {
			PlayerPrefs.SetInt ("score", Mathf.RoundToInt (tocke));
			leaderSkripta.saveScore=true;
			bestScore.text = Mathf.RoundToInt(tocke)+"";
		}
        kamera.GetComponent<SlediRaciSkripta>().youLostShow();
        bestLost.text = "BEST: "+PlayerPrefs.GetInt("score") + "";
        scoreLost.text = "SCORE: "+Mathf.RoundToInt(tocke);
    }

	public void logIN(){
		if (input.text.Length >= 3) {
			leaderSkripta.userName = input.text;
			leaderSkripta.createUser = true;
			signUpCanvas.SetActive(false);
		}
	}

	public void leaderBoard(){
		if (meni.activeSelf) {
			skladLeader = meni;
		} else {
			skladLeader=loose;
		}
		skladLeader.SetActive (false);
		leader.SetActive (true);
		if (!PlayerPrefs.HasKey ("user")) {
			signUpCanvas.SetActive (true);
		} else {
			leaderSkripta.getTopNRanks=true;
			if(PlayerPrefs.HasKey("score")){
				leaderSkripta.saveScore=true;
			}

		}
	}

	public void zapriLeader(){
		leader.SetActive (false);
		skladLeader.SetActive (true);
	}

	public void getUserRank(){
		leaderSkripta.getUserRank = true;
	}


}
