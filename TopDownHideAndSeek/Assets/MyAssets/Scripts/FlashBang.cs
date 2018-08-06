using UnityEngine;
using System.Collections;

public class FlashBang : MonoBehaviour {
	
	private bool enabled = true;
	private bool LIup = false;
	private bool LIdown = false;
	private bool overLayTrig = true;
	private bool end;
	
	private float alpha = 1.0f;
	private float HDRIntensity = 2.0f;
	
	private Texture2D FBOverlay;
	
	private BloomAndLensFlares BLF;
	
	private GameObject hiderCam;
	
	private StaticVars stvr = new StaticVars();
	private ScoreManager scrMngr = new ScoreManager();

	void Start () {
		hiderCam = GameObject.FindGameObjectWithTag("HiderCam");
		BLF = hiderCam.GetComponentInChildren<BloomAndLensFlares>();
	}
	
	void Update () {
		
		if(light.intensity < 8f && LIup){ light.intensity += Time.deltaTime * 10; light.range += Time.deltaTime; } else { if(LIup){ LIup = false; LIdown = true; } }
		
		if(light.intensity > 7f && overLayTrig){ AddOverlay(); overLayTrig = false; }
		
		if(light.intensity > 0f && LIdown){ light.intensity -= Time.deltaTime * 10; light.range -= Time.deltaTime; } else { if(LIdown){ LIdown = false; overLayTrig = true; } }
		
		
		
		if(alpha > 0.0f){
			alpha -= Time.deltaTime / 10;
		}
		
		if(HDRIntensity > 2.0f){
			HDRIntensity -= Time.deltaTime ;
		} else {
			HDRIntensity = 2.0f;
		}
		
		if((HDRIntensity == 2.0f) && (alpha <= 0.0f) && end){ Destroy(gameObject); }
		
		BLF.bloomIntensity = HDRIntensity;
	}
	
	public void Enable(){
		enabled = true;
	}
		
	void AddOverlay(){		
		FBOverlay = new Texture2D((Screen.width / 2) - 6, Screen.height);
		FBOverlay.ReadPixels(new Rect((Screen.width / 2),0,(Screen.width / 2) + 3, Screen.height),0,0);
		FBOverlay.Apply();
		alpha = 1.0f;
		HDRIntensity = 15.0f;
		end = true;
	}
	
	void OnTriggerEnter(Collider target)
    {
    	if(target.tag == "Hider" && enabled)
    	{			
			GameObject GUIscpt = GameObject.FindGameObjectWithTag("GUIscripts");
			
			GUIscpt.GetComponent<GUIpopup>().addPopup(true,transform,10);
			
			gameObject.GetComponent<FxLightFlash>().enabled = false;
			
    		light.color = Color.white;
			LIup = true;
			
			MeshRenderer mR = gameObject.GetComponent<MeshRenderer>();
			mR.enabled = false;
			
			enabled = false;
			
			// scoreing //
			
			stvr.AddGold(true,50);
			scrMngr.AddTrapHit(true);
			stvr.RemoveActiveTrap();
    	}
    }
	
	void OnGUI(){
		Color col = GUI.color;
		col.a = alpha;
		GUI.color = col;
		GUI.DrawTexture(new Rect((Screen.width / 2),0,(Screen.width / 2) + 3, Screen.height),FBOverlay);
	}
}
