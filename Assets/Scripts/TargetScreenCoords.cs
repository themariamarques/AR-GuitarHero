using UnityEngine;
using System.Collections;
using Vuforia;

public class TargetScreenCoords : MonoBehaviour {

	private ImageTargetBehaviour mImageTargetBehaviour = null;
	public int xCoordBL, yCoordBL, xCoordTL, yCoordTL, xCoordBR, yCoordBR, xCoordTR, yCoordTR, div;

	// Use this for initialization
	void Start () {
		// We retrieve the ImageTargetBehaviour component
		// Note: This only works if this script is attached to an ImageTarget
		mImageTargetBehaviour = GetComponent<ImageTargetBehaviour>();

		if (mImageTargetBehaviour == null)
		{
			Debug.Log ("ImageTargetBehaviour not found ");
		}
	}

	// Update is called once per frame
	void Update () {
		if (mImageTargetBehaviour == null)
		{
			Debug.Log ("ImageTargetBehaviour not found");
			return;
		}

		Vector2 targetSize = mImageTargetBehaviour.GetSize();
		float targetAspect = targetSize.x / targetSize.y;

		// We define a point in the target local reference 
		// we take the bottom-left corner of the target, 
		// just as an example
		// Note: the target reference plane in Unity is X-Z, 
		// while Y is the normal direction to the target plane
		//Bottom Left
		Vector3 pointOnTargetBL = new Vector3(-0.5f, 0, -0.5f/targetAspect);
		//Top Left
		Vector3 pointOnTargetTL = new Vector3(-0.5f, 0, 0.5f/targetAspect);
		//Bottom Right
		Vector3 pointOnTargetBR = new Vector3(0.5f, 0, -0.5f/targetAspect);
		//Top Right
		Vector3 pointOnTargetTR = new Vector3(0.5f, 0, 0.5f/targetAspect);

		// We convert the local point to world coordinates
		Vector3 targetPointInWorldRefBL = transform.TransformPoint(pointOnTargetBL);
		Vector3 targetPointInWorldRefTL = transform.TransformPoint(pointOnTargetTL);
		Vector3 targetPointInWorldRefBR = transform.TransformPoint(pointOnTargetBR);
		Vector3 targetPointInWorldRefTR = transform.TransformPoint(pointOnTargetTR);

		// We project the world coordinates to screen coords (pixels)
		Vector3 screenPointBL = Camera.main.WorldToScreenPoint(targetPointInWorldRefBL);
		Vector3 screenPointTL = Camera.main.WorldToScreenPoint(targetPointInWorldRefTL);
		Vector3 screenPointBR = Camera.main.WorldToScreenPoint(targetPointInWorldRefBR);
		Vector3 screenPointTR = Camera.main.WorldToScreenPoint(targetPointInWorldRefTR);

		xCoordBL = (int)screenPointBL.x;
		yCoordBL = (int)screenPointBL.y;
		xCoordTL = (int)screenPointTL.x;
		yCoordTL = (int)screenPointTL.y;
		xCoordBR = (int)screenPointBR.x;
		yCoordBR = (int)screenPointBR.y;
		xCoordTR = (int)screenPointTR.x;
		yCoordTR = (int)screenPointTR.y;

		//Debug.Log (mImageTargetBehaviour + "coords BL: " + xCoordBL + ", " + yCoordBL);
		//Debug.Log (mImageTargetBehaviour + "coords TL: " + xCoordTL + ", " + yCoordTL);
		//Debug.Log (mImageTargetBehaviour + "coords BR: " + xCoordBR + ", " + yCoordBR);
		//Debug.Log (mImageTargetBehaviour + "coords TR: " + xCoordTR + ", " + yCoordTR);

	}

	public int getMidPoint(int div){
		return (yCoordTL - yCoordBL)/div;
	}

	public int getBLXCoord(){
		return xCoordBL;
	}

	public int getBLYCoord(){
		return yCoordBL;
	}

	public int getTLXCoord(){
		return xCoordTL;
	}

	public int getTLYCoord(){
		return yCoordTL;
	}

	public int getBRXCoord(){
		return xCoordBR;
	}

	public int getBRYCoord(){
		return yCoordBR;
	}

	public int getTRXCoord(){
		return xCoordTR;
	}

	public int getTRYCoord(){
		return yCoordTR;
	}
}