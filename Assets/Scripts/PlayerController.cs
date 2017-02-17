﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour{
    public Animator Anime;
    public Rigidbody2D PlayerRigidbody2D;
    public int ForceJump;

    public bool Slide;

    //Verifica se está tocando no ground
	private bool isGrounded;

    public Transform GroundCheck;
    public LayerMask WhatIsGround;

    //Slide
    public float SlideTemp;
	private float timetemp;

	//Colisor
	public Transform colisor;

    // Use this for initialization
    private void Start(){
		
    }

    // Update is called once per frame
    private void Update(){
        if (Input.GetButtonDown("Jump") && isGrounded){
            PlayerRigidbody2D.AddForce(new Vector2(0, ForceJump));

			if (Slide) {
				colisor.position = new Vector3 (colisor.position.x, colisor.position.y + 0.3f, colisor.position.z);
				Slide = false;
			}
        }

		if (Input.GetButtonDown("Slide") && isGrounded && !Slide){
			colisor.position = new Vector3 (colisor.position.x, colisor.position.y - 0.3f, colisor.position.z);
            Slide = true;
            timetemp = 0;
        }

        isGrounded = Physics2D.OverlapCircle(GroundCheck.position, 0.2f, WhatIsGround);
		//Debug.Log("chao: " + isGrounded);

        if (Slide){
            timetemp += Time.deltaTime;

            if (timetemp >= SlideTemp){
				colisor.position = new Vector3 (colisor.position.x, colisor.position.y + 0.3f, colisor.position.z);
                Slide = false;
            }
        }

        Anime.SetBool("Jump", !isGrounded);
        Anime.SetBool("Slide", Slide);
    }

	void OnTriggerEnter2D(){
		Debug.Log ("Bateu!");
	}
		
}
                 