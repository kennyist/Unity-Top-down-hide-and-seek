using UnityEngine;
using System.Collections;

public class SeekerShop : MonoBehaviour {
	
	StaticVars stvr = new StaticVars();
	ScoreManager scrMngr = new ScoreManager();
	
	public GameObject flashBang;
	public GameObject scanner;

	public Texture2D xIcon;
	public Texture2D flashbangIcon;
	public Texture2D scannerIcon;
	public Texture2D phyPushIcon;
	public Texture2D cctvIcon;
	public AudioClip pulse;

	private string xbxY;
	private string xbxB;
	private string xbxA;
	private string xbxX;
	
	private float cctvTime = 0f;

	void Start(){
		if (Application.platform == RuntimePlatform.OSXPlayer){
			xbxA = "mac A";
			xbxB = "mac B";
			xbxY = "mac Y";
			xbxX = "mac X";
		} else {
			xbxA = "win A";
			xbxB = "win B";
			xbxY = "win Y";
			xbxX = "win X";
		}
	}

	void Update (){
		int gold = stvr.GetGold(true);
		if(gold > 0){
			if(gold >= 75){
				if(Input.GetKeyUp(KeyCode.Alpha1) || Input.GetButtonDown(xbxA)){
					Instantiate(flashBang,transform.position,transform.rotation);
					stvr.RemoveGold(true,75);
					stvr.AddActiveTrap();
					scrMngr.AddTrapUsed(true);
				}

				if(Input.GetKeyUp(KeyCode.Alpha3) || Input.GetButtonDown(xbxY)){
					Explode();
					stvr.RemoveGold(true,75);
					scrMngr.AddTrapUsed(true);
				}

				if(Input.GetKeyUp(KeyCode.Alpha4) || Input.GetButtonDown(xbxX)){
					stvr.RemoveGold(true,75);
					scrMngr.AddTrapUsed(true);
					Cctv();
				}
			}

			if(gold >= 25){
				if(Input.GetKeyUp(KeyCode.Alpha2) || Input.GetButtonDown(xbxB)){
					StartCoroutine(startScanner());
					stvr.RemoveGold(true,25);
					scrMngr.AddTrapUsed(true);
				}
			}
		}

		if(Time.time > cctvTime){
			stvr.SetSeekerCCTV(false);
		}
	}

	void OnGUI(){
		int gold = stvr.GetGold(true);

		if(gold >= 75){
			GUI.DrawTexture(new Rect(5,Screen.height - 65,60,60),flashbangIcon);
			GUI.DrawTexture(new Rect(125,Screen.height - 65,60,60),phyPushIcon);
			GUI.DrawTexture(new Rect(185,Screen.height - 65,60,60),cctvIcon);
		} else {
			GUI.DrawTexture(new Rect(5,Screen.height - 65,60,60),flashbangIcon);
			GUI.DrawTexture(new Rect(5,Screen.height - 65,60,60),xIcon);
			GUI.DrawTexture(new Rect(125,Screen.height - 65,60,60),phyPushIcon);
			GUI.DrawTexture(new Rect(125,Screen.height - 65,60,60),xIcon);
			GUI.DrawTexture(new Rect(185,Screen.height - 65,60,60),cctvIcon);
			GUI.DrawTexture(new Rect(185,Screen.height - 65,60,60),xIcon);
		}

		if(gold >= 25){
			GUI.DrawTexture(new Rect(65,Screen.height - 65,60,60),scannerIcon);
		} else {
			GUI.DrawTexture(new Rect(65,Screen.height - 65,60,60),scannerIcon);
			GUI.DrawTexture(new Rect(65,Screen.height - 65,60,60),xIcon);
		}

	}
	
	// ============== Explosion ============ //
	
	private void Explode(){
		
		Collider[] colliders = Physics.OverlapSphere(transform.position, 5.0f);
		
		foreach(Collider hit in colliders){
			if(hit && hit.rigidbody && (hit.gameObject.tag != "Hider") && (hit.gameObject.tag != "Seeker")){
				hit.rigidbody.AddExplosionForce(500f, transform.position, 5f);	
			}
		}
	}
	
	// ============== Scanner ============== //
		
	private IEnumerator startScanner(){
		createScanObj();
		yield return new WaitForSeconds(0.2f);
		createScanObj();
		yield return new WaitForSeconds(0.2f);
		createScanObj();
		yield return new WaitForSeconds(0.2f);
		createScanObj();
		yield return new WaitForSeconds(0.2f);
		createScanObj();
	}
	
	private void createScanObj(){
		
		GameObject clone = Instantiate(scanner,new Vector3(transform.position.x,transform.position.y,transform.position.z),scanner.transform.rotation) as GameObject;
		clone.GetComponent<BurstEffectGrow>().enabled = true;
		clone.AddComponent<AudioSource>();
		clone.audio.PlayOneShot(pulse);
	}

	private void Cctv(){
		stvr.SetSeekerCCTV(true);
		cctvTime = Time.time + 10f;
	}
}
