using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureSensor : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	// void OnCollisionExit2D (Collision2D col) {
	// 	Camera.main.GetComponent<ShatterMain>().youwin1 = true;
	// }
	void OnCollisionEnter2D(Collision2D col) {
		if (col.transform.gameObject.name == "Treasure")
		{
		Camera.main.GetComponent<ShatterMain>().youwin1 = true;
		}
		else if(col.transform.gameObject.tag == "Player" && col.transform.gameObject!= this.gameObject && this.gameObject.name != "Treasure")
		{
			col.transform.FindChild("text").gameObject.SetActive(true);
		}
	}
}
