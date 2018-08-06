using UnityEngine;
using System.Collections;

public class MotionDetecter : MonoBehaviour {

	private StaticVars stvr = new StaticVars();
	private ScoreManager scrMngr = new ScoreManager();

	void Update(){

	}

	void OnTriggerEnter(Collider target)
	{
		if(target.tag == "Seeker")
		{			
			GameObject GUIscpt = GameObject.FindGameObjectWithTag("GUIscripts");
			GUIscpt.GetComponent<GUIpopup>().addPopup(false,transform,10);
			stvr.AddGold(false,25);
			scrMngr.AddTrapHit(false);

			MeshRenderer mR = gameObject.GetComponent<MeshRenderer>();
			mR.enabled = false;

			collider.enabled = false;
		}
	}
}
