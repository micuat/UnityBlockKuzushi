using UnityEngine;
using System.Collections;

public class BlockController : MonoBehaviour {
	private UnitychanScript uscript;
	private GameObject ball;

	// Use this for initialization
	void Start () {
		uscript = GameObject.Find("unitychan").GetComponent<UnitychanScript>();
		ball = GameObject.Find("Sphere");
	}
	
	// Update is called once per frame
	void Update () {
//	if (ball.GetComponent<BallController> ().bakuretsu) {
//						collider.enabled = false;
//				} else {
//						collider.enabled = true;
//				}
//
	}

	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject == ball) {
			collider.enabled = false;
			collision.gameObject.SendMessage("HitBlock");
			uscript.DoRun ();
			Destroy (gameObject);
		}
 	}
}
