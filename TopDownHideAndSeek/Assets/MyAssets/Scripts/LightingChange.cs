using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LightingChange : MonoBehaviour {

	public List<Light> Lights;
	private GameObject[] temp;
	public bool forSeeker = false;
	public Material lightMaterial;
	
	void Start(){
		if(forSeeker){
			temp = GameObject.FindGameObjectsWithTag("LightHide");
			for(int i = 0; i < temp.Length; i++){
				Lights.Add(temp[i].GetComponent<Light>());	
			}
		}
	}
 
	void OnPreCull(){
		foreach (Light light in Lights){
			light.enabled = false;
			if(forSeeker){
				lightMaterial.SetColor("_Color", Color.black);
				lightMaterial.shader = Shader.Find("Diffuse");
			}
		}
	}
	 
	void OnPostRender(){
		foreach (Light light in Lights){
			light.enabled = true;
			if(forSeeker){
				lightMaterial.SetColor("_Color", Color.white);
				lightMaterial.shader = Shader.Find("Self-Illumin/Specular");
			}
		}
	}
}
