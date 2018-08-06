using UnityEngine;
using System.Collections;

public class SeekerControls : MonoBehaviour {

	public float speed = 300f;
	public Light light;
	public float maxSpeed;
	
	private Vector3 pos;
	private Quaternion rot;
	
	private float time;
	private bool visable = false;

	string type = "win";
	
	void Start(){
		pos = transform.position;
		rot = transform.rotation;

		if (Application.platform == RuntimePlatform.OSXPlayer){
			type = "mac";
		} else {
			type = "win";
		}
	}
	
	void Update(){
		transform.position = new Vector3(transform.position.x, pos.y, transform.position.z);
		transform.rotation = new Quaternion(rot.x, rot.y, rot.z,transform.rotation.w);
		
		if(visable && Time.time >= time){
			visable = false;
			gameObject.layer = 8;
		}
	}

	void FixedUpdate () {
		
		light.transform.position = new Vector3(transform.position.x,transform.position.y + 8,transform.position.z);
		
		if((Input.GetKey(KeyCode.W) || Input.GetAxis(type + " vertical") > 0.5 )&& rigidbody.velocity.magnitude < maxSpeed){			
			rigidbody.AddForce(-Vector3.forward * speed * Time.deltaTime);
		}
		
		if((Input.GetKey(KeyCode.S) || Input.GetAxis(type + " vertical") < -0.5 )&& rigidbody.velocity.magnitude < maxSpeed){
			rigidbody.AddForce(Vector3.forward * speed * Time.deltaTime);
		}

		if((Input.GetKey(KeyCode.A) || Input.GetAxis(type + " horizontal") < -0.5 ) && rigidbody.velocity.magnitude < maxSpeed){
			rigidbody.AddForce(-Vector3.left * speed * Time.deltaTime);
		}
		
		if((Input.GetKey(KeyCode.D) || Input.GetAxis(type + " horizontal") > 0.5 )&& rigidbody.velocity.magnitude < maxSpeed){
			rigidbody.AddForce(Vector3.left * speed * Time.deltaTime);
		}		
	}
	
	public void SetVisable(){
		if(!visable){
			gameObject.layer = 10;
			time = Time.time + 10f;
			visable = true;
		}
	}
}
