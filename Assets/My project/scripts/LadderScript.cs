using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderScript : MonoBehaviour
{
    public Collider LadderCollider;
    public Collider Top;
    public Collider Bottom;
    private bool MoveCheck = false;

	private void OnTriggerEnter(Collider other)
	{
		if (MoveCheck == false)
		{
			if (other.gameObject.CompareTag("Player"))
			{
				other.gameObject.GetComponentInParent<PlayerMove>().StartClimbing();
				LadderCollider.enabled = false;
				MoveCheck = true;
				StartCoroutine(CheckForTop());
				StartChecking();
			}
		}
		if (Input.GetAxis("Vertical") < 0)
		{
			if (other.CompareTag("Player"))
			{
				other.gameObject.GetComponent<PlayerMove>().StopClimbing();
				LadderCollider.enabled = false;
				Bottom.enabled = false;
				Top.enabled = false;
				StartCoroutine(Rebuild());
				CancelInvoke();
			}
		}
		if (Input.GetAxis("Vertical") > 0)
		{
			if (other.CompareTag("Player"))
			{
				other.gameObject.GetComponent<PlayerMove>().ReachedTheTop();
				LadderCollider.enabled = false;
				Bottom.enabled = false;
				Top.enabled = false;
				StartCoroutine(Rebuild());
				CancelInvoke();
			}
		}
	}

	void StartChecking()
	{
		InvokeRepeating("CheckDirection", 1, 1);
	}

	void CheckDirection()
	{
		if (MoveCheck == true)
		{
			if (Input.GetAxis("Vertical") < 0)
			{
				Bottom.enabled = true;
			}
		}
	}

	IEnumerator CheckForTop()
	{
		yield return new WaitForSeconds(1);
		Top.enabled = true;
	}

	IEnumerator Rebuild()
	{
		yield return new WaitForSeconds(1f);
		LadderCollider.enabled = true;
		MoveCheck = false;
	}
}
