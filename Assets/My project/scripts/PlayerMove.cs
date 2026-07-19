using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Animator Anim;
    [SerializeField] float StillRotateSpeed = 12f;
    [SerializeField] float WalkRotateSpeed = 12f;
    [SerializeField] float RunRotateSpeed = 12f;
    [SerializeField] float AimRotateSpeed = 12f;
    [SerializeField] GameObject Crosshair;
    [SerializeField] GameObject BloodFX;

    private float RotateSpeed;
    private AnimatorStateInfo PlayerInfo;
    private AnimatorStateInfo PlayerInfoL2;

    public bool ClimbingLadder = false;
    private bool IsClimbing = false;
    [SerializeField] Rigidbody RB;
    public float ForceSpeed = 600f;
    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();
        Crosshair.gameObject.SetActive(false);
        BloodFX.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (IsClimbing == false)
        {
            if (SaveScripts.PlayerDead == false)
            {
                PlayerInfo = Anim.GetCurrentAnimatorStateInfo(0);
                PlayerInfoL2 = Anim.GetCurrentAnimatorStateInfo(1);

                float MoveDirection = Input.GetAxis("Vertical");
                float RotateDirection = Input.GetAxis("Mouse X");

                if (PlayerInfo.IsTag("Still"))
                {
                    RotateSpeed = StillRotateSpeed;
                    Crosshair.gameObject.SetActive(false);
                }
                if (PlayerInfo.IsTag("Walk"))
                {
                    RotateSpeed = WalkRotateSpeed;
                }
                if (PlayerInfo.IsTag("Run"))
                {
                    RotateSpeed = RunRotateSpeed;
                }
                if (PlayerInfo.IsTag("Aiming"))
                {
                    RotateSpeed = AimRotateSpeed;
                    Crosshair.gameObject.SetActive(true);
                }

                if (PlayerInfoL2.IsTag("Hit"))
                {
                    Anim.SetLayerWeight(1, 1);
                    BloodFX.gameObject.SetActive(true);
                }
                else if (PlayerInfoL2.IsTag("Idle"))
                {
                    Anim.SetLayerWeight(1, 0);
                    BloodFX.gameObject.SetActive(false);
                }

                if (MoveDirection > 0)
                {
                    if (Input.GetKeyDown(KeyCode.LeftShift))
                    {
                        Anim.SetBool("running", true);
                    }
                    else if (Input.GetKeyUp(KeyCode.LeftShift))
                    {
                        Anim.SetBool("running", false);
                    }
                    else
                    {
                        Anim.SetBool("walk", true);
                    }
                    Anim.SetBool("walk", true);
                    Anim.SetBool("walkback", false);
                }
                if (MoveDirection == 0)
                {
                    Anim.SetBool("walk", false);
                    Anim.SetBool("walkback", false);
                    Anim.SetBool("running", false);
                }
                if (MoveDirection < 0)
                {
                    Anim.SetBool("walk", false);
                    Anim.SetBool("walkback", true);
                }

                if (RotateDirection > 0)
                {
                    this.transform.Rotate(Vector3.up * RotateSpeed);
                }
                if (RotateDirection < 0)
                {
                    this.transform.Rotate(Vector3.up * -RotateSpeed);
                }


                if (Input.GetMouseButtonDown(1))
                {
                    Anim.SetBool("aim", true);
                }
                if (Input.GetMouseButtonUp(1))
                {
                    Anim.SetBool("aim", false);
                }
                if (Input.GetKeyDown(KeyCode.J))
                {
                    RB.AddForce(Vector3.up * ForceSpeed, ForceMode.Impulse);
                }
            }
        }

        if (IsClimbing == true)
        {
            if (Input.GetAxis("Vertical") > 0)
            {
                Anim.SetBool("Climb", true);
                Anim.SetBool("StopClimbing", false);
                Anim.SetBool("Down", false);
                Anim.SetTrigger("ClimbUp");
            }
            else if (Input.GetAxis("Vertical") < 0)
            {
                Anim.SetBool("StopClimbing", false);
                Anim.SetBool("Down", true);
                Anim.SetTrigger("ClimbDown");
            }
            if (Input.GetAxis("Vertical") == 0)
            {
                Anim.SetBool("StopClimbing", true);
                RB.isKinematic = true;
            }
        }
    }

    public void StartClimbing()
    {
        IsClimbing = true;
        Anim.SetBool("Climb", true);
        Anim.SetBool("walk", false);
    }

    public void StopClimbing()
    {
        IsClimbing = false;
        RB.isKinematic = false;
        Anim.SetBool("Climb", false);
    }

    public void ReachedTheTop()
    {
        IsClimbing = false;
        Anim.SetBool("Climb", false);
        StartCoroutine(GravityOn());
    }

    public void GetHit()
    {
        //Anim.SetLayerWeight(1,1);
        Anim.SetTrigger("React");
    }

    IEnumerator GravityOn()
    {
        yield return new WaitForSeconds(1.3f);
        RB.isKinematic = false;
    }
}


//TODO:Left and Right Movement