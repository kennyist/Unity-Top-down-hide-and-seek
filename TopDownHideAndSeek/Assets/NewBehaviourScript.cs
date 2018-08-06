using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {

	public GUITexture text;

	void OnPreCull(){
		text.enabled = true;
	}

	void OnPostRender(){
		text.enabled = false;
	}

}
