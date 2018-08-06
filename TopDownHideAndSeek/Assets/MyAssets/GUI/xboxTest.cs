using UnityEngine;
using System.Collections;

public class xboxTest : MonoBehaviour {

	void OnGUI()
	{/*
		GUI.Label(new Rect(5, 5, 200, 25), "Left Joystick X-Axis: ");
		GUI.Label(new Rect(155, 5, 200, 25), Input.GetAxis("Horizontal").ToString());
		
		GUI.Label(new Rect(5, 25, 200, 25), "Left Joystick Y-Axis: ");
		GUI.Label(new Rect(155, 25, 200, 25), Input.GetAxis("Vertical").ToString());
		
		GUI.Label(new Rect(5, 45, 200, 25), "Right Joystick X-Axis: ");
		GUI.Label(new Rect(155, 45, 200, 25), Input.GetAxis("RightHorizontal").ToString());
		
		GUI.Label(new Rect(5, 65, 200, 25), "Right Joystick Y-Axis: ");
		GUI.Label(new Rect(155, 65, 200, 25), Input.GetAxis("RightVertical").ToString());
		
		GUI.Label(new Rect(5, 85, 200, 25), "Left Pad Up: ");
		GUI.Label(new Rect(155, 85, 200, 25), Input.GetButton("PadUp").ToString());
		
		GUI.Label(new Rect(5, 105, 200, 25), "Left Pad Down: ");
		GUI.Label(new Rect(155, 105, 200, 25), Input.GetButton("PadDown").ToString());
		
		GUI.Label(new Rect(5, 125, 200, 25), "Left trigger: ");
		GUI.Label(new Rect(155, 125, 200, 25), Input.GetAxis("win triggerl").ToString());
		
		GUI.Label(new Rect(5, 145, 200, 25), "right trigger: ");
		GUI.Label(new Rect(155, 145, 200, 25), Input.GetAxis("win triggerr").ToString());*/
		
		GUI.Label(new Rect(5, 165, 200, 25), "Y Button: ");
		GUI.Label(new Rect(155, 165, 200, 25), Input.GetButton("win Y").ToString());
		
		GUI.Label(new Rect(5, 185, 200, 25), "B Button: ");
		GUI.Label(new Rect(155, 185, 200, 25), Input.GetButton("win B").ToString());
		
		GUI.Label(new Rect(5, 205, 200, 25), "A Button: ");
		GUI.Label(new Rect(155, 205, 200, 25), Input.GetButton("win A").ToString());
		
		GUI.Label(new Rect(5, 225, 200, 25), "X Button: ");
		GUI.Label(new Rect(155, 225, 200, 25), Input.GetButton("win X").ToString());

		GUI.Label(new Rect(5, 245, 200, 25), "Left Button: ");
		GUI.Label(new Rect(155, 245, 200, 25), Input.GetButton("win LB").ToString());
		
		GUI.Label(new Rect(5, 265, 200, 25), "Right Button: ");
		GUI.Label(new Rect(155, 265, 200, 25), Input.GetButton("win RB").ToString());
		
		GUI.Label(new Rect(5, 285, 200, 25), "pad horizontal: ");
		GUI.Label(new Rect(155, 285, 200, 25), Input.GetAxis("win dhorizontal").ToString());

		GUI.Label(new Rect(5, 305, 200, 25), "pad vertical: ");
		GUI.Label(new Rect(155, 305, 200, 25), Input.GetAxis("win dvertical").ToString());
		
		GUI.Label(new Rect(5, 325, 200, 25), "Back Button: ");
		GUI.Label(new Rect(155, 325, 200, 25), Input.GetButton("win back").ToString());
		
		GUI.Label(new Rect(5, 345, 200, 25), "Start Button: ");
		GUI.Label(new Rect(155, 345, 200, 25), Input.GetButton("win start").ToString());
		
		/*GUI.Label(new Rect(5, 365, 200, 25), "XBox Button: ");
		GUI.Label(new Rect(155, 365, 200, 25), Input.GetButton("XBox").ToString());*/
	}
}
