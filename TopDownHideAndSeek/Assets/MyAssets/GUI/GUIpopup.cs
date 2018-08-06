using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GUIpopup : MonoBehaviour {
	
	public Texture2D warningTexture;
	public Camera leftCam;
	public Camera rightCam;
	public GameObject popUpContainer;
	private List<GameObject> popups = new List<GameObject>();
	
	void Update(){		
		if(popups.Count > 0){
			foreach(GameObject obj in popups){
				ScreenPopup popup = obj.GetComponent<ScreenPopup>();
				
				if(popup.GetEndLife()){
					popups.Remove(obj);
					popup.DestroyScript();
				}
			}
		}
	}

	void OnGUI(){
		if(popups.Count > 0){
			foreach(GameObject obj in popups){
				
				ScreenPopup popup = obj.GetComponent<ScreenPopup>();
				Vector3 screenPoint;
				
				if(popup.leftScreen()){
					
					screenPoint = leftCam.WorldToScreenPoint(popup.GetPosition().position);
					if(screenPoint.x < 5){ screenPoint.x = 5f; }
					if(screenPoint.x > ((Screen.width / 2) - 35f)) { screenPoint.x = ((Screen.width / 2) - 35f); }
					if(screenPoint.y < 35){ screenPoint.y = 35f; }
					if(screenPoint.y > (Screen.height - 5)){ screenPoint.y = (Screen.height - 5f); }
				
				}  else {
					
					screenPoint = rightCam.WorldToScreenPoint(popup.GetPosition().position);
					if(screenPoint.x < (Screen.width / 2) + 5f){ screenPoint.x = (Screen.width / 2) + 5f; }
					if(screenPoint.x > Screen.width - 35f) { screenPoint.x = (Screen.width - 35f); }
					if(screenPoint.y < 35){ screenPoint.y = 35f; }
					if(screenPoint.y > (Screen.height - 5)){ screenPoint.y = (Screen.height - 5f); }
				}

				//Debug.Log("alpha: "+ popup.GetAlpha());
				
				//Color GUIcol = GUI.color;
				//GUIcol.a = popup.GetAlpha();
				//GUI.color = GUIcol;
				
				GUI.DrawTexture(new Rect(screenPoint.x, ( Screen.height - screenPoint.y),30,30), popup.GetTexture());
			}
		}
	}
	
	public void addPopup(bool leftRight, Transform position, float showTime){
		GameObject popup = new GameObject("popup");
		popup.transform.parent = popUpContainer.transform;
		popup.AddComponent<ScreenPopup>().Set(warningTexture,position,leftRight,showTime);
		popups.Add(popup);
		Debug.Log(popups.Count);
	}
}
