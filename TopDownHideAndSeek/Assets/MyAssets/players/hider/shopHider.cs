using UnityEngine;
using System.Collections;

public class shopHider : MonoBehaviour {
	
	public WarningSpamWeapon wsw;
	private StaticVars stvr = new StaticVars();
	ScoreManager scrMngr = new ScoreManager();

	public Texture2D xIcon;
	public Texture2D spamIcon;
	public Texture2D cctvIcon;
	public Texture2D motionIcon;
	public GameObject motionDetector;

	private float cctvTime = 0f;
	
	void Update () {
		int gold = stvr.GetGold(false);
		if(gold > 0){
			if(gold >= 50){
				if(Input.GetKeyDown(KeyCode.RightControl)){	
					wsw.startEffect();	
					stvr.RemoveGold(false,50);
					scrMngr.AddTrapUsed(false);
					scrMngr.AddTrapHit(false);
				}

				if(Input.GetKeyDown(KeyCode.Return)){
					Instantiate(motionDetector,new Vector3(transform.position.x,transform.position.y - 0.5f,transform.position.z),transform.rotation);
					stvr.RemoveGold(false,50);
				}
			}

			if(gold >= 75){
				if(Input.GetKeyDown(KeyCode.RightShift)){	
					stvr.RemoveGold(false,75);
					Cctv();
				}
			}
		}

		if(Time.time > cctvTime){
			stvr.SetHiderCCTV(false);
		}
	}

	void OnGUI(){
		int gold = stvr.GetGold(false);

		if(gold >= 75){
			GUI.DrawTexture(new Rect(Screen.width - 125,Screen.height - 65,60,60),cctvIcon);
			GUI.DrawTexture(new Rect(Screen.width - 185,Screen.height - 65,60,60),motionIcon);
		} else {
			GUI.DrawTexture(new Rect(Screen.width - 125,Screen.height - 65,60,60),cctvIcon);
			GUI.DrawTexture(new Rect(Screen.width - 125,Screen.height - 65,60,60),xIcon);
			GUI.DrawTexture(new Rect(Screen.width - 185,Screen.height - 65,60,60),motionIcon);
			GUI.DrawTexture(new Rect(Screen.width - 185,Screen.height - 65,60,60),xIcon);
		}

		if(gold >= 50){
			GUI.DrawTexture(new Rect(Screen.width - 65,Screen.height - 65,60,60),spamIcon);
		} else {
			GUI.DrawTexture(new Rect(Screen.width - 65,Screen.height - 65,60,60),spamIcon);
			GUI.DrawTexture(new Rect(Screen.width - 65,Screen.height - 65,60,60),xIcon);
		}
	}

	private void Cctv(){
		stvr.SetHiderCCTV(true);
		cctvTime = Time.time + 10f;
	}
}
