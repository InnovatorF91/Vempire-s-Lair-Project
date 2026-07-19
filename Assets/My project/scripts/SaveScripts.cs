using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveScripts : MonoBehaviour
{
    public static int WeaponID = 1;
    public static string WeaponName;
    public static float PickupAmmo;
    public static float AmmoAmt;
    public static float HealthAmt = 100f;
    public static int ScoreAmt = 0;
    public static int MinionCount = 0;
    public static bool PlayerDead = false;
    public static float BossHealth = 1.0f;
    public static bool WinScore = false;

    [SerializeField] GameObject DeathPanel;
    [SerializeField] GameObject WinPanel;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        AmmoAmt = 1000f;
        WeaponName = "SingleShot";
        PlayerDead = false;
        HealthAmt = 100f;
        ScoreAmt = 0;
        WeaponID = 1;
        MinionCount = 0;
        BossHealth = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (PickupAmmo <= 0)
        {
            WeaponID = 1;
            WeaponName = "SingleShot";
        }

        if (HealthAmt <= 0)
        {
            DeathPanel.gameObject.SetActive(true);
            PlayerDead = true;
            //WinScore = true;
            Cursor.visible = true;
        }

        if (BossHealth <= 0.0f)
        {
            WinPanel.gameObject.SetActive(true);
            PlayerDead = true;
            WinScore = true;
            Cursor.visible = true;
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            Cursor.visible = false;
            AmmoAmt = 1000f;
            WeaponName = "SingleShot";
            PlayerDead = false;
            HealthAmt = 100f;
            ScoreAmt = 0;
            WeaponID = 1;
            MinionCount = 0;
            BossHealth = 1.0f;
            BackToMenu();
        }
    }

    public void Replay()
    {
        SceneManager.LoadScene(1);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
