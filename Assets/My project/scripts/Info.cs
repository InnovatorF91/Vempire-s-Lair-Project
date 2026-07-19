using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Info : MonoBehaviour
{
	[SerializeField] GameObject TitleText;
	[SerializeField] GameObject ControlsTitle;
	[SerializeField] GameObject StoryTitle;
	[SerializeField] GameObject PickUpTitle;
	[SerializeField] GameObject ControlsText;
	[SerializeField] GameObject StoryText;
	[SerializeField] GameObject PickUpText;

	[SerializeField] GameObject TitleText_Japanese;
	[SerializeField] GameObject ControlsTitle_Japanese;
	[SerializeField] GameObject StoryTitle_Japanese;
	[SerializeField] GameObject PickUpTitle_Japanese;
	[SerializeField] GameObject ControlsText_Japanese;
	[SerializeField] GameObject StoryText_Japanese;
	[SerializeField] GameObject PickUpText_Japanese;
	public void BackToMenu()
	{
		SceneManager.LoadScene(0);
	}

	public void JapaneseText()
	{
		TitleText.SetActive(false);
		ControlsTitle.SetActive(false);
		StoryTitle.SetActive(false);
		PickUpTitle.SetActive(false);
		ControlsText.SetActive(false);
		StoryText.SetActive(false);
		PickUpText.SetActive(false);

		TitleText_Japanese.SetActive(true);
		ControlsTitle_Japanese.SetActive(true);
		StoryTitle_Japanese.SetActive(true);
		PickUpTitle_Japanese.SetActive(true);
		ControlsText_Japanese.SetActive(true);
		StoryText_Japanese.SetActive(true);
		PickUpText_Japanese.SetActive(true);
	}

	public void EnglishText()
	{
		TitleText.SetActive(true);
		ControlsTitle.SetActive(true);
		StoryTitle.SetActive(true);
		PickUpTitle.SetActive(true);
		ControlsText.SetActive(true);
		StoryText.SetActive(true);
		PickUpText.SetActive(true);

		TitleText_Japanese.SetActive(false);
		ControlsTitle_Japanese.SetActive(false);
		StoryTitle_Japanese.SetActive(false);
		PickUpTitle_Japanese.SetActive(false);
		ControlsText_Japanese.SetActive(false);
		StoryText_Japanese.SetActive(false);
		PickUpText_Japanese.SetActive(false);
	}
}
