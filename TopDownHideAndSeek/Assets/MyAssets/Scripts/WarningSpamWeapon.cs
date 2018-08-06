using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WarningSpamWeapon : MonoBehaviour {
	
	public GUIpopup popup;
	private List<Transform> children = new List<Transform>();
	private List<Transform> temp = new List<Transform>();
	
	private bool effectOn = false;

	void Start () {
		Transform[] tc = gameObject.GetComponentsInChildren<Transform>();
		children.AddRange(tc);
		Debug.Log (children.Count);
	}
	
	public void startEffect(){
		if(!effectOn){
			effectOn = true;
			temp.AddRange(children);
			Debug.Log("CC: " + children.Count + " TC: " + temp.Count); 
			StartCoroutine(Effect());
		}
	}
	
	private IEnumerator Effect(){
		for(int i = 0; i <= 4; i++){
			int rand = Random.Range(0,temp.Count);
			float randTime = Random.Range(0.5f,4f);
			popup.addPopup(true,temp[rand],randTime);
			temp.RemoveAt(rand);
		}
		
		yield return new WaitForSeconds(3f);
		
		for(int i = 0; i <= 6; i++){
			int rand = Random.Range(0,temp.Count);
			float randTime = Random.Range(0.5f,4f);
			popup.addPopup(true,temp[rand],randTime);
			temp.RemoveAt(rand);
		}
		
		yield return new WaitForSeconds(3f);
		
		for(int i = 0; i <= 3; i++){
			int rand = Random.Range(0,(temp.Count - 1));
			float randTime = Random.Range(0.5f,4f);
			popup.addPopup(true,temp[rand],randTime);
			if(i == 3){
				temp.Clear();
			} else {
				temp.RemoveAt(rand);
			}
		}	
		
		yield return new WaitForSeconds(3f);
		effectOn = false;
	}
}
