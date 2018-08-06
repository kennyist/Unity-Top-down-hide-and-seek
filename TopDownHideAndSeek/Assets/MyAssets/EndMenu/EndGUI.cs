using UnityEngine;
using System.Collections;

public class EndGUI : MonoBehaviour {
	
	private scoreBoard scrSkr = new scoreBoard();
	private scoreBoard scrHdr = new scoreBoard();
	private StaticVars statvr = new StaticVars();
	
	public GUISkin skin;

	void Start () {
		StartCoroutine(scrHdr.postScore(statvr.getHiderName(),statvr.GetScore(false),statvr.getSeekerName(),false));
		StartCoroutine(scrSkr.postScore(statvr.getSeekerName(),statvr.GetScore(true),statvr.getHiderName(),true));
	}
	
	void OnGUI(){
		GUI.skin = skin;
		
		GUI.Label(new Rect(0,0,Screen.width,100), statvr.GetWinner() + " is the winner!");
		
		if(!scrHdr.isLoading()){
			
			GUI.Label(new Rect(0,100,Screen.width,100),statvr.getHiderName() + " scored " + statvr.GetScore(false) + " and is placed:","Small");
			GUI.Label(new Rect(0,170,Screen.width,100),scrHdr.GetPlacement());
			GUI.Label(new Rect(0,220,Screen.width,100),"In the world","Small");
			
		} else {
			GUI.Label(new Rect(0,150,Screen.width,100),"Posting and Loading hider score...");
		}
		
		if(!scrSkr.isLoading()){
			
			GUI.Label(new Rect(0,300,Screen.width,100),statvr.getSeekerName() + " scored " + statvr.GetScore(true) + " and is placed:","Small");
			GUI.Label(new Rect(0,370,Screen.width,100),scrSkr.GetPlacement());
			GUI.Label(new Rect(0,420,Screen.width,100),"In the world","Small");
			
		} else {
			GUI.Label(new Rect(0,350,Screen.width,100),"Posting and Loading seeker score...");
		}
		
		if(GUI.Button(new Rect((Screen.width / 2) - 100, Screen.height - 100,200,50),"Return to Menu")){
			Debug.Log("pressed");
			Application.LoadLevel(0);	
			statvr.Reset();
		}
	}
}
