
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPScontroller : MonoBehaviour {

	public float  moveSpeed = 3f, jumpforce = 4f;
	public GameObject eyes;
	private float moveFB, moveLR, vertVel;
	private CharacterController Player;
	private bool hasjumped, iscrouched;

    public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
    public RotationAxes axes = RotationAxes.MouseXAndY;
    public float speed = 1.0f;
    public float sensitivityX = 0.2F;
    public float sensitivityY = 0.2f;
    public float minimumY = -60F;
    public float maximumY = 60F;
    float rotationY = 0F;


    void Start () {

        Player = GetComponent<CharacterController>();

	}


    void Update()
    {
		Movement ();

		if (Input.GetButtonDown ("Jump")) {
			hasjumped = true;
		}

		if (Input.GetButtonDown ("Crouch")) {
			if (iscrouched == false) {				
				Player.height = Player.height / 2;
				iscrouched = true;
			} else {
				Player.height = Player.height * 2;
				iscrouched = false;
			}
		}

		ApplyGravity ();

        Rotation();
	}

	void Movement(){
		//input de WASD
		moveFB = Input.GetAxis ("Vertical") * moveSpeed;
		moveLR = Input.GetAxis ("Horizontal") * moveSpeed;

		//controla el moviemiento del personaje
		Vector3 movement = new Vector3 (moveLR, vertVel, moveFB);

		//rota la camara en el eje Y
		//eyes.transform.localRotation = Quaternion.Euler (rotY, 0, 0);

		//fix para la orientacion
		movement = transform.rotation * movement;

		//mueve al personaje
		Player.Move (movement * Time.deltaTime);
	}
		
	private void ApplyGravity(){
		if (Player.isGrounded == true) {
			if (hasjumped == false) {
				vertVel = Physics.gravity.y;
			} else {
				vertVel = jumpforce;
			}
		} else {
			vertVel += Physics.gravity.y * Time.deltaTime;
			vertVel = Mathf.Clamp (vertVel, -50f, jumpforce);
			hasjumped = false;
		}
	}
    public void Rotation()
    {
        if (axes == RotationAxes.MouseXAndY)
        {
            float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;

            rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
            rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

            eyes.transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
        }
        else if (axes == RotationAxes.MouseX)
        {
            eyes.transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityX, 0);
        }
        else
        {
            rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
            rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

            eyes.transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0);
        }
    }

}
