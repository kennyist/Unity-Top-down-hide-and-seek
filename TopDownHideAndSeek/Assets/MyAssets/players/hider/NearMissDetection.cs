using UnityEngine;
using System.Collections;

public class NearMissDetection : MonoBehaviour {
	
	ScoreManager scrMngr = new ScoreManager();
	bool count = false;
	float time = 0f;
	public GameObject hider;

	void OnTriggerEnter(Collider col){
		if(col.gameObject.tag == "Seeker"){
			count = true;
		}
	}
	
	void OnTriggerExit(Collider col){
		if(col.gameObject.tag == "Seeker"){
			count = false;	
			AddUp();
		}
	}
	
	void Update(){
		
		transform.position = hider.transform.position;
		
		if(count){
			time += Time.deltaTime;
		}
	}
	
	void AddUp(){
		if(time > 5.0f){
			scrMngr.AddNearMiss(false);	
		}
		time = 0f;
	}
}
