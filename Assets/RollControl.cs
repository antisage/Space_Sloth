using UnityEngine;
using System.Collections;

public class RollControl : MonoBehaviour
{
	public float doubleTapDelay = 0.25f;
	public float barrelRollDuration = 0.25f;
	public float returnSpeed = .005f;
	public float inverse = 1;
	
	private float time = float.MaxValue;
	private bool buttonDown = false;
	private bool inBarrelRoll = false;
	private float dir = 0;
	private Vector3 newRotationEuler;
	private float oldBankAxis = 0;
	private bool ReadytoRollagain = true;

	// Update is called once per frame
	void Update ()
	{
		if(!inBarrelRoll)
		{
			float bankAxis = Input.GetAxis("Roll");

			newRotationEuler = transform.rotation.eulerAngles;

			if(bankAxis != 0) {

					newRotationEuler.z = -90*bankAxis*inverse;
					oldBankAxis = bankAxis;
			}

			else {
				ReturnControl();
			}

			Quaternion newQuat = Quaternion.identity;
			newQuat.eulerAngles = newRotationEuler;
			transform.rotation = newQuat;
			
			
			if(bankAxis == 0)
			{
				buttonDown = false;
			}
			else if(buttonDown == false)
			{
				buttonDown = true;
				if(time < doubleTapDelay)
				{
					dir = bankAxis;
					StartCoroutine("BarrelRoll");
				}
				time = 0.0f;
			}
			
			time += Time.deltaTime;
		}
	}

	void ReturnControl(){
		if(oldBankAxis > returnSpeed) {
			oldBankAxis -= returnSpeed;
			newRotationEuler.z = -90*oldBankAxis*inverse;
		}
		else if(oldBankAxis < returnSpeed*-1) {
			oldBankAxis += returnSpeed;
			newRotationEuler.z = -90*oldBankAxis*inverse;
		}
		else {
			oldBankAxis = 0;
			newRotationEuler.z = 0;
		}
	}
	
	IEnumerator BarrelRoll()
	{
		inBarrelRoll = true;
		float t = 0.0f;
		
		Vector3 initialRotation = transform.localRotation.eulerAngles;
		
		Vector3 goalRotation = initialRotation;
		if(dir > 0){
			goalRotation.z -= 180.0f*inverse;
		}
		else {
			goalRotation.z += 180.0f*inverse;
		}
		
		Vector3 currentRotation = initialRotation;
		
		while(t < barrelRollDuration/2.0f)
		{
			currentRotation.z = Mathf.Lerp(initialRotation.z,goalRotation.z,t/(barrelRollDuration/2.0f));
			transform.localRotation = Quaternion.Euler(currentRotation);
			t += Time.deltaTime;
			yield return null;
		}
		
		t = 0;
		
		initialRotation = transform.localRotation.eulerAngles;
		goalRotation = initialRotation;
		if(dir > 0){
			goalRotation.z -= 180.0f*inverse;
		}
		else {
			goalRotation.z += 180.0f*inverse;
		}
		
		while(t < barrelRollDuration/2.0f)
		{
			currentRotation.z = Mathf.Lerp(initialRotation.z,goalRotation.z,t/(barrelRollDuration/2.0f));
			transform.localRotation = Quaternion.Euler(currentRotation);
			t += Time.deltaTime;
			yield return null;
		}
		
		inBarrelRoll = false;
	}
}