﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class player_controler : MonoBehaviour {

	public float speed;
	public Text countText;
	public Text winText;

	public AudioClip[] audioClip;

	private Rigidbody rb;
	private int count;

	void Start ()
	{
		rb = GetComponent<Rigidbody> ();
		count = 0;
		SetCountText ();
		winText.text = "";
	}

	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movment = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movment * speed);
	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag("pick_up"))
		{
			other.gameObject.SetActive (false);
			count = count + 1;
			SetCountText ();
			PlaySound(0);
		}
	}

	void SetCountText ()
	{
		countText.text = "Count: " + count.ToString ();

		if (count >= 3)
		{
			PlaySound(1);
			winText.text = "You Win!";
			Time.timeScale = 0f;
		}

	}

	void PlaySound(int clip)
	{
		GetComponent<AudioSource>().clip = audioClip[clip];
		GetComponent<AudioSource>().Play ();
	}
}
