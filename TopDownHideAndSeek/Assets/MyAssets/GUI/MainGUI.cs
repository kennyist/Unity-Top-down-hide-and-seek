using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MainGUI : MonoBehaviour {
	
	public Texture2D tempMiddle;
	public float gameRoundTime;
	public SeekerControls seekerControls;
	public SeekerShop seekerShop;
	public GUISkin skin;
	
	private StaticVars statvr = new StaticVars();
	
	private GameTimeManager gameTime;
	
	private ScoreManager scoreMngr = new ScoreManager();
	
	private List<string> Stally;
	private List<string> Htally;
	private bool tallyed = false;

	private bool seekerMove = false;
	private float outOfGoldTime;
	private bool outOfGoldBool = true;
	
	void Start () {
		seekerControls.enabled = false;
		seekerShop.enabled = false;
		gameTime = new GameTimeManager(15,gameRoundTime,10);
		gameTime.startGame();
	}
	
	void Update(){
		gameTime.SetTime(gameTime.GetTime() - Time.deltaTime);

		if(gameTime.GetStateInt() == 1 && !seekerMove){
			seekerMove = true;
			seekerControls.enabled = true;
			seekerShop.enabled = true;
		}

		if(gameTime.GetStateInt() == 2 && !tallyed){
			EndGame(false);
		}
		
		if(gameTime.GetStateInt() == 3){
			Application.LoadLevel(2);	
		}

		if(statvr.GetActiveTraps() == 0 && statvr.GetGold(true) < 20){
			if(outOfGoldBool){
				outOfGoldBool = false;
				outOfGoldTime = Time.time + 10f;
			}

			if(Time.time > outOfGoldTime && !outOfGoldBool){
				EndGame(false);
				seekerControls.enabled = false;
			}
		}
	}
	
	void OnGUI(){
		GUI.skin = skin;

		GUI.DrawTexture(new Rect((Screen.width / 2) - 5, 0, 10, Screen.height), tempMiddle);

		if(!seekerMove){
			GUILayout.BeginArea(new Rect(0,(Screen.height/2) - 50,Screen.width / 2,Screen.height / 2));
			GUILayout.Label("Cant move during warmup","warmup");
			GUILayout.EndArea();
		}
		
		if(tallyed){
			
			if(statvr.GetWinner() == statvr.getHiderName()){
				GUILayout.BeginArea(new Rect(0,0,Screen.width,400));
				GUILayout.Label("WINNER","winnerR");
				GUILayout.EndArea();
			}
			
			GUILayout.BeginArea(new Rect((Screen.width / 2) + 30,50,(Screen.width / 2) - 60, Screen.height - 50));
			GUILayout.BeginVertical("box");
			GUILayout.Label("Your score breakdown");
			
			foreach(string tally in Htally){	
				GUILayout.Label(tally);
			}
			
			GUILayout.Label("Total you scored: " + scoreMngr.GetScore(false));
			GUILayout.EndVertical();
			GUILayout.EndArea();
			
			// =======================
			
			if(statvr.GetWinner() == statvr.getSeekerName()){
				GUILayout.BeginArea(new Rect(0,0,Screen.width,400));
				GUILayout.Label("WINNER","winnerL");
				GUILayout.EndArea();
			}
			
			GUILayout.BeginArea(new Rect(30,50,(Screen.width / 2) - 60, Screen.height - 50));
			GUILayout.BeginVertical("box");
			GUILayout.Label("Your score breakdown");
			
			foreach(string tally in Stally){	
				GUILayout.Label(tally);
			}
			
			GUILayout.Label("Total you scored: " + scoreMngr.GetScore(true));
			GUILayout.EndVertical();
			GUILayout.EndArea();

			GUILayout.BeginArea(new Rect(0,0,Screen.width,400));
			GUILayout.Label(gameTime.GetTimeString(),"Timer");
			GUILayout.EndArea();
			
		} else {
			GUILayout.BeginArea(new Rect(0,0,Screen.width,400));
			if(gameTime.GetStateInt() < 2){
				GUILayout.Label(gameTime.GetStateString() +" Time: "+ gameTime.GetTimeString(),"Timer");
			} else {
				GUILayout.Label(gameTime.GetStateString(),"Timer");
			}
			GUILayout.EndArea();

			GUI.Box(new Rect(Screen.width - 170,Screen.height - 100,150,20), "Hider Gold: "+ statvr.GetGold(false));
			GUI.Box(new Rect(20,Screen.height - 100,150,20), "Seeker Gold: "+ statvr.GetGold(true));
		}
	}
	
	public void EndGame(bool didSeekerWin){
		if(didSeekerWin){
			statvr.SetWinner(statvr.getSeekerName());	
		} else {
			statvr.SetWinner(statvr.getHiderName());
		}
		gameTime.End();
		Stally = scoreMngr.GetTally(true,didSeekerWin);
		Htally = scoreMngr.GetTally(false,didSeekerWin);
		tallyed = true;
	}
}
