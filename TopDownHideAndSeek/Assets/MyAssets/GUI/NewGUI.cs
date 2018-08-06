using UnityEngine;
using System.Collections;

public class NewGUI : MonoBehaviour {
	
	public GameObject splitScreenOBJ;
	public GameObject lanOBJ;
	public GameObject onlineOBJ;
	public GameObject highScoreBoard;
	GameObject[] playOBJs = new GameObject[3];
	
	scoreBoard scoreBoard = new scoreBoard();
	public Material scoreBoardTexture;
	public Texture2D loadingMaterial;
	
	public GUISkin skin;
	
	private StaticVars statvr = new StaticVars();
	
	private string hiderName = "";
	private string seekerName = "";
	
	// --- Main
	
	string[] mainOptions = new string[6];
	int selectedMain = 0;
	bool isMain = true;
	float mainOptionsX = 0;
	
	// --- Play
	
	string[] playOptions = new string[4];
	int selectedPlay = 0;
	bool isPlay = false;
	float playOptionsX;
	
	// --- Subplay / SplitScreen
	
	string[] SplitOptions = new string[4];
	int selectedSplit = 0;
	bool isSplit = false;
	float splitOptionsX;
	float pauseTime = 0;
	bool enableOverRideKeys = true;
	
	// --- Help
	
	string[] helpOptions = new string[6];
	int selectedHelp = 0;
	bool isHelp = false;
	float helpOptionsX = -320;

	public Texture2D seekerControls;
	public Texture2D hiderControls;
	public Texture2D weapons;
	
	// --- help / about
	
	bool isAbout = false;
	string aboutTextOne = "This in a basic explination is an hide and seek game. The seeker (red, Left side) has to find and capture the hider (Green, Right side), But its not as simple as going to the hider because the hider is invisable to the seeker (and the other way around). The seeker has to deploy a scanner, If the hider touches the range of it they beomce visable, then all the seeker has to do is collider with the hider.";
	string aboutTextTwo = "Both players have weapons, Some shared some different. The seeker weapons are there to help find the hider where as the hider weapons are for distracting. You both get a set ammount of gold, If your deployed weapon gets hit by the other player you get a rebate. This does lead to another way to loose for the seeker, As the scanner costs gold, Running out of gold you will be unable to capture the hider so the game ends.";
	
	// --- help / controls
	
	bool isSControls = false;
	bool isHControls = false;
	bool isWeapons = false;
	
	// --- help / credits
	
	bool isCredits = false;
	
	// --- high scores
	
	string[] highSOptions = new string[3];
	int selectedHighS = 0;
	bool isHighS = false;
	float highSOptionsX = -320;
	
	// --- settings

	void Start () {
		Screen.showCursor = false;
		Screen.lockCursor = false;
		
		playOBJs[0] = splitScreenOBJ;
		playOBJs[1] = lanOBJ;
		playOBJs[2] = onlineOBJ;
		
		mainOptions[0] = "Play";
		mainOptions[1] = "Help";
		mainOptions[2] = "High Scores";
		mainOptions[3] = "Create";
		mainOptions[4] = "Settings";
		mainOptions[5] = "Exit";
		
		playOptions[0] = "Return";
		playOptions[1] = "Split";
		playOptions[2] = "Local";
		playOptions[3] = "Online";
		
		SplitOptions[0] = "Return";
		SplitOptions[1] = "Hider";
		SplitOptions[2] = "Seeker";
		SplitOptions[3] = "Begin";
		
		helpOptions[0] = "Return";
		helpOptions[1] = "About";
		helpOptions[2] = "SControls";
		helpOptions[3] = "HControls";
		helpOptions[4] = "Weapons";
		helpOptions[5] = "Credits";
		
		highSOptions[0] = "Return";
		highSOptions[1] = "Seeker";
		highSOptions[2] = "Hider";
		
		StartCoroutine(scoreBoard.getTextTestStart(true));
	}
	
	// ========================== Methods ============================== //
	
	int menuSelection(string[] menuItems, int selectedItem, string direction){
		if(direction == "up"){
			if(selectedItem == 0){
				selectedItem = menuItems.Length - 1;
			} else {
				selectedItem -= 1;
			}
		}
		
		if(direction == "down"){
			if(selectedItem == menuItems.Length - 1){
				selectedItem = 0;
			} else {
				selectedItem += 1;
			}
		}
		
		return selectedItem; 
	}
	
