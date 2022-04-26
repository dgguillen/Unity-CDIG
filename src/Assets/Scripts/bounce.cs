using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bounce : MonoBehaviour {

	public float velocidad = 200;
	public GameObject gestorPlanos;

	private Transform[] children;
	private Transform closest;
	private bool penis = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		children = gestorPlanos.GetComponentsInChildren<Transform>();
		if (penis) {
			this.GetComponent<Transform>().position = Vector3.Lerp(this.GetComponent<Transform>().position, closest.position, 0.02f);
		}
	}

	void OnCollisionEnter(Collision collision) {
		//Random.Range(350.0f, 500.0f)
		this.GetComponent<Rigidbody>().AddForce(new Vector3(0, 350 * Time.deltaTime * 100, 0));

		closest = GetClosestEnemy(children, collision);
		Vector3 currentDirection = (closest.position-this.GetComponent<Transform>().position).normalized;
		Debug.Log(closest.position);
		penis = !penis;
		//this.GetComponent<Transform>().Translate(Vector3.Lerp(this.GetComponent<Transform>().position, closest.position, 2f) * Time.deltaTime * velocidad * 300);
	}

	Transform GetClosestEnemy(Transform[] enemies, Collision collision)
	{
		Transform tMin = null;
		float minDist = Mathf.Infinity;
		Vector3 currentPos = transform.position;
		foreach (Transform t in enemies)
		{
			float dist = Vector3.Distance(t.position, currentPos);
			if (dist < minDist && collision.transform != t && t != enemies[0])
			{
				tMin = t;
				minDist = dist;
			}
		}
		return tMin;
	}
}
