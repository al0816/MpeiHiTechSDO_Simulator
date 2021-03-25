using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AirplaneController : MonoBehaviour
{
    [SerializeField]
    float rollControlSensitivity = 0.2f;
    [SerializeField]
    float pitchControlSensitivity = 0.2f;
    [SerializeField]
    float yawControlSensitivity = 0.2f;
    [SerializeField]
    float thrustControlSensitivity = 0.01f;
    [SerializeField]
    float flapControlSensitivity = 0.15f;
public float maxSpeed = 200f;

    float pitch;
    float yaw;
    float roll;
    float flap;
	float kek;

    float thrustPercent;
    bool brake = false;

    AircraftPhysics aircraftPhysics;
    Rotator propeller;

    private void Start()
    {
        aircraftPhysics = GetComponent<AircraftPhysics>();
        propeller = FindObjectOfType<Rotator>();
	ScoreScript.theScore=0;
        SetThrust(0);
    }

    private void Update()
    {
		
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            SetThrust(thrustPercent + thrustControlSensitivity);
        }
	
        propeller.speed = thrustPercent * 1500f;
		
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            thrustControlSensitivity *= -1;
            flapControlSensitivity *= -1;
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            brake = !brake;
			if(brake==true)
			{
				if(maxSpeed>=1)
				{
				maxSpeed--;
				}
			}
			
			
        }
		

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            flap += flapControlSensitivity;
            //clamp
            flap = Mathf.Clamp(flap, 0f, Mathf.Deg2Rad * 40);
        }

        pitch = pitchControlSensitivity * Input.GetAxis("Vertical");
        roll = rollControlSensitivity * Input.GetAxis("Horizontal");
        yaw = yawControlSensitivity * Input.GetAxis("Yaw");
    }

    private void SetThrust(float percent)
    {
        thrustPercent = Mathf.Clamp01(percent);
    }

    private void FixedUpdate()
    {
		if(GetComponent<Rigidbody>().velocity.magnitude > maxSpeed)
         {
                GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity.normalized * maxSpeed;
         }
		 if(brake==true)
			{
				if(maxSpeed>=10)
				{
				maxSpeed-=0.5f;
				}
			}
			else
			{
				maxSpeed=200f;
			}
        aircraftPhysics.SetControlSurfecesAngles(pitch, roll, yaw, flap);
        aircraftPhysics.SetThrustPercent(thrustPercent);
        aircraftPhysics.Brake(brake);
    }
}
