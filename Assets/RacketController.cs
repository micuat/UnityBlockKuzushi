using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityOSC;

public class RacketController : MonoBehaviour {

	private float Accel = 1000.0f;
    private Dictionary<string, ServerLog> servers;

	// Use this for initialization
	void Start () {
        OSCHandler.Instance.Init(); //init OSC
        servers = new Dictionary<string, ServerLog>();
    }
	
	// Update is called once per frame
	void Update () {
		rigidbody.AddForce(transform.right * Input.GetAxisRaw("Horizontal") * Accel, ForceMode.Impulse);

        OSCHandler.Instance.UpdateLogs();
        servers = OSCHandler.Instance.Servers;

        foreach (KeyValuePair<string, ServerLog> item in servers)
        {
            // If we have received at least one packet,
            // show the last received from the log in the Debug console
            foreach(OSCPacket packet in item.Value.packets)
            {
                rigidbody.AddForce(-transform.right * (float)packet.Data[1] * Accel * 0.02f, ForceMode.Impulse);
            }
        }
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
