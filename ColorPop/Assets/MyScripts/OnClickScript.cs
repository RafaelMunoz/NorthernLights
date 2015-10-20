using UnityEngine;
using System.Collections;

public class OnClickScript : MonoBehaviour {

	public Rigidbody touchParticle;

	// Use this for initialization
	void Start () {
	
	}

	void OnMouseDown ()
	{
		Instantiate (touchParticle);
		Destroy (gameObject);

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
