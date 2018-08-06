using UnityEngine;
using System.Collections;

public class PickUpObjects : MonoBehaviour {
	
	public Camera camera;
	private RaycastHit hit;
	bool carry = false;

	public Transform seeker;

	void Update () {

		if(Vector3.Distance(transform.position,seeker.position) < 1){
			carry = false;
			end();
		}


		if(Input.GetMouseButtonUp(0)){
			if(carry){
				end ();
			} else {
				
				if(Input.mousePosition.x > Screen.width / 2){
					Physics.Raycast(camera.ScreenPointToRay(Input.mousePosition), out hit, 100f);
					Debug.Log(hit.transform.gameObject.name);
					
					if(Vector3.Distance(transform.position, hit.transform.gameObject.transform.position) < 1 && hit.transform.gameObject.tag != "Seeker" && hit.transform.gameObject.tag != "Hider"){
						hit.rigidbody.useGravity = false;
						carry = true;
					}
				}
			}
		}
		
		if(carry){
			Carry();	
		}
		
	}

	void end(){
		carry = false;
		hit.rigidbody.useGravity = true;
		hit = new RaycastHit();
	}
	
	void Carry(){
		Rigidbody hitRidg = hit.transform.gameObject.rigidbody;
		
		hitRidg.MoveRotation(transform.rotation);
		
		Vector3 newPos = new Vector3(transform.position.x,transform.position.y + 0.1f,transform.position.z);
		hitRidg.MovePosition(newPos + transform.forward * 0.3f);
		
	}
}
