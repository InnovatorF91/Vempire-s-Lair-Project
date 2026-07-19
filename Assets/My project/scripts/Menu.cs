using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] Text HighScoreValue;
    [SerializeField] Text ShortestTimeValue;

    [SerializeField] GameObject PlayText;
    [SerializeField] GameObject InfoText;
    [SerializeField] GameObject QuitText;
    [SerializeField] GameObject HighScoreLabel;
    [SerializeField] GameObject ShortTimeLabel;

    [SerializeField] GameObject Play_Japanese;
    [SerializeField] GameObject Info_Japanese;
    [SerializeField] GameObject Quit_Japanese;
    [SerializeField] GameObject HS_Japanese;
    [SerializeField] GameObject ST_Japanese;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HighScoreValue.text = HighScores.HighScore.ToString();
        ShortestTimeValue.text = ShortestTime.SMinutes.ToString() + " " + ":" + " " + ShortestTime.Sseconds.ToString();
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void Info()
    {
        SceneManager.LoadScene(2);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void DeleteAllRecords()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
    }

    public void ToBeJapanese()
    {
        PlayText.SetActive(false);
        InfoText.SetActive(false);
        QuitText.SetActive(false);
        HighScoreLabel.SetActive(false);
        ShortTimeLabel.SetActive(false);

        Play_Japanese.SetActive(true);
        Info_Japanese.SetActive(true);
        Quit_Japanese.SetActive(true);
        HS_Japanese.SetActive(true);
        ST_Japanese.SetActive(true);
    }

    public void ToBeEnglish()
    {
        PlayText.SetActive(true);
        InfoText.SetActive(true);
        QuitText.SetActive(true);
        HighScoreLabel.SetActive(true);
        ShortTimeLabel.SetActive(true);

        Play_Japanese.SetActive(false);
        Info_Japanese.SetActive(false);
        Quit_Japanese.SetActive(false);
        HS_Japanese.SetActive(false);
        ST_Japanese.SetActive(false);
    }
}
