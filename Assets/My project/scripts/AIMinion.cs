using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIMinion : MonoBehaviour
{
    [SerializeField] GameObject PlayerTarget;
    [SerializeField] float CrawlSpeed = 1.1f;
    [SerializeField] float DragSpeed = 0.6f;
    [SerializeField] float RunSpeed = 2.3f;
    [SerializeField] float AttackDistance = 5.3f;
    [SerializeField] Collider MinionCol;
    [Tooltip("1=Running,2=Crawl,3=Drag")]
    [SerializeField] int MinionType = 1;
    [SerializeField] float RotationSpeed = 2.0f;
    private NavMeshAgent Nav;
    private Animator Anim;
    private float DistanceToPlayer;
    private bool CanMove = true;
    private NavMeshObstacle NavObstacle;
    private float NavMinionSpeed;
    private AnimatorStateInfo MinionInfo;
    private AnimatorStateInfo MinionInfo2;
    private AnimatorStateInfo MinionInfo3;
    private bool Moving = true;
    private bool AlreadyDead = false;

    // Start is called before the first frame update
    void Start()
    {
        Nav = GetComponent<NavMeshAgent>();
        PlayerTarget = GameObject.FindGameObjectWithTag("Player");
        Anim = GetComponent<Animator>();
        NavObstacle = GetComponent<NavMeshObstacle>();
        NavObstacle.enabled = false;
        if (MinionType == 1)
        {
            NavMinionSpeed = RunSpeed;
        }
        if (MinionType == 2)
        {
            NavMinionSpeed = CrawlSpeed;
            Anim.SetLayerWeight(1, 1);
        }
        if (MinionType == 3)
        {
            NavMinionSpeed = DragSpeed;
            Anim.SetLayerWeight(2, 1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (SaveScripts.PlayerDead == false)
        {
            if (MinionType == 1)
            {
                MinionInfo = Anim.GetCurrentAnimatorStateInfo(0);
            }
            else if (MinionType == 2)
            {
                MinionInfo2 = Anim.GetCurrentAnimatorStateInfo(0);
            }
            else if (MinionType == 3)
            {
                MinionInfo3 = Anim.GetCurrentAnimatorStateInfo(0);
            }

            if (MinionInfo.IsTag("Death") || MinionInfo2.IsTag("Death") || MinionInfo3.IsTag("Death") || MinionInfo.IsTag("Dead"))
            {
                Moving = false;
                Nav.enabled = false;
                Anim.SetBool("Attack", false);
                //Debug.Log(SaveScripts.MinionCount);
            }
            else
            {
                Moving = true;
            }
            if (Moving == true)
            {
                DistanceToPlayer = Vector3.Distance(PlayerTarget.transform.position, transform.position);

                if (DistanceToPlayer < AttackDistance)
                {
                    Anim.SetBool("Attack", true);
                    //MinionCol.enabled = true;
                    //Nav.enabled = false;
                    CanMove = false;
                    //NavObstacle.enabled = true;
                    Vector3 Pos = (PlayerTarget.transform.position - transform.position).normalized;
                    Quaternion PosRotation = Quaternion.LookRotation(new Vector3(Pos.x, 0, Pos.z));
                    transform.rotation = Quaternion.Slerp(transform.rotation, PosRotation, Time.deltaTime * RotationSpeed);
                }
                else if (DistanceToPlayer > AttackDistance + 1)
                {
                    Anim.SetBool("Attack", false);
                    //MinionCol.enabled = false;
                    //Nav.enabled = true;
                    CanMove = true;
                    //NavObstacle.enabled = false;
                }

                if (CanMove == true)
                {
                    Nav.speed = NavMinionSpeed;
                    Nav.SetDestination(PlayerTarget.transform.position);
                }
            }
        }
    }

    public void MinionDeath()
    {
        if (AlreadyDead == false)
        {
            Anim.SetTrigger("Dying");
            Nav.enabled = false;
            AlreadyDead = true;
            SaveScripts.ScoreAmt += 1000;
        }
    }

    public void MinionBurned()
    {
        if (AlreadyDead == false)
        {
            if (MinionType==1)
            {
                Anim.SetTrigger("Burned");
                Nav.enabled = false;
                AlreadyDead = true;
                SaveScripts.ScoreAmt += 1000;
            }
            else
            {
                Anim.SetTrigger("Dying");
                Nav.enabled = false;
                AlreadyDead = true;
                SaveScripts.ScoreAmt += 1000;
            }
        }
    }

    public void DestroyOnDeath()
    {
        StartCoroutine(WaitForDestroy());
    }

    IEnumerator WaitForDestroy()
    {
        yield return new WaitForSeconds(1.5f);
        SaveScripts.MinionCount--;
        Destroy(gameObject);
    }
}
