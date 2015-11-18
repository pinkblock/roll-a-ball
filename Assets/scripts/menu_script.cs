using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {

	public Canvas quiteMenu;
	public Button startText;
	public Button exitText;


	// Use this for initialization
	void Start () {
		quiteMenu = quiteMenu.GetComponent<Canvas> ();
		startText = startText.GetComponent<Button> ();
		exitText = exitText.GetComponent<Button> ();

		quiteMenu.enabled = false;

	}

	public void ExitPress()
	{
		quiteMenu.enabled = true;
		startText.enabled = false;
		exitText.enabled = false;
	}

	public void noIsPressed()
	{
		quiteMenu.enabled = false;
		startText.enabled = true;
		exitText.enabled = true;
	}

	public void StarLevel()
	{
		Application.LoadLevel (1);
	}

	public void ExitGame()
	{
		Application.Quit ();
	}

	// Update is called once per frame
	void Update () {
	
	}
}
