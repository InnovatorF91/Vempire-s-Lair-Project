using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Animator CamAnim;
    // Start is called before the first frame update
    void Start()
    {
        CamAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (SaveScripts.PlayerDead == false)
        {
            if (Input.GetMouseButtonDown(1))
            {
                CamAnim.SetBool("aimCam", true);
            }
            if (Input.GetMouseButtonUp(1))
            {
                CamAnim.SetBool("aimCam", false);
            }
        }
    }
}