	IEnumerator swapMenus(string current, string next){
		
		float pInT = 0f;
		float duration = 0.5f;
		
		switch(current)
		{
			case "main":
				pInT = 0f;
				while(pInT <= duration){
					mainOptionsX = Mathf.Lerp(0,-320, pInT / duration);
					pInT += Time.deltaTime;
					yield return 0;
				}
			
				isMain = false;
			break;
			
			case "play":
				pInT = 0f;
				while(pInT <= duration){
					playOptionsX = Mathf.Lerp(0,-320, pInT / duration);
					pInT += Time.deltaTime;
					yield return 0;
				}
				isPlay = false;
			break;
			
			case "split":
				pInT = 0f;
				while(pInT <= duration){
					splitOptionsX = Mathf.Lerp(0,-320, pInT / duration);
					pInT += Time.deltaTime;
					yield return 0;
				}
				isSplit = false;
			break;
			
			case "help":
				pInT = 0f;
				while(pInT <= duration){
					helpOptionsX = Mathf.Lerp(0,-320, pInT / duration);
					pInT += Time.deltaTime;
					yield return 0;
				}
				isHelp = false;
			break;
			
			case "highS":
				pInT = 0f;
				while(pInT <= duration){
					highSOptionsX = Mathf.Lerp(0,-320, pInT / duration);
					pInT += Time.deltaTime;
					yield return 0;
				}
				isHighS = false;
			break;
			
		}
		
		
		switch(next)
		{
			case "main":
			
				isMain = true;
				
				pInT = 0f;
				while(pInT <= duration){
					mainOptionsX = Mathf.Lerp(-320,0, pInT / duration);
					pInT += Time.deltaTime;
					yield return 0;
				}
			break;
			
			case "play":
			
				isPlay = true;
			
				pInT = 0f;
				while(pInT <= duration){
					playOptionsX = Mathf.Lerp(-320,0, pInT / duration);
					pInT += Time.deltaTime;
					yield return 0;
				}
			break;
			
			case "split":
			
				isSplit = true;
			
				pInT = 0f;
				while(pInT <= duration){
					splitOptionsX = Mathf.Lerp(-320,0, pInT / duration);
					pInT += Time.deltaTime;
					yield return 0;
				}
			break;
			
			case "help":
			
				isHelp = true;
			
				pInT = 0f;
				while(pInT <= duration){
					helpOptionsX = Mathf.Lerp(-320,0, pInT / duration);
					pInT += Time.deltaTime;
					yield return 0;
				}
			break;
			
			case "highS":
			
				isHighS = true;
			
				pInT = 0f;
				while(pInT <= duration){
					highSOptionsX = Mathf.Lerp(-320,0, pInT / duration);
					pInT += Time.deltaTime;
					yield return 0;
				}
			break;
		}
		
		
		
		
		yield return 0;
	}
	
	// ========================== Update =============================== //
	
