﻿using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class NPCWalk : MonoBehaviour {

	Rigidbody2D rigidBody;
	Animator anim;
	public float speed = 2.0f;
	int direction = 0;
	bool isInteracting = false;

	// counter to make walk() occur every certain number of frames
	private int frames = 0;

	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void FixedUpdate () {
		if (!isInteracting) {
			frames++;
			Walk (direction);

			if (frames % 20 == 0) {
				System.Random rnd = new System.Random ();
				direction = rnd.Next (10);
				frames = 0;
			}
		}
	}

	void Walk (int direction) {
		Vector2 movement_vector = new Vector2 (0, 0);

		switch (direction) {
		case 0:
			Debug.Log ("NPC is walking up.");
			movement_vector = new Vector2 (0, 1);
			break;

		case 1:
			Debug.Log ("NPC is walking down.");
			movement_vector = new Vector2 (0, -1);
			break;

		case 2:
			Debug.Log ("NPC is walking left.");
			movement_vector = new Vector2 (-1, 0);
			break;

		case 3:
			Debug.Log ("NPC is walking right.");
			movement_vector = new Vector2 (1, 0);
			break;
		default:
			Debug.Log("NPC is staying still.");
			movement_vector = new Vector2 (0 , 0);
			break;
		}

		movement_vector *= speed;

		if (movement_vector != Vector2.zero) {
			anim.SetBool ("isWalking", true);
			anim.SetFloat ("input_x", movement_vector.x);
			anim.SetFloat ("input_y", movement_vector.y);
		} else {
			anim.SetBool ("isWalking", false);
		}

		rigidBody.MovePosition (rigidBody.position + movement_vector * Time.deltaTime);
	}
}