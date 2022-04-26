using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bounce : MonoBehaviour {

	public float fSpeed = 200;
	public GameObject gPlaneManager;

	private Transform[] tChildren;
	private Transform tNext;
	private bool bBounce = false;

	void Start () {
		
	}
	
	void Update () {
		tChildren = gPlaneManager.GetComponentsInChildren<Transform>();
		if (!bBounce && tNext.gameObject.tag == "Bounced") {
			this.GetComponent<Transform>().position = Vector3.Lerp(this.GetComponent<Transform>().position, tNext.position, 0.03f);
		}
	}

	void OnCollisionEnter(Collision collision) {
		this.GetComponent<Rigidbody>().AddForce(new Vector3(0, fSpeed * Time.deltaTime * 120, 0));
		if (bBounce) {
			tNext = GetNextPlane(tChildren);
		}
		if (tNext == null) {
			// reset all bounce
		}
		bBounce = !bBounce;
	}

	Transform GetNextPlane(Transform[] tPlanes)
	{
		foreach (Transform t in tPlanes)
		{
			if (t.gameObject.tag != "Bounced" && t != tPlanes[0]) {
				t.gameObject.tag = "Bounced";
				return t;
			}
		}
		return null;
	}
}
