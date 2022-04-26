using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createBall : MonoBehaviour {

	private Transform[] tChildren;
	void Start () {
		
	}
	
	void Update () {
		tChildren = this.GetComponentsInChildren<Transform>();
		
	}
}
