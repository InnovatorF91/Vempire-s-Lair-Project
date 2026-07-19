using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShortestTime : MonoBehaviour
{
    [SerializeField] GameObject TimeKeeper;
    public static float STime=10000.0f;
    public static int SMinutes=99;
    public static int Sseconds=59;
    private bool SetTime = false;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(TimeKeeper);
		STime = PlayerPrefs.GetFloat("NewShortTime");
		SMinutes = PlayerPrefs.GetInt("NewShortMinutes");
		Sseconds = PlayerPrefs.GetInt("NewShortSeconds");
    }

    // Update is called once per frame
    void Update()
    {
        if (SaveScripts.WinScore == true)
        {
            SetTime = true;
        }

        if (SetTime == true)
        {
            SetTime = false;
            if (STime != 0f)
            {
                if (UIScript.timer < STime)
                {
                    PlayerPrefs.SetFloat("NewShortTime", UIScript.timer);
                    PlayerPrefs.SetInt("NewShortMinutes", UIScript.minutes);
                    PlayerPrefs.SetInt("NewShortSeconds", UIScript.seconds);
                    PlayerPrefs.Save();
                }
            }
            else
            {
                PlayerPrefs.SetFloat("NewShortTime", UIScript.timer);
                PlayerPrefs.SetInt("NewShortMinutes", UIScript.minutes);
                PlayerPrefs.SetInt("NewShortSeconds", UIScript.seconds);
                PlayerPrefs.Save();
            }
        }
    }
}
