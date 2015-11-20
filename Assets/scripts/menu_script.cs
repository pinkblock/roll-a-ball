using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class menu_script : MonoBehaviour {

	public Canvas quiteMenu;
	public Button startButton;
	public Button exitButton;

	// Use this for initialization
	void Start () {
		quiteMenu = quiteMenu.GetComponent<Canvas> ();
		startButton = startButton.GetComponent<Button> ();
		exitButton = exitButton.GetComponent<Button> ();

		quiteMenu.enabled = false;

	}

	public void ExitPress()
	{
		quiteMenu.enabled = true;
		startButton.enabled = false;
		exitButton.enabled = false;
	}

	public void noIsPressed()
	{
		quiteMenu.enabled = false;
		startButton.enabled = true;
		exitButton.enabled = true;
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
