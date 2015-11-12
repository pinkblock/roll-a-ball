using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class player_controler : MonoBehaviour {

	public float speed;
	public Text countText;
	public Text winText;
	public GameObject Lid;
	public GameObject InTheHole;
	public GameObject IntroLightGreen;
	public GameObject ExitLightRed;
	public GameObject ExitLightGreen;

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

		if (other.gameObject.CompareTag("in_the_hole"))
		{
			other.gameObject.SetActive (false);
			winText.text = "You Win!!!";
			PlaySound(1);
			Time.timeScale = 0f;
		}

		if (other.gameObject.CompareTag("background"))
		{
			winText.text = "You Die!!!";
			PlaySound(1);
			Time.timeScale = 0f;
		}
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

	void PlaySound(int clip)
	{
		GetComponent<AudioSource>().clip = audioClip[clip];
		GetComponent<AudioSource>().Play ();
	}
}
