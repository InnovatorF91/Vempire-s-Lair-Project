using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] Transform MuzzleSpawn;
    [SerializeField] GameObject MuzzleFlash;
    [SerializeField] GameObject ImpactStone;
    [SerializeField] GameObject ImpactMetal;
    [SerializeField] GameObject GrenadeSmoke;
    [SerializeField] GameObject GrenadeExplosion;
    [SerializeField] GameObject Flames;
    [SerializeField] GameObject BloodImpact;
    [SerializeField] AudioClip SingleShotSound;
    [SerializeField] AudioClip RapidShotSound;
    [SerializeField] AudioClip GrenadeSound;
    [SerializeField] AudioClip FlamesSound;
    [SerializeField] AudioClip PickupFX;
    [SerializeField] float RapidDelay = 0.1f;
    [SerializeField] float ImpactDistance = 0.001f;
    [SerializeField] LayerMask PlayerLayer;
    [SerializeField] LayerMask BarrelLayer;

    private bool RapidPlay = true;
    private bool RapidShooting = true;
    private bool FireFuel = false;

    private AudioSource PlayerAudio;

    RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        PlayerAudio = GetComponent<AudioSource>();
        Flames.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (SaveScripts.PlayerDead == false)
        {
            if (SaveScripts.WeaponID == 1)
            {
                if (Input.GetMouseButton(1) && Input.GetMouseButtonDown(0))
                {
                    Instantiate(MuzzleFlash, MuzzleSpawn.position, MuzzleSpawn.rotation);

                    SaveScripts.AmmoAmt--;

                    PlayerAudio.clip = SingleShotSound;
                    PlayerAudio.loop = false;
                    PlayerAudio.pitch = 1;
                    PlayerAudio.Play();

                    Hits();
                }
            }

            if (SaveScripts.WeaponID == 2)
            {
                if (Input.GetMouseButton(1) && Input.GetMouseButton(0))
                {
                    Instantiate(MuzzleFlash, MuzzleSpawn.position, MuzzleSpawn.rotation);

                    if (RapidPlay == true)
                    {
                        RapidPlay = false;
                        PlayerAudio.clip = RapidShotSound;
                        PlayerAudio.loop = true;
                        PlayerAudio.pitch = 3;
                        PlayerAudio.Play();
                    }

                    if (RapidShooting == true)
                    {
                        RapidShooting = false;
                        StartCoroutine(RapidFire());
                    }
                }

                if (Input.GetMouseButtonUp(0))
                {
                    PlayerAudio.Stop();
                    RapidPlay = true;
                }
            }

            if (SaveScripts.WeaponID == 3)
            {
                if (Input.GetMouseButton(1) && Input.GetMouseButtonDown(0))
                {
                    Instantiate(GrenadeSmoke, MuzzleSpawn.position, MuzzleSpawn.rotation);

                    SaveScripts.PickupAmmo--;

                    PlayerAudio.clip = GrenadeSound;
                    PlayerAudio.loop = false;
                    PlayerAudio.pitch = 1;
                    PlayerAudio.PlayDelayed(0.3f);

                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    if (Physics.Raycast(ray, out hit, 1000))
                    {
                        StartCoroutine(Grenade());
                    }


                }
            }

            if (SaveScripts.WeaponID == 4)
            {
                if (Input.GetMouseButton(1) && Input.GetMouseButtonDown(0))
                {
                    Flames.gameObject.SetActive(true);

                    if (RapidPlay == true)
                    {
                        RapidPlay = false;
                        FireFuel = true;
                        PlayerAudio.clip = FlamesSound;
                        PlayerAudio.loop = true;
                        PlayerAudio.pitch = 0.1f;
                        PlayerAudio.Play();
                    }

                }

                if (Input.GetMouseButtonUp(1) || Input.GetMouseButtonUp(0))
                {
                    Flames.gameObject.SetActive(false);
                    if (RapidPlay == false)
                    {
                        PlayerAudio.Stop();
                        FireFuel = false;
                        RapidPlay = true;
                    }
                }
            }
            if (FireFuel == true)
            {
                SaveScripts.PickupAmmo -= 3 * Time.deltaTime;
                if (SaveScripts.PickupAmmo <= 0)
                {
                    Flames.gameObject.SetActive(false);
                    if (RapidPlay == false)
                    {
                        PlayerAudio.Stop();
                        FireFuel = false;
                        RapidPlay = true;
                    }
                }
            }
        }
    }

    void Hits()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 1000, ~PlayerLayer))
        {
            if (hit.transform.tag == "Stone")
            {
                Instantiate(ImpactStone, hit.point, Quaternion.LookRotation(hit.normal));
            }
            if (hit.transform.tag == "Metal")
            {
                Instantiate(ImpactMetal, hit.point, Quaternion.LookRotation(hit.normal));
            }
            if (hit.transform.tag == "Minion")
            {
                Instantiate(BloodImpact, hit.point + hit.normal * ImpactDistance, Quaternion.LookRotation(hit.normal));
                hit.transform.gameObject.SendMessageUpwards("MinionDeath");
            }
            if (hit.transform.tag == "Switchboard")
            {
                Instantiate(ImpactMetal, hit.point, Quaternion.LookRotation(hit.normal));
                hit.transform.gameObject.SendMessage("Sparks");
            }
            if (hit.transform.tag == "Boss")
            {
                Instantiate(BloodImpact, hit.point + hit.normal * ImpactDistance, Quaternion.LookRotation(hit.normal));
                hit.transform.gameObject.SendMessage("Hit");
            }
        }
        if (Physics.Raycast(ray, out hit, 1000, BarrelLayer))
        {
            if (hit.transform.tag == "ExplodingBarrel")
            {
                hit.transform.gameObject.SendMessage("Explode");
            }
        }
    }

	private void OnTriggerEnter(Collider other)
	{
        if (other.gameObject.CompareTag("RapidFire"))
        {
            SaveScripts.WeaponID = 2;
            SaveScripts.WeaponName = "Rapid Fire";
            SaveScripts.PickupAmmo = 100f;
            PickupSound();
            Destroy(other.gameObject, 0.2f);
        }
        if (other.gameObject.CompareTag("GrenadeAmmo"))
        {
            SaveScripts.WeaponID = 3;
            SaveScripts.WeaponName = "Granade Launcher";
            SaveScripts.PickupAmmo = 10f;
            PickupSound();
            Destroy(other.gameObject, 0.2f);
        }
        if (other.gameObject.CompareTag("Flamethrower"))
        {
            SaveScripts.WeaponID = 4;
            SaveScripts.WeaponName = "Flame Thrower";
            SaveScripts.PickupAmmo = 50f;
            PickupSound();
            Destroy(other.gameObject, 0.2f);
        }
        if (other.gameObject.CompareTag("HealthPickup"))
        {
            SaveScripts.HealthAmt += 40;
            if (SaveScripts.HealthAmt >= 100)
            {
                SaveScripts.HealthAmt = 100;
            }
            PickupSound();
            Destroy(other.gameObject, 0.2f);
        }
    }

    void PickupSound()
    {
        PlayerAudio.clip = PickupFX;
        PlayerAudio.loop = false;
        PlayerAudio.pitch = 1;
        PlayerAudio.Play();
    }

	IEnumerator RapidFire()
    {
        yield return new WaitForSeconds(RapidDelay);

        SaveScripts.PickupAmmo--;

        Hits();
        RapidShooting = true;
    }

    IEnumerator Grenade()
    {
        yield return new WaitForSeconds(0.3f);

        Instantiate(GrenadeExplosion, hit.point, Quaternion.LookRotation(hit.normal));

        if (hit.transform.tag == "ExplodingBarrel")
        {
            hit.transform.gameObject.SendMessage("Explode");
        }
    }
}
