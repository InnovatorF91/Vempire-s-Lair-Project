using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlobMove : MonoBehaviour
{
    [SerializeField] float MoveSpeed = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * MoveSpeed;
    }

	private void OnTriggerEnter(Collider other)
	{
        if (other.gameObject.CompareTag("Stone"))
        {
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("Switchboard"))
        {
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("ExplodingBarrel"))
        {
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("Player"))
        {
            SaveScripts.HealthAmt -= 10.0f;
            other.transform.gameObject.SendMessage("GetHit");
            Destroy(gameObject);
        }
    }
}
