using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpendedTimeScript : MonoBehaviour
{
    [SerializeField] Text SpendedTime;
    // Start is called before the first frame update
    void Start()
    {
        SpendedTime.text = UIScript.minutes.ToString() + " " + ":" + " " + UIScript.seconds.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
