using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFlameHit : MonoBehaviour
{
	private void OnParticleCollision(GameObject other)
	{
		gameObject.SendMessageUpwards("Hit");
	}
}
