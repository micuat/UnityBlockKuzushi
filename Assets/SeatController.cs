using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityOSC;

public class SeatController : MonoBehaviour {
	
	private float Accel = 10.0f;
	private Dictionary<string, ServerLog> servers;
	
	// Use this for initialization
	void Start () {
		OSCHandler.Instance.Init(); //init OSC
		servers = new Dictionary<string, ServerLog>();
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 inputForce = new Vector2 (0.0f, 0.0f);
        float maxForce = 0.0f;

		inputForce.x += Input.GetAxisRaw ("Horizontal");
		inputForce.y += Input.GetAxisRaw ("Vertical");

		OSCHandler.Instance.UpdateLogs();
		servers = OSCHandler.Instance.Servers;
		
		foreach (KeyValuePair<string, ServerLog> item in servers)
		{
			// If we have received at least one packet,
			// show the last received from the log in the Debug console
			foreach(OSCPacket packet in item.Value.packets)
			{
                Vector2 oscForce = new Vector2((float)packet.Data[1] * 0.02f, (float)packet.Data[0] * 0.02f);
                inputForce += oscForce;
                maxForce = Mathf.Max(maxForce, oscForce.magnitude);
			}
		}

//		rigidbody.AddForce((transform.right * inputForce.x + transform.forward * inputForce.y) * Accel, ForceMode.Impulse);
		rigidbody.AddForce((transform.forward * inputForce.y) * Accel, ForceMode.Impulse);
		Vector3 torque = new Vector3 (0.0f, inputForce.x, 0.0f);
		rigidbody.AddTorque (torque * 10.0f);

        OSCHandler.Instance.SendMessageToClient("SuperCollider", "/floor/vibrate", gameObject.rigidbody.velocity.magnitude);
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
