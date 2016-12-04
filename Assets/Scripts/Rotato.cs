using UnityEngine;
using System.Collections;

public class Rotato : MonoBehaviour {

    public float turnSpeed = 50f;
    Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        rb.transform.Rotate(0.0f, turnSpeed * Time.deltaTime, 0.0f);
	
	}
}
