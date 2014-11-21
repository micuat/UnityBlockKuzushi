using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour {

	private float Speed = 10.0f;
	private bool started = false;
	public bool bakuretsu = false;
	private Vector3 prevSpeed = new Vector3 ();

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Space) && !started) {
			rigidbody.AddForce((transform.forward + transform.right) * Speed, ForceMode.VelocityChange);
			started = true;
		}

		if (Input.GetKey (KeyCode.A) ) {
			HitBottomWall(); 
		}

		if (transform.position.y < -0.1) {
			HitBottomWall ();
		}

		prevSpeed = rigidbody.velocity;
	}

	void HitBottomWall() {
		//Destroy (this.gameObject);
		rigidbody.velocity = new Vector3 (0, 0, 0);
		transform.position = new Vector3 (0, 0, 7); 
		started = false; 
	}

	void HitBlock() {
 		if (bakuretsu) {
			print ("bakuretsu");
			rigidbody.velocity = prevSpeed;
		}
	}

	void Bakuretsu(bool b) {
		bakuretsu = b;
		if (b) {
			renderer.material.color = new Color (1.0f, 0.0f, 0.0f, 1.0f);
		} else {
			renderer.material.color = new Color (1.0f, 1.0f, 1.0f, 1.0f);
		}
	}
}
