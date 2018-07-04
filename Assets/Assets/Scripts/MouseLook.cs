using System;
using UnityEngine;

public class MouseLook: MonoBehaviour
{
	public Transform Character;
	public Transform Camera;
	public float xMouseSensitivity = 0.0f;
	public float yMouseSensitivity = 0.0f;
	public float clampAngle = 30.0f;

	private Quaternion characterTargetRot;
	private Quaternion cameraTargetRot;



	void Start ()
	{
		
		characterTargetRot = Character.localRotation;
		cameraTargetRot = Camera.localRotation;


	}

	void LateUpdate ()
	{
		

		float rotY = Input.GetAxis ("Mouse X") * xMouseSensitivity;
		float rotX = Input.GetAxis ("Mouse Y") * yMouseSensitivity;

		characterTargetRot *= Quaternion.Euler (0f, rotY, 0f);
		cameraTargetRot *= Quaternion.Euler (-rotX, 0f, 0f);

		cameraTargetRot.x /= cameraTargetRot.w;
		cameraTargetRot.y /= cameraTargetRot.w;
		cameraTargetRot.z /= cameraTargetRot.w;
		cameraTargetRot.w = 1.0f;
		float angleX = 2.0f * Mathf.Rad2Deg * Mathf.Atan (cameraTargetRot.x);
		angleX = Mathf.Clamp (angleX, -clampAngle, clampAngle);
		cameraTargetRot.x = Mathf.Tan (0.5f * Mathf.Deg2Rad * angleX);


		Character.localRotation = characterTargetRot;
		Camera.localRotation = cameraTargetRot;

	}
}






