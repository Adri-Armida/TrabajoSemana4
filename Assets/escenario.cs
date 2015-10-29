using UnityEngine;
using System.Collections;

public class escenario : MonoBehaviour {

	public bool dentro = true;
	
	
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
			dentro = true;
	}
	
	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "Player")
			dentro = false;
	}
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (dentro == false) {
			gameObject.transform.Translate(new Vector3(0,-1,0));
			Destroy (this, 1f);
		} else {
			GetComponent<Rigidbody> ().useGravity = false;
		}
	}
}
