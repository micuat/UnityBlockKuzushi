using UnityEngine;
using System.Collections;

public class BlockGenerator : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		for (float y = 0; y < 6; y++) {
			for (float x = 0; x < 6; x++) {
				GameObject box = (GameObject)Instantiate (Resources.Load<GameObject>("Block1"), new Vector3 (-7.5f + x * 3.0f, 0.0f, 24.0f + y), Quaternion.identity);
				HSBColor color = new HSBColor(y / 10.0f, 1.0f, 1.0f, 0.2f);
				box.renderer.material.color = color.ToColor();
				box.renderer.material.shader = Shader.Find("Transparent/Diffuse");
 			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
