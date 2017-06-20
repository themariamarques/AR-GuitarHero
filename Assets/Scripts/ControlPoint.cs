using UnityEngine;
using System.Collections;
using Vuforia;
using System;

public class ControlPoint : MonoBehaviour, IVirtualButtonEventHandler {

    public GameObject button;
    public GameObject controlPoint;
    GameObject note;
    public String cmp_tag;
    bool active = false;
    public bool createMode;
    public KeyCode key;
    public GameObject n;
    public Note no;
    public ScoreText stxt;

    // Use this for initialization
    void Start () {
        button.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
	}
	
	// Update is called once per frame
	void Update () {
        if (createMode && Input.GetKeyDown(key)) {
            n = GameObject.Find("red_note (1)");
            GameObject nob = Instantiate(n, n.transform.position, Quaternion.identity, GameObject.Find("red_note (1)").transform.parent) as GameObject;
            nob.transform.rotation = n.transform.rotation;
            nob.GetComponent<Note>().setSpeed((float)0.33);
            
        }
	}

    void OnTriggerEnter(Collider col)
    {
        active = true;
        if (col.gameObject.tag == cmp_tag)
        {
            note = col.gameObject;
        }
    }

    void OnTriggerExit(Collider col)
    {
        active = false;

    }

    public void OnButtonPressed(VirtualButtonAbstractBehaviour vb) {
        if (active)
        {
            stxt.AddScore();
            Destroy(note);
            active = false;
        }
    }

    public void OnButtonReleased(VirtualButtonAbstractBehaviour vb) {
        Debug.Log("! ! ! SOLTEI ! ! !");
    }
}
