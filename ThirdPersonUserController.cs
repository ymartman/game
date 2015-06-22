namespace User.Control {

using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class ThirdPersonUserController : MonoBehaviour {

	private Transform camera_Transform;
	private bool is_Jump; 
	private bool is_Atack;
	private Vector3 vec_CamForward; 
	private Vector3 vec_Move;

	// Use this for initialization
	void Start () {
		// get the transform of the main camera
		if (Camera.main != null)
		{
			camera_Transform = Camera.main.transform;
		}
		else
		{
			Debug.LogWarning(
				"Warning: no main camera found. Third person character needs a Camera tagged \"MainCamera\", for camera-relative controls.");
		}
	}
	
	// Update is called once per frame
	void Update () {

		if (!is_Jump)
		{
			is_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
		}
					
		if (!is_Atack)
		{
			is_Atack = CrossPlatformInputManager.GetButtonDown("Jump");
		}
	
	}

		private void FixedUpdate()
		{
			// read inputs
			//TODO store inputs in separate file
			float h = CrossPlatformInputManager.GetAxis("Horizontal");
			float v = CrossPlatformInputManager.GetAxis("Vertical");
			//TODO why here? Maybe move to update
			bool crouch = Input.GetKey(KeyCode.C);
			
			// calculate move direction to pass to character
			//TODO Think what should be used for navigation mouse, or keyboard/joystick and change to fit.
			if (camera_Transform != null)
			{

				// calculate camera relative direction to move:
				vec_CamForward = Vector3.Scale(camera_Transform.forward, new Vector3(1, 0, 1)).normalized;
				vec_Move = v*vec_CamForward + h*camera_Transform.right;
			}
			else
			{
				// we use world-relative directions in the case of no main camera
				vec_Move = v*Vector3.forward + h*Vector3.right;
			}
			// pass all parameters to the character control script
			//TODO think about more suitable form of params, additional class perhaps
			//	m_Character.Move(m_Move, crouch, m_Jump);
			is_Jump = false;
		}
}
}