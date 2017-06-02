using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPScontroller : MonoBehaviour {

	public float mouseSensitivity = 3f, moveSpeed = 3f, jumpforce = 4f;
	public GameObject eyes;
	private float moveFB, moveLR, rotX, rotY, vertVel;
	private CharacterController Player;
	private bool hasjumped, iscrouched;


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
	}

	void Movement(){
		//input de WASD
		moveFB = Input.GetAxis ("Vertical") * moveSpeed;
		moveLR = Input.GetAxis ("Horizontal") * moveSpeed;

		//input del Mouse
		//rotX = Input.GetAxis ("Mouse X") * mouseSensitivity;
		//rotY = Input.GetAxis ("Mouse Y") * mouseSensitivity;

		//controla el moviemiento del personaje
		Vector3 movement = new Vector3 (moveLR, vertVel, moveFB);

		//rota el personaje
		transform.Rotate (0, rotX, 0);

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
}
