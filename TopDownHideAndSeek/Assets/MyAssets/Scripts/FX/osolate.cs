using UnityEngine;
using System.Collections;

public class osolate : MonoBehaviour {
	
	float y;
	float startY;
	public float yLeft = 20f;
	public float yRight = -20f;
	public float duration = 3f;
	float time = 0f;
	public float x,z;

	void Start () {
		startY = transform.rotation.y;
	 	StartCoroutine(rotate());
	}
	
	void Update(){
		transform.localEulerAngles = new Vector3(x,y,z);	
	}
	
	IEnumerator rotate(){
		time = 0;
		
		while(time <= duration){
			y = Mathf.Lerp(yRight,yLeft, time / duration);
			time += Time.deltaTime;
			yield return 0;
		}
		
		time = 0;
		
		while(time <= duration){
			y = Mathf.Lerp(yLeft,yRight, time / duration);
			time += Time.deltaTime;
			yield return 0;
		}
		
		StartCoroutine(rotate());
	}
}
