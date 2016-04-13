using UnityEngine;
using System.Collections;

public class ReturnMainMenu : MonoBehaviour {
		

		void Update ()
	{
		if (Input.GetKeyDown ("m")) {
			//loadingImage.SetActive (true);
			UnityEngine.SceneManagement.SceneManager.LoadScene ("TitleMenu");
		}
	}
}
