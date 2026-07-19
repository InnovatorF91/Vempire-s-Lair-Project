using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    [SerializeField] Text ScoreText;
    // Start is called before the first frame update
    void Start()
    {
        ScoreText.text = SaveScripts.ScoreAmt.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
