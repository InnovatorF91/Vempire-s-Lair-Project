using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    [SerializeField] Text WeaponType;
    [SerializeField] Text Ammo;
    [SerializeField] Text AmmoLabel;
    [SerializeField] Text HealthAmt;
    [SerializeField] Text ScoreAmt;
    [SerializeField] Image BossHealthBar;
    [SerializeField] Text TimeText;

    public static float timer = 0f;
    public static int minutes = 0;
    public static int seconds = 0;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0f;
        minutes = 0;
        seconds = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        minutes = Mathf.FloorToInt(timer / 60f);
        seconds = Mathf.FloorToInt(timer % 60f);
        TimeText.text = minutes.ToString() + " " + ":" + " " + seconds.ToString();


        WeaponType.text = SaveScripts.WeaponName;
        HealthAmt.text = SaveScripts.HealthAmt.ToString();
        ScoreAmt.text = SaveScripts.ScoreAmt.ToString("n0");

        BossHealthBar.fillAmount = SaveScripts.BossHealth;

        if (SaveScripts.WeaponID == 1)
        {
            Ammo.text = "infinity";
            //Ammo.text = SaveScripts.AmmoAmt.ToString();
        }
        if (SaveScripts.WeaponID > 1)
        {
            Ammo.text = SaveScripts.PickupAmmo.ToString();
        }
        if (SaveScripts.WeaponID == 4)
        {
            AmmoLabel.text = "Fuel";
            Ammo.text = (Mathf.Round(SaveScripts.PickupAmmo).ToString());
        }
        else
        {
            AmmoLabel.text = "Ammo";
        }
    }
}
