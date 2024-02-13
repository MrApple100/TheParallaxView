﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this script doesn't actually select which eye to track (that happens in HeadTrackManager) 
// this script merely moves the eye camera to the correct place (taking IPD into account)
// and also move the red dots that represen the eyes to the correct places

public class SelectEye : MonoBehaviour {

	public HeadTrackManager headTrackManager;
	public CameraManager camManager;
	public Transform leftEye;
	public Transform rightEye;
	public Transform thirdEye;

    private Vector3 eyeye = Vector3.zero;


// Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 pos = transform.localPosition;
		float IPD = headTrackManager.IPD;
		float EyeHeight = headTrackManager.EyeHeight;

		float dist = IPD * 0.001f * 0.5f; //in metres and half
		float height = EyeHeight * 0.001f;


//if (headTrackManager.headCenter == HeadTrackManager.OpenEye.Right) { // move camera to open eye
        if (!camManager.DeviceCamUsed)
				pos.x = -dist;
			else
				pos.x = dist; // mirror in device cam
                              //} else {
                              //	if (!camManager.DeviceCamUsed)
                              //		pos.x = dist;
                              //	else
                              //		pos.x = -dist; 
                              //}


        

       // Debug.Log("X pos: " + pos);
        transform.localPosition = pos;

		pos = thirdEye.transform.localPosition;
		pos.y = height;
		thirdEye.transform.localPosition = pos;

		// update eye positions, only for visualization purpose

		rightEye.localPosition = new Vector3 (dist, 0, 0);
		leftEye.localPosition = new Vector3 (-dist, 0, 0);
        // look opposite direction of device cam
       


	}
}
