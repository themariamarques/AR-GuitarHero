using System;
using UnityEngine;
using System.Collections;

public class VolController : MonoBehaviour {

	public TargetScreenCoords tscGH;
	public TargetScreenCoords tscVOL;
	//public Audiosource barracuda;
	public AudioSource barracuda;
	int folga = 100;

	// Use this for initialization
	void Start () {
		//Debug.Log ("Volume START:" + barracuda.volume);
		barracuda.Play();
		barracuda.volume = 0.2F;
	}
	
	// Update is called once per frame
	void Update () {
		//max vol;
		if (similar (tscGH.getTRXCoord(), tscVOL.getTLXCoord()) && similar (tscGH.getTRYCoord(), tscVOL.getTLYCoord()) && notZero()) {
			barracuda.volume = 1F;
		}
		//med-max vol
		if (similar (tscGH.getBRXCoord(), tscVOL.getBLXCoord()) && similar (tscGH.getBRYCoord() + tscGH.getMidPoint(4) + tscGH.getMidPoint(2), tscVOL.getBLYCoord() + tscVOL.getMidPoint(4) + tscVOL.getMidPoint(2)) && notZero()) {
			barracuda.volume = 0.75F;
		}
		//med vol
		if (similar (tscGH.getBRXCoord(), tscVOL.getBLXCoord()) && similar (tscGH.getBRYCoord() + tscGH.getMidPoint(2), tscVOL.getBLYCoord() + tscVOL.getMidPoint(2)) && notZero()) {
			barracuda.volume = 0.5F;
		}
		//min-med vol
		if (similar (tscGH.getBRXCoord(), tscVOL.getBLXCoord()) && similar (tscGH.getBRYCoord() + tscGH.getMidPoint(4), tscVOL.getBLYCoord() + tscVOL.getMidPoint(4)) && notZero()) {
			barracuda.volume = 0.25F;
		}
		//min vol
		if (similar (tscGH.getBRXCoord(), tscVOL.getBLXCoord()) && similar (tscGH.getBRYCoord(), tscVOL.getBLYCoord()) && notZero()) {
			barracuda.volume = 0F;
		}

		//Debug.Log ("diff1:" + similar (tscGH.getBRXCoord (), tscVOL.getBLXCoord ()));
		//Debug.Log ("diff2:" + similar (tscGH.getBRYCoord (), tscVOL.getBLYCoord ()));
		//Debug.Log ("Volume:" + barracuda.volume);
		//Debug.Log ("GH TR:" + tscGH.getTRXCoord() + ", " + tscGH.getTRYCoord() + " | VOL TL " + tscGH.getTLYCoord() + ", " + tscVOL.getTLYCoord());
	}

	bool similar (float c1, float c2) {
		float diff = c1 - c2;

		if (Math.Abs(diff) <= folga)
			return true;
		else
			return false;
	}

	bool notZero () {
		if ((tscGH.getTRXCoord () * tscGH.getTRYCoord () * tscGH.getTLYCoord () * tscVOL.getTLYCoord ()) == 0)
			return false;
		else
			return true;
	}
}
