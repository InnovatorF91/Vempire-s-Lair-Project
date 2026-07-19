using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionSpawn : MonoBehaviour
{
    [SerializeField] GameObject RunningMinion;
    [SerializeField] GameObject CrawlingMinion;
    [SerializeField] GameObject DraggingMinion;
    [SerializeField] Transform SpawnPlace;
    [SerializeField] GameObject SpawnPoint;
    [SerializeField] GameObject PlayerTarget;
    private bool CanSpawn = true;
    private int MinionCount = 3;
    private float DistanceToPlayer;
    // Start is called before the first frame update
    void Start()
    {
        PlayerTarget = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (SpawnPoint.tag=="Point1")
        {
            DistanceToPlayer = Vector3.Distance(PlayerTarget.transform.position, SpawnPlace.transform.position);
            if (SaveScripts.MinionCount <= MinionCount && DistanceToPlayer <= 20f)
			{
				MakingMinion();
			}
		}

        if (SpawnPoint.tag == "Point2")
        {
            DistanceToPlayer = Vector3.Distance(PlayerTarget.transform.position, SpawnPlace.transform.position);
            if (SaveScripts.MinionCount <= MinionCount * 2 && DistanceToPlayer <= 20f)
            {
                MakingMinion();
            }
        }

        if (SpawnPoint.tag == "Point3")
        {
            DistanceToPlayer = Vector3.Distance(PlayerTarget.transform.position, SpawnPlace.transform.position);
            if (SaveScripts.MinionCount <= MinionCount * 3 && DistanceToPlayer<=20f)
            {
                MakingMinion();
            }
        }

        if (SpawnPoint.tag == "Point4")
        {
            DistanceToPlayer = Vector3.Distance(PlayerTarget.transform.position, SpawnPlace.transform.position);
            if (SaveScripts.MinionCount <= MinionCount * 6 && DistanceToPlayer <= 20f)
            {
                MakingMinion();
            }
        }

        if (SpawnPoint.tag == "Point5")
        {
            DistanceToPlayer = Vector3.Distance(PlayerTarget.transform.position, SpawnPlace.transform.position);
            if (SaveScripts.MinionCount <= MinionCount * 5 && DistanceToPlayer <= 20f)
            {
                MakingMinion();
            }
        }

        if (SpawnPoint.tag == "Point6")
        {
            DistanceToPlayer = Vector3.Distance(PlayerTarget.transform.position, SpawnPlace.transform.position);
            if (SaveScripts.MinionCount <= MinionCount * 6 && DistanceToPlayer <= 20f)
            {
                MakingMinion();
            }
        }

        if (SpawnPoint.tag == "Point7")
        {
            if (SaveScripts.MinionCount <= MinionCount * 7)
            {
                MakingMinion();
            }
        }

        if (SpawnPoint.tag == "Point8")
        {
            if (SaveScripts.MinionCount <= MinionCount * 8)
            {
                MakingMinion();
            }
        }
    }

	private void MakingMinion()
	{
		if (CanSpawn == true)
		{
			CanSpawn = false;
			StartCoroutine(Spawning());
		}
	}

	IEnumerator Spawning()
    {
        yield return new WaitForSeconds(0.1f);
        Instantiate(RunningMinion, SpawnPlace.position, SpawnPlace.rotation);
        SaveScripts.MinionCount++;


		yield return new WaitForSeconds(0.5f);
		Instantiate(CrawlingMinion, SpawnPlace.position, SpawnPlace.rotation);
		SaveScripts.MinionCount++;

		yield return new WaitForSeconds(1f);
		Instantiate(DraggingMinion, SpawnPlace.position, SpawnPlace.rotation);
		SaveScripts.MinionCount++;

		CanSpawn = true;
    }
}
