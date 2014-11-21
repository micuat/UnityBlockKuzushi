using UnityEngine;
using System.Collections;

public class UnitychanScript : MonoBehaviour {

	private Animator animator;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		animator.SetBool("isDamaged", false);
	}
	
	// Update is called once per frame
	void Update () {
  	}

	public void DoRun() {
		animator.SetBool("isDamaged", true);
	}
}
