using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameExplode : MonoBehaviour
{
	private void OnParticleCollision(GameObject other)
	{
		gameObject.SendMessageUpwards("FlameExplode");
		//gameObject.SendMessage("Explode");
	}


}
