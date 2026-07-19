using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScores : MonoBehaviour
{
    public static int HighScore;
    [SerializeField] GameObject ScoreKeeper;
    private bool SetScore = false;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(ScoreKeeper);
        HighScore = PlayerPrefs.GetInt("NewHighScore");
        //HighScore = 100000;
    }

    // Update is called once per frame
    void Update()
    {
        if (SaveScripts.WinScore == true)
        {
            SetScore = true;
        }

        if (SetScore == true)
        {
            SetScore = false;
            if (SaveScripts.ScoreAmt > HighScore)
            {
                PlayerPrefs.SetInt("NewHighScore", SaveScripts.ScoreAmt);
                PlayerPrefs.Save();
            }
        }
    }
}
