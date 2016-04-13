using UnityEngine;
using System.Collections;

public class ReturnMainMenu : MonoBehaviour {
		
	public GameObject loadingImage;

		void Update ()
	{
		if (Input.GetKeyDown ("m")) {
			loadingImage.SetActive (true);
			UnityEngine.SceneManagement.SceneManager.LoadScene ("TitleMenu");
		}
	}
}
