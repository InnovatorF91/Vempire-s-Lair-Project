using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTriggerScript : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			SaveScripts.HealthAmt = 0;
		}
	}
}
