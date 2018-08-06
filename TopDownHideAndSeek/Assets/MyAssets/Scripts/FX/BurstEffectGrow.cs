using UnityEngine;
using System.Collections;

public class BurstEffectGrow : MonoBehaviour {
	
	Vector3 scl = new Vector3(40f,40f,1f);
	float spd = 0.8f;
	
	public HiderControls hider;
	public SeekerControls seeker;

	void FixedUpdate () {
		transform.localScale = Vector3.Lerp (transform.localScale, scl, spd * Time.deltaTime);
		
		if(transform.localScale.x > 35f){
			Destroy(gameObject);	
		}
	}
	
	void OnTriggerEnter(Collider col) {
        if(col.tag == "Hider")
		{
			Debug.Log("scanned");
			hider.SetVisable();
			seeker.SetVisable();
		}
    }
}
