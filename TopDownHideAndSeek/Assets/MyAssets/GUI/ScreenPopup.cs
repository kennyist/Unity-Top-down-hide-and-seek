using UnityEngine;
using System.Collections;

public class ScreenPopup : MonoBehaviour {
	
	private Texture2D texture;
	private Transform position;
	private bool screenLeft;
	private float lifeTime;
	private bool endLife = false;
	private float alpha = 1.0f;
	
	public void Set(Texture2D text,Transform pos,bool scrnLft, float time){
		texture = text;
		position = pos;
		screenLeft = scrnLft;
		lifeTime = time;
	}
	
	bool fadeIn = false;
	
	void Update(){
		
		if(lifeTime < 0){
			endLife = true;
		} else {
			lifeTime -= Time.deltaTime;
		}
		
		if(fadeIn){
			if(alpha < 1.0f) { alpha += Time.deltaTime*2; }
			if(alpha > 1f) { fadeIn = false; }
		} else {		
			if(alpha > 0.0f){ alpha -= Time.deltaTime*2; }
			if(alpha < 0f){ fadeIn = true; }	
		}
	}
	
	public float GetAlpha(){
		return Mathf.Clamp01(alpha);
	}
	
	public bool leftScreen(){
		return screenLeft;
	}
	
	public bool GetEndLife(){
		return endLife;
	}
	
	public Transform GetPosition(){
		return position;
	}
	
	public Texture2D GetTexture(){
		return texture;
	}
	
	public void DestroyScript(){
		Destroy(gameObject);	
	}
}
