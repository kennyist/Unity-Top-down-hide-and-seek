using UnityEngine;
using System.Collections;

public class HiderControls : MonoBehaviour {
	
	private ScoreManager scrMngr =  new ScoreManager();
	
	public float speed = 300f;
	public float maxSpeed;
	
	public GameObject directionArrow;
	
	private Vector3 pos;
	private Quaternion rot;
	
	private float time;
	private bool visable = false;
	
	// ----
	
	public Camera camera;
	private Vector3 worldPos;
	private float mouseX;
	private float mouseY;
	
	// ------
	
	void Start(){
		pos = transform.position;
		rot = transform.rotation;
	}
	
	void Update(){
		transform.position = new Vector3(transform.position.x, pos.y, transform.position.z);
		
		if(visable && Time.time >= time){
			visable = false;
			gameObject.layer = 9;
			scrMngr.AddNearMiss(true);
		}
		
		// ---
		
		mouseX = Input.mousePosition.x;
		mouseY = Input.mousePosition.y;
		
		worldPos = camera.ScreenToWorldPoint(new Vector3(mouseX,mouseY,3f));
		
		transform.LookAt(worldPos);
		
		if(mouseX > Screen.width / 2){ Screen.showCursor = true; } else { Screen.showCursor = false; }
	}

	void FixedUpdate () {
		
		if(Input.GetKey(KeyCode.UpArrow) && rigidbody.velocity.magnitude < maxSpeed){			
			rigidbody.AddForce(Vector3.forward * speed * Time.deltaTime);
		}
		
		if(Input.GetKey(KeyCode.DownArrow) && rigidbody.velocity.magnitude < maxSpeed){
			rigidbody.AddForce(-Vector3.forward * speed * Time.deltaTime);
		}
		
		if(Input.GetKey(KeyCode.LeftArrow) && rigidbody.velocity.magnitude < maxSpeed){
			rigidbody.AddForce(Vector3.left * speed * Time.deltaTime);
		}
		
		if(Input.GetKey(KeyCode.RightArrow) && rigidbody.velocity.magnitude < maxSpeed){
			rigidbody.AddForce(-Vector3.left * speed * Time.deltaTime);
		}
	}
	
	public void SetVisable(){
		if(!visable){
			gameObject.layer = 10;
			time = Time.time + 10f;
			visable = true;
		}
	}
	
	void OnCollisionEnter(Collision col){
		if(col.gameObject.tag == "Seeker"){	
			if(gameObject.layer == 10){
				GameObject tempOBJ = GameObject.FindGameObjectWithTag("GUIscripts");
				tempOBJ.GetComponent<MainGUI>().EndGame(true);
			}
		}
	}
}
