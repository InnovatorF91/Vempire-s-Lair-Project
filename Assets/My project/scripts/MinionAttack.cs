using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionAttack : MonoBehaviour
{
	[SerializeField] float DamageAmt = 1f;
	private AudioSource MinionAudio;
	[Tooltip("1=Running,2=Crawl,3=Drag")]
	[SerializeField] int MinionType = 1;


	private void Start()
	{
		MinionAudio = GetComponentInParent<AudioSource>();
	}

	private void OnTriggerEnter(Collider other)
	{
		if (SaveScripts.PlayerDead == false)
		{
			if (MinionType == 1)
			{
				if (other.gameObject.CompareTag("Player"))
				{
					SaveScripts.HealthAmt -= DamageAmt;
					other.transform.gameObject.SendMessage("GetHit");
					MinionAudio.Play();
				}
			}
			else if (MinionType == 2)
			{
				if (other.gameObject.CompareTag("Player"))
				{
					SaveScripts.HealthAmt -= DamageAmt;
					other.transform.gameObject.SendMessage("GetHit");
					MinionAudio.Play();
				}
			}
			else if (MinionType == 3)
			{
				if (other.gameObject.CompareTag("Player"))
				{
					SaveScripts.HealthAmt -= DamageAmt;
					other.transform.gameObject.SendMessage("GetHit");
					MinionAudio.Play();
				}
			}
		}
	}
}
