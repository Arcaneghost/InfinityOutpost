using UnityEngine;
using System.Collections;

public class LoadOnClick : MonoBehaviour {

	public GameObject loadingImage;

	public void LoadScene(int level)
	{
		//This loads the scene
		loadingImage.SetActive (true);
		Application.LoadLevel(level);

	}
}
