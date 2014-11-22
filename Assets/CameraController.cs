using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	private Vector3 offset = new Vector3(0.0f, 1.0f, 0.0f);

	// Update is called once per frame
	void Update () {
		transform.LookAt (transform.parent.transform.position + offset);
	}
}
