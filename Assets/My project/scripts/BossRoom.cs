using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRoom : MonoBehaviour
{
    [SerializeField] GameObject Boss;
    [SerializeField] GameObject BossHB;
    [SerializeField] GameObject FinalMinion1;
    [SerializeField] GameObject FinalMinion2;

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			Boss.gameObject.SetActive(true);
			BossHB.gameObject.SetActive(true);
			FinalMinion1.gameObject.SetActive(true);
			FinalMinion2.gameObject.SetActive(true);
		}
	}

	private void Update()
	{
		if (SaveScripts.PlayerDead == true)
		{
			BossHB.gameObject.SetActive(false);
		}
	}
}
