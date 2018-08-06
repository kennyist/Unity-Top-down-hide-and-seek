using UnityEngine;
using System.Collections;

public class FxLightFlash : MonoBehaviour {

	public float interval = 1.0f;
	public float flashTime = 0.5f;
	public bool invert = false;
	
	float StartTime;
	float flashStartTime;
	bool isInterval = true;
	LensFlare flare;
	
	void Start(){
		StartTime = Time.time + interval;	
		
		if(invert){
			isInterval = !isInterval;
		}
	}
	
	void Update () {
		if(Time.time >= StartTime){
			if(isInterval){
				StartTime = Time.time + flashTime;
				isInterval = !isInterval;
				light.intensity = 0f;
			} else {
				StartTime = Time.time + interval;
				isInterval = !isInterval;
				light.intensity = 1f;
			}
		}
	}
}
