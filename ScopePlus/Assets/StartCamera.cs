﻿using UnityEngine;
using System.Collections;

public class StartCamera : MonoBehaviour {
	
	public int deviceNumber;
	MeshRenderer mr;
	// Use this for initialization
	void Start () {
		AVProLiveCameraManager.Instance.GetDevice (deviceNumber).Start (-1);
		mr = GetComponent<MeshRenderer> ();
	}

	private void UpdateCameras()
	{
		// Update all cameras
		/*int numDevices = AVProLiveCameraManager.Instance.NumDevices;
		//Debug.Log (numDevices);
		for (int i = 0; i < numDevices; i++)
		{
			AVProLiveCameraDevice device = AVProLiveCameraManager.Instance.GetDevice(i);
			
			// Update the actual image
			device.Update(false);
		}*/
		AVProLiveCameraDevice device = AVProLiveCameraManager.Instance.GetDevice(deviceNumber);
		device.Update(false);
		mr.material.mainTexture = AVProLiveCameraManager.Instance.GetDevice (deviceNumber).OutputTexture;
	}
	
	private int _lastFrameCount;
	void OnRenderObject()
	{
		if (_lastFrameCount != Time.frameCount)
		{
			_lastFrameCount = Time.frameCount;
			
			UpdateCameras();
		}
	}
	
/*	void Update () {
		//Right Plane
		//AVProLiveCameraManager.
		mr.material.mainTexture = AVProLiveCameraManager.Instance.GetDevice (deviceNumber).OutputTexture;
	}*/
}
