using UnityEngine;
using System.Collections;

public class FloorController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision collision) {
		if( Mathf.Abs(collision.relativeVelocity.y) > 1.0f )
		collision.gameObject.SendMessage("HitFloor", 0);
	}
}
