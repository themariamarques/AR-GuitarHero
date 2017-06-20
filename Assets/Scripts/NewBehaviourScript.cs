using UnityEngine;
using System.Collections;
using Vuforia;
using System;

public class NewBehaviourScript : MonoBehaviour, IVirtualButtonEventHandler {

    public GameObject btn1;

    // Use this for initialization
    void Start () {
        btn1.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
        
	}

    public void OnButtonPressed(VirtualButtonAbstractBehaviour vb){
        btn1.SetActive(false);
        Debug.Log("pressed down !!!!!!!!!!!!");
    }

    public void OnButtonReleased(VirtualButtonAbstractBehaviour vb){
        btn1.SetActive(true);
        Debug.Log("r!e!l!e!a!s!e!d!");
    }
}
