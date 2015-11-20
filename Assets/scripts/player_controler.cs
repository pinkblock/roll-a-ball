using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class player_controler : MonoBehaviour {

	public float speed;
	public Text countText;
	public Text curentLevleText;
	public Text winText;
	public Text timeText;
	public GameObject Lid;
	public GameObject InTheHole;
	public GameObject IntroLightGreen;
	public GameObject ExitLightRed;
	public GameObject ExitLightGreen;

	public AudioClip[] audioClip;

	private Rigidbody rb;
	private int count;
	private int curentLevle;

	private float gameStartTime;
	private float gameTime;

	void Start ()
	{
		rb = GetComponent<Rigidbody> ();
		count = 0;
		curentLevle = 1;
		SetCountText ();
		winText.text = "";
		gameStartTime = Time.time;
		gameTime = 0;

	}

	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movment = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movment * speed);
	}

	void Update ()
	{
		SetGameTime ();
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

		if (other.gameObject.CompareTag("in_the_hole"))
		{
			other.gameObject.SetActive (false);
			PlaySound(1);


			Application.LoadLevel (Application.loadedLevel + 1);
		}

		if (other.gameObject.CompareTag("background"))
		{
			winText.text = "You Die!!!";
			PlaySound(1);
			Time.timeScale = 0f;
		}
	}

	void SetCurentLevleText ()
	{
		curentLevleText.text = "Levle: " + curentLevle.ToString ();
	}

	void SetCountText ()
	{
		countText.text = "Count: " + count.ToString ();

		if (count >= 3)
		{
			IntroLightGreen.SetActive (false);
			Lid.SetActive (false);
			ExitLightRed.SetActive (false);
			InTheHole.SetActive (true);
			ExitLightGreen.SetActive (true);
		}

	}

	void SetGameTime ()
	{
		gameTime = Time.time - gameStartTime;
		timeText.text = gameTime.ToString ();
	}

	void PlaySound(int clip)
	{
		GetComponent<AudioSource>().clip = audioClip[clip];
		GetComponent<AudioSource>().Play ();
	}
}
