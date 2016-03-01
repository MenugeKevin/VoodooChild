using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	private static int nbButton;
	
	void Update()
	{
	if (Input.GetKeyDown(KeyCode.Escape))
		Application.Quit();
	if (Input.GetKeyDown(KeyCode.Return))
		Application.LoadLevel(0);
	}
	
	public static void setNb(int nb)
	{
		nbButton = nb;
	}
	
	public static int getNb()
	{
		return nbButton;
	}
}
