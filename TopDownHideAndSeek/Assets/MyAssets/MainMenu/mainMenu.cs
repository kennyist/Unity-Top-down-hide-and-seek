using UnityEngine;
using System.Collections;

public class mainMenu : MonoBehaviour {
	
	private scoreBoard top10S = new scoreBoard();
	private scoreBoard top10h = new scoreBoard();
	public GUISkin skin;
	
	private StaticVars statvr = new StaticVars();
	
	private string hiderName = "";
	private string seekerName = "";
	
	private bool nameMenu = false;
	private bool help = false;
	
	private Vector2 helpScrollPos;
	
	void Start () {
		StartCoroutine(top10S.getTop10(true));
		StartCoroutine(top10h.getTop10(false));
	}
	
	void OnGUI(){
		GUI.skin = skin;
		
		// MENU
		
		GUI.BeginGroup(new Rect(Screen.width * 0.05f,10, Screen.width * 0.9f, Screen.height  * 0.1f));
		GUILayout.BeginArea(new Rect(0,0,Screen.width * 0.9f, Screen.height  * 0.1f));
		GUILayout.BeginHorizontal();
		
		if(GUILayout.Button("Start Game")){
			nameMenu = !nameMenu;
			help = false;
		}
		
		if(GUILayout.Button("Help")){
			help = !help;
			nameMenu = false;
		}
		
		if(GUILayout.Button("Settings")){
		}
		
		if(GUILayout.Button("Quit")){
			Application.Quit();
		}
		
		GUILayout.EndHorizontal();
		GUILayout.EndArea();
		GUI.EndGroup();
		
		
		// HELP MENU
		
		if(help){
			GUILayout.BeginArea(new Rect(Screen.width * 0.25f,Screen.height  * 0.1f, Screen.width * 0.65f, Screen.height  * 0.35f));
			helpScrollPos = GUILayout.BeginScrollView(helpScrollPos,"Box");
			//
			
			GUILayout.Label("About:");
			GUILayout.Label("This is a game of hide and seek, But with the use of traps and othre systems. The Hider (left sceen, Green) has a 30 second warmump time to hide or move to another area and has basic traps to help know where the seeker is or confuse the seeker, The hider can win by multipul ways such as: Round time runs out, Seeker runs out of scans.");
			GUILayout.Label("The seeker (right screen, Red) is a fast mover but has resitricted visability. The seeker has use of traps that effect the Hider, such as a flashbang trap, and ones that effect objects such as explosion push. The seeker can only win by colliding with the Hider, But its not that simple, The hider has to be visable to do so. To make the hider visable the Seeker has to use the scanner, If the hider is in range they will become visable for 10 seconds, But you also become visable to them aswell.");
			GUILayout.Space(10);
			
			GUILayout.Label("Controls:");
			GUILayout.BeginHorizontal();
			
			GUILayout.BeginVertical();
			GUILayout.Label("-- Hider --");
			GUILayout.Label("WASD - Move");
			GUILayout.Label("Q - Weapon, warning system spam");
			GUILayout.EndVertical();
				
			GUILayout.BeginVertical();
			GUILayout.Label("-- Seeker --");
			GUILayout.Label("Arrow keys - Move");
			GUILayout.Label("1 - Weapon, FlashBang trap");
			GUILayout.Label("2 - Weapon, Scanner");
			GUILayout.Label("3 - Weapon, Object push explosion");
			GUILayout.EndVertical();
			
			GUILayout.EndHorizontal();	
			
			GUILayout.Space(10);
			
			GUILayout.Label("Credits:");
			GUILayout.Label("Sounds: Julien Nicolas, Dheming, FreeSound.org");
			
			//
			GUILayout.EndScrollView();
			GUILayout.EndArea();
		}
		
		// CREDITS
		
		GUI.BeginGroup(new Rect(Screen.width * 0.05f,100, Screen.width * 0.3f, Screen.height  * 0.3f));
		GUILayout.BeginVertical();
		GUILayout.Label("Tristan 'Kennyist' Cunningham");
		GUILayout.Label("www.tristanjc.com");
		GUILayout.Label("------------------");
		GUILayout.Label("GabberDaan");
		GUILayout.Label("Gameplay & Creative input");
		GUILayout.EndVertical();
		GUI.EndGroup();
		
		// ENTER NAME AND START BUTTON
		
		if(nameMenu){
			GUI.Box(new Rect(Screen.width * 0.3f,Screen.height  * 0.2f, Screen.width * 0.4f, Screen.height  * 0.2f),"");
			GUI.BeginGroup(new Rect(Screen.width * 0.31f,Screen.height  * 0.23f, Screen.width * 0.4f, Screen.height  * 0.2f));
			GUILayout.BeginArea(new Rect(0,0,Screen.width * 0.3f, Screen.height  * 0.1f));
			GUILayout.BeginVertical();
			GUILayout.BeginHorizontal();
			GUILayout.Label("Hider Name: ");
			hiderName = GUILayout.TextField(hiderName, GUILayout.Width(200));
			GUILayout.EndArea();
			GUILayout.BeginHorizontal();
			GUILayout.Label("Seeker Name: ");
			seekerName = GUILayout.TextField(seekerName, GUILayout.Width(200));
			GUILayout.EndHorizontal();
			GUILayout.BeginArea(new Rect(Screen.width * 0.15f,50,100,25));
			if(GUILayout.Button("Begin")){
				statvr.setHiderName(hiderName);
				statvr.setSeekerName(seekerName);
				Application.LoadLevel("1");
			}
			GUILayout.EndArea();
			GUILayout.EndVertical();
			GUILayout.EndArea();
		}
		
		// SCORES
		
		GUI.BeginGroup(new Rect(Screen.width * 0.1f,Screen.height / 2, Screen.width * 0.8f, Screen.height  * 0.5f));
		
		
		GUI.Box(new Rect(0,0,Screen.width * 0.4f,Screen.height  * 0.5f),"High scores: hider");
		GUILayout.BeginArea(new Rect(10f,25f,(Screen.width  * 0.4f)- 20f, (Screen.height * 0.5f) - 40f));
		scores(top10h.GetTop10STR());
		GUILayout.EndArea();
		
		
		GUI.Box(new Rect(Screen.width  * 0.4f,0,Screen.width  * 0.4f,Screen.height  * 0.5f),"High scores: Seeker");
		GUILayout.BeginArea(new Rect((Screen.width  * 0.4f)+10f,25f,(Screen.width  * 0.4f)- 20f, (Screen.height * 0.5f) - 40f));
		scores(top10S.GetTop10STR());
		GUILayout.EndArea();
		
		GUI.EndGroup();
	}
	
	private void scores(string scores){
		if(scores != null){
			float win = Screen.width * 0.4f;
			float w1 = win * 0.4f, w2 = win * 0.1f, w3 = win * 0.1f, w4 = win * 0.4f;
			
			GUILayout.BeginHorizontal();
			GUILayout.Label("Name", GUILayout.Width(w1));
			GUILayout.Label("Score", GUILayout.Width(w2));
			GUILayout.Label("Country", GUILayout.Width(w3));
			GUILayout.Label("Oponent", GUILayout.Width(w4));
			GUILayout.EndHorizontal();
			
			foreach(string line in scores.Split("\n"[0])){
				string[] fields = line.Split("\t"[0]);
				if(fields.Length>=3){
					GUILayout.BeginHorizontal();
					GUILayout.Label(fields[0], GUILayout.Width(w1));
					GUILayout.Label(fields[1], GUILayout.Width(w2));
					GUILayout.Label(fields[2], GUILayout.Width(w3));
					GUILayout.Label(fields[3], GUILayout.Width(w4));
					GUILayout.EndHorizontal();
				}
			}
		} else {
			GUILayout.Label("Loading Highscores");			
		}
	}
}
