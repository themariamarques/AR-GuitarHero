using UnityEngine;
using System.Collections;
using System;

public class Note : MonoBehaviour {

    Rigidbody rb;
    public float speed;

    void Awake() {
        rb=GetComponent<Rigidbody>();
    }

	// Use this for initialization
	void Start () {        

    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(0, 0, -speed * Time.deltaTime);
    }

    public void SetSpeed(float spd) {
        speed = spd;
    }

    internal void setSpeed(float v)
    {
        speed = v;
    }
}