	void Update () {
		
		if(scoreBoard.isLoading()){
			scoreBoardTexture.mainTexture = loadingMaterial;
		} else {
			scoreBoardTexture.mainTexture = scoreBoard.returnTextTest();
		}
		
		foreach(GameObject obj in playOBJs){
			obj.renderer.enabled = false;
		}
		if(isPlay || isSplit){
			if(selectedPlay == 0 || selectedPlay == 1){
				playOBJs[0].renderer.enabled = true;
			} else {
				playOBJs[selectedPlay - 1].renderer.enabled = true;
			}
		}
		
		if(isHighS){
			highScoreBoard.renderer.enabled = true;	
		} else {
			highScoreBoard.renderer.enabled = false;	
		}
		
		// ==========================
		
		if(Time.time > pauseTime){
			enableOverRideKeys = true;	
		}
		
		Debug.Log(selectedSplit);
		
		// ==========================	
		
		if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)){
			if(isMain){
				selectedMain = menuSelection(mainOptions, selectedMain, "up");
			}
			
			if(isHelp){
				selectedHelp = menuSelection(helpOptions, selectedHelp, "up");
			}
			
			if(isPlay){
				selectedPlay = menuSelection(playOptions, selectedPlay, "up");	
			}
			
			if(isSplit){
				selectedSplit = menuSelection(SplitOptions, selectedSplit, "up");
				enableOverRideKeys = false;
				pauseTime = Time.time + 0.2f;
			}
			
			if(isHighS){
				if(selectedHighS == 1){
					
					selectedHighS = menuSelection(highSOptions, selectedHighS, "up");
					
				} else {
					
					selectedHighS = menuSelection(highSOptions, selectedHighS, "up");
					
					if(selectedHighS == 0 || selectedHighS == 1){
						scoreBoardTexture.mainTexture = loadingMaterial;
						StartCoroutine(scoreBoard.getTextTestStart(true));	
					} else if (selectedHighS == 2){
						scoreBoardTexture.mainTexture = loadingMaterial;
						StartCoroutine(scoreBoard.getTextTestStart(false));	
					}
				}
			}
		}
		
		if(Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)){
			if(isMain){
				selectedMain = menuSelection(mainOptions, selectedMain, "down");
			}
			
			if(isHelp){
				selectedHelp = menuSelection(helpOptions, selectedHelp, "down");
			}
			
			if(isPlay){
				selectedPlay = menuSelection(playOptions, selectedPlay, "down");	
			}
			
			if(isSplit){
				selectedSplit = menuSelection(SplitOptions, selectedSplit, "down");
				enableOverRideKeys = false;
				pauseTime = Time.time + 0.2f;
			}
			
			if(isHighS){
				if(selectedHighS == 0){
					
					selectedHighS = menuSelection(highSOptions, selectedHighS, "down");
					
				} else {
					selectedHighS = menuSelection(highSOptions, selectedHighS, "down");
					
					if(selectedHighS == 0 || selectedHighS == 1){
						StartCoroutine(scoreBoard.getTextTestStart(true));	
					} else if (selectedHighS == 2){
						StartCoroutine(scoreBoard.getTextTestStart(false));	
					}
				}
			}
		}
		
		// =============================================================================== //
		
		if(selectedHelp == 1){
			isAbout = true;
			isSControls = false;
			isHControls = false;
			isWeapons = false;
			isCredits = false;
		} else if (selectedHelp == 2){
			isAbout = false;
			isSControls = true;
			isHControls = false;
			isWeapons = false;
			isCredits = false;
		} else if (selectedHelp == 3){
			isAbout = false;
			isSControls = false;
			isHControls = true;
			isWeapons = false;
			isCredits = false;
		} else if (selectedHelp == 4){
			isAbout = false;
			isSControls = false;
			isHControls = false;
			isWeapons = true;
			isCredits = false;
		} else if (selectedHelp == 5){
			isAbout = false;
			isSControls = false;
			isHControls = false;
			isWeapons = false;
			isCredits = true;
		} else {
			isAbout = false;
			isSControls = false;
			isHControls = false;
			isWeapons = false;
			isCredits = false;
		}
	}
	
	// ============================ GUI ================================ //
	
	void OnGUI(){
		
		GUI.skin = skin;
		
		if(isMain){
			GUILayout.BeginArea(new Rect(mainOptionsX,(Screen.height / 2) - ((mainOptions.Length * 50) / 2),200,mainOptions.Length * 50));
			GUILayout.BeginVertical();
			
			GUI.SetNextControlName("Play");
			if(GUILayout.Button("Play") || ((selectedMain == 0) && Input.GetKeyDown(KeyCode.Return))){
				StartCoroutine(swapMenus("main","play"));
			}
			
			GUI.SetNextControlName("Help");
			if(GUILayout.Button("Help") || ((selectedMain == 1) && Input.GetKeyDown(KeyCode.Return))){
				StartCoroutine(swapMenus("main","help"));
			}
			
			GUI.SetNextControlName("High Scores");
			if(GUILayout.Button("High Scores") || ((selectedMain == 2) && Input.GetKeyDown(KeyCode.Return))){
				StartCoroutine(swapMenus("main","highS"));
			}

			GUI.SetNextControlName("Create");
			if(GUILayout.Button("Create") || ((selectedMain == 3) && Input.GetKeyDown(KeyCode.Return))){
				
			}
			
			GUI.SetNextControlName("Settings");
			if(GUILayout.Button("Settings") || ((selectedMain == 4) && Input.GetKeyDown(KeyCode.Return))){
				
			}
			
			GUI.SetNextControlName("Exit");
			if(GUILayout.Button("Exit") || ((selectedMain == 5) && Input.GetKeyDown(KeyCode.Return))){
				Application.Quit();
			}
			
			GUI.FocusControl(mainOptions[selectedMain]);
			
			GUILayout.EndVertical();
			GUILayout.EndArea();
		}
		
		if(isPlay){
			
			GUIStyle strike = new GUIStyle();
			strike.fontSize = 20;
			strike.alignment = TextAnchor.MiddleRight;
			strike.onNormal.textColor = Color.gray;
			
			GUILayout.BeginArea(new Rect(playOptionsX,(Screen.height / 2) - ((playOptions.Length * 50) / 2) ,200,playOptions.Length * 50));
			GUILayout.BeginVertical();
			
			GUI.SetNextControlName("Return");
			if(GUILayout.Button("Return to Menu") || ((selectedPlay == 0) && Input.GetKeyDown(KeyCode.Return))){
				StartCoroutine(swapMenus("play","main"));
			}
			
			GUI.SetNextControlName("Split");
			if(GUILayout.Button("Split Screen") || ((selectedPlay == 1) && Input.GetKeyDown(KeyCode.Return))){
				StartCoroutine(swapMenus("play","split"));
			}
			
			GUI.Label(new Rect(new Rect(0,100,200,50)),"---------------------",strike);
			GUI.SetNextControlName("Local");
			if(GUILayout.Button("Local Network") || ((selectedPlay == 2) && Input.GetKeyDown(KeyCode.Return))){
				
			}
			
			GUI.Label(new Rect(new Rect(0,150,200,50)),"-----------",strike);
			GUI.SetNextControlName("Online");
			if(GUILayout.Button("Online") || ((selectedPlay == 3) && Input.GetKeyDown(KeyCode.Return))){
				
			}
			
			GUI.FocusControl(playOptions[selectedPlay]);
			
			GUILayout.EndVertical();
			GUILayout.EndArea();
		}
		
		if(isSplit){
			Event e = Event.current;
			
			if(selectedSplit == 1 || selectedSplit == 2){
				if(e.keyCode == KeyCode.UpArrow && e.type == EventType.keyUp && enableOverRideKeys){
					selectedSplit = menuSelection(SplitOptions, selectedSplit, "up");
					enableOverRideKeys = false;
					pauseTime = Time.time + 0.2f;
				}
				
				if(e.keyCode == KeyCode.DownArrow && e.type == EventType.keyUp && enableOverRideKeys){
					selectedSplit = menuSelection(SplitOptions, selectedSplit, "down");
					enableOverRideKeys = false;
					pauseTime = Time.time + 0.2f;
				}
			}
			
			if(e.keyCode == KeyCode.Return && e.type == EventType.keyUp && selectedSplit == 3) { startGame(); }
			if(e.keyCode == KeyCode.Return && e.type == EventType.keyUp && selectedSplit == 0) { StartCoroutine(swapMenus("split","play")); }

			GUI.Box(new Rect((Screen.width / 2) - 450, 20, 900,25),"Your scores WILL be uploaded at the end of the game to a online database, Including your IP's country code. This is not optional at the current time"); 
			
			GUILayout.BeginArea(new Rect(splitOptionsX,(Screen.height / 2) - ((SplitOptions.Length * 50) / 2) ,300,SplitOptions.Length * 50));
			GUILayout.BeginVertical();
			
			GUI.SetNextControlName("Return");
			if(GUILayout.Button("Return to Play menu") || ((selectedPlay == 0) && Input.GetKeyDown(KeyCode.Return))){
				StartCoroutine(swapMenus("split","play"));
			}
			
			GUI.SetNextControlName("Hider");
			GUILayout.BeginHorizontal();
			GUILayout.Label("Hider Name: ");
			hiderName = GUILayout.TextField(hiderName);
			GUILayout.EndHorizontal();
			
			GUI.SetNextControlName("Seeker");
			GUILayout.BeginHorizontal();
			GUILayout.Label("Seeker Name: ");
			seekerName = GUILayout.TextField(seekerName);
			GUILayout.EndHorizontal();
			
			GUI.SetNextControlName("Begin");
			if(GUILayout.Button("Begin") || ((selectedPlay == 3) && Input.GetKeyDown(KeyCode.Return))){
				startGame();
			}
			
			GUI.FocusControl(SplitOptions[selectedSplit]);
			
			GUILayout.EndVertical();
			GUILayout.EndArea();
		}
		
		if(isHelp){
			
			GUILayout.BeginArea(new Rect(helpOptionsX,(Screen.height / 2) - ((helpOptions.Length * 50) / 2),200,helpOptions.Length * 50));
			GUILayout.BeginVertical();
			
			GUI.SetNextControlName("Return");
			if(GUILayout.Button("Return to Menu") || ((selectedHelp == 0) && Input.GetKeyDown(KeyCode.Return))){
				StartCoroutine(swapMenus("help","main"));
			}
			
			GUI.SetNextControlName("About");
			if(GUILayout.Button("About") || ((selectedHelp == 1) && Input.GetKeyDown(KeyCode.Return))){
				StartCoroutine(swapMenus("NA","about"));
			}
			
			GUI.SetNextControlName("SControls");
			if(GUILayout.Button("Seeker Controls") || ((selectedHelp == 2) && Input.GetKeyDown(KeyCode.Return))){
				
			}

			GUI.SetNextControlName("HControls");
			if(GUILayout.Button("Hider Controls") || ((selectedHelp == 2) && Input.GetKeyDown(KeyCode.Return))){
				
			}

			GUI.SetNextControlName("Weapons");
			if(GUILayout.Button("Weapons") || ((selectedHelp == 2) && Input.GetKeyDown(KeyCode.Return))){
				
			}
			
			GUI.SetNextControlName("Credits");
			if(GUILayout.Button("Credits") || ((selectedHelp == 3) && Input.GetKeyDown(KeyCode.Return))){
				
			}
			
			GUI.FocusControl(helpOptions[selectedHelp]);
			
			GUILayout.EndVertical();
			GUILayout.EndArea();
			
			GUILayout.BeginArea(new Rect(300, Screen.height - (Screen.height * 0.7f), Screen.width - 400,Screen.height * 0.8f));
			GUI.skin = skin;
			if(isAbout){
				GUILayout.BeginVertical();
				GUILayout.Label(aboutTextOne);
				GUILayout.Label(aboutTextTwo);
				GUILayout.EndVertical();
			}
			
			if(isSControls){
				GUILayout.EndArea();
				GUILayout.BeginArea(new Rect(300, 50, Screen.width - 400,Screen.height * 0.9f));
				GUI.DrawTexture(new Rect(0, 0, Screen.width - 400,Screen.height * 0.9f),seekerControls);
				/*
				GUILayout.BeginHorizontal();
				GUILayout.BeginVertical();
				GUILayout.Label("Seeker:");
				GUILayout.Label("Movement - Arrow Keys");
				
				GUILayout.Label("Shop:");
				GUILayout.Label("FlashBang trap (50 gold) - 1");
				GUILayout.Label("scanner (50 gold) - 2");
				GUILayout.Label("Explosion push (50 gold) - 3");
				
				GUILayout.EndVertical();
				GUILayout.BeginVertical();
				
				GUILayout.Label("Hider:");
				GUILayout.Label("Movement - WASD");
				GUILayout.Label("Look around - Mouse");
				GUILayout.Label("Pick up object - Left click");
				
				GUILayout.Label("Shop:");
				GUILayout.Label("Spam Seeker warning system (50 gold) - Q");
				
				GUILayout.EndVertical();
				GUILayout.EndHorizontal();*/
			}

			if(isHControls){
				GUILayout.EndArea();
				GUILayout.BeginArea(new Rect(300, 50, Screen.width - 400,Screen.height * 0.9f));
				
				GUI.DrawTexture(new Rect(0, 0, Screen.width - 400,Screen.height * 0.9f),hiderControls);
			}

			if(isWeapons){
				GUILayout.EndArea();
				GUILayout.BeginArea(new Rect(300, 50, Screen.width - 400,Screen.height * 0.9f));
				
				GUI.DrawTexture(new Rect(0, 0, Screen.width - 400,Screen.height * 0.9f),weapons);
			}
			
			if(isCredits){
				GUILayout.BeginVertical();
				GUILayout.Label("Tristan 'Kennyist' Cunningham","Person");
				GUILayout.Label("www.tristanjc.com","SubDetails");
				GUILayout.Label("---","Gap");
				GUILayout.Label("GabberDaan","Person");
				GUILayout.Label("Creative And gameplay input, Game testing","SubDetails");
				GUILayout.Label("---","Gap");
				GUILayout.Label("Freesounds.org","Person");
				GUILayout.Label("Julien Nicolas, Dheming, cameronmusic","SubDetails");
				GUILayout.EndVertical();
			}
			GUILayout.EndArea();
		}
		
		if(isHighS){
			
			GUILayout.BeginArea(new Rect(highSOptionsX,(Screen.height / 2) - ((highSOptions.Length * 50) / 2),200,highSOptions.Length * 50));
			GUILayout.BeginVertical();
			
			GUI.SetNextControlName("Return");
			if(GUILayout.Button("Return to Menu") || ((selectedHighS == 0) && Input.GetKeyDown(KeyCode.Return))){
				StartCoroutine(swapMenus("highS","main"));
			}
			
			GUI.SetNextControlName("Seeker");
			if(GUILayout.Button("Seeker")){}
			
			GUI.SetNextControlName("Hider");
			if(GUILayout.Button("Hider")){}
			
			GUI.FocusControl(highSOptions[selectedHighS]);
			
			GUILayout.EndVertical();
			GUILayout.EndArea();			
		}
	}
	
	void startGame(){
		if(hiderName == ""){ hiderName = "Annon Hider"; }
		if(seekerName == ""){ seekerName = "Annon Seeker"; }
				
		statvr.setHiderName(hiderName);
		statvr.setSeekerName(seekerName);
		Application.LoadLevel("1");
	}
}
