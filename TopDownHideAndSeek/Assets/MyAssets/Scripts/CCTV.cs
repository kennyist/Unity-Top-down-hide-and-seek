using UnityEngine;
using System.Collections;

public class CCTV : MonoBehaviour {

	StaticVars stvr = new StaticVars();
	ScoreManager scrMngr = new ScoreManager();
	private float stime;
	private bool senable;
	private float htime;
	private bool henable;

	void Update(){
		if(Time.time > stime){
			senable = true;
		}

		if(Time.time > htime){
			henable = true;
		}
	}

	void OnTriggerEnter(Collider col) {
		if(col.tag == "Seeker" && stvr.HiderCCTVEnabled()){
			scrMngr.AddTrapHit(false);
		}

		if(col.tag == "Hider" && stvr.SeekerCCTVEnabled()){
			scrMngr.AddTrapHit(true);
		}
	}

	void OnTriggerStay(Collider col){
		if(col.tag == "Seeker" && stvr.HiderCCTVEnabled() && henable){
			htime = Time.time + 1.0f;
			henable = false;
			GameObject GUIscpt = GameObject.FindGameObjectWithTag("GUIscripts");
			GUIscpt.GetComponent<GUIpopup>().addPopup(false,col.transform,1.0f);
			stvr.AddGold(false,5);
		}

		if(col.tag == "Hider" && stvr.SeekerCCTVEnabled() && senable){
			stime = Time.time + 1.0f;
			senable = false;
			GameObject GUIscpt = GameObject.FindGameObjectWithTag("GUIscripts");
			GUIscpt.GetComponent<GUIpopup>().addPopup(true,col.transform,1.0f);
			stvr.AddGold(true,5);
		}
	}
}
