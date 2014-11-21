using UnityEngine;
using System.Collections;

public class RacketController : MonoBehaviour {

	private float Accel = 1000.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		rigidbody.AddForce(transform.right * Input.GetAxisRaw("Horizontal") * Accel, ForceMode.Impulse);
	}

	private float tolerance = 0.5f;
	
	void OnCollisionEnter(Collision collision) { 
		ContactPoint contact = collision.contacts [0];
		Vector3 p = contact.point - gameObject.transform.position;
		print (p);
		if (Mathf.Abs(p.x) < tolerance) {
			collision.gameObject.SendMessage ("Bakuretsu", true);
		} else {
			collision.gameObject.SendMessage ("Bakuretsu", false);
		}
	}
}
