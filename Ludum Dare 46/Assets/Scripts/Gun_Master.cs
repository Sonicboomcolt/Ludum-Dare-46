using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//Made by AspectDevelops
public enum FireType
{
	SINGLE,
	AUTO,
	BURST,
	CHARGE,
	SHOTGUN
}
public class Gun_Master : MonoBehaviour
{
	//public struct userAttributes {}
	//public struct appAttributes {}
	
	[Header("FireType")]
	[Tooltip("Changes the fire mode of your gun.")]
	public FireType fireType = FireType.SINGLE;
	
	[Header("Essentials")]
	[Tooltip("Changes the shooting speed of the bullet.")]
	public float attackSpeed = 0.1f;
	[Tooltip("Changes the cooldown between shots of the gun.")]
	public float cooldown;
	//[Tooltip("If Shotgun firetype selected ")]
	//public bool spread;
	[Tooltip("Changes the spread of the shotguns.")]
	public float spreadammount;
	[Tooltip("Changes the speed of the bullet.")]
	public float ShootSpeed;
	[Tooltip("Changes the speed of the ejected shells.")]
	public float ejectspeed = 4f;
	[Header("WeaponTypes")]
	public bool isPistol;
	public bool isMinigun;
	public bool isShotGun;
	public bool isAssultRifle;
	public bool isGravityGun = false;
	public bool isRPG;
	public bool isBurstRifle;
	
	[Header("Ammo")]
	[Tooltip("Bullets in a magazine.")]
	public int magazineSize = 10;
	[Tooltip("Bullets in the reserve.")]
	public int StockPile = 50;
	private int BaseAmmo;
	
	[Header("Accuracy")]
	[Tooltip("Base accuracy is the accuracy.")]
	public float baseaccuracy;
	[Tooltip("Accuracy is how precice you want your bullets to be..")]
	public float accuracy;
	[Tooltip("While Aiming down the sights you might want the accuracy to get better.")]
	public float aimaccuracy;
	
	[Header("Reloading")]
	[Tooltip("The speed in which the gun reloads.")]
	public float reloadtime;
	[Tooltip("Tells the script that its reloading.")]
	public bool Isreloading;
	[Tooltip("If your gun is at 0 ammo it will reload by itself.")]
	public bool AutoReload;
	
	[Header("Objects")]
	[Tooltip("Where you want the bullet to shoot from.")]
	public Transform bulletShoot;
	[Tooltip("What do you want the gun to shoot.")]
	public GameObject bulletPrefab;
	[Tooltip("what audio you want the gun to play when shot.")]
	public AudioClip fire1;
	[Tooltip("Players camera.")]
	private Camera MainCamera;
	[Tooltip("ejectionpoint for the gun shells.")]
	public Transform shellejectionpoint;
	[Tooltip("What do you want the gun to eject.")]
	public GameObject shell;
	[Tooltip("Test.")]
	public Player_SunDetector Test;
	[Tooltip("3D or 2D ammo counter for the gun.")]
	public TMPro.TMP_Text AmmoCounter;
	[Header("GravityGun")]
	public ParticleSystem Gravity;
	
	[Header("Animations")]
	[Tooltip("Weapons animations.")]
	public Animator anim;

	public void Start()
	{
		baseaccuracy = accuracy;
        MainCamera = GetComponentInParent<Camera>();
		BaseAmmo = magazineSize;
    }
	public void Update()
	{
		if(Time.timeScale != 0)
		{
			if(fireType != FireType.SHOTGUN)
			{
				
			}
			
			if(AmmoCounter != null)
			{
				AmmoCounter.text = (magazineSize + "/" + StockPile).ToString();
			}
        
			StockPile = Mathf.Clamp(StockPile, 0, 1000);
			// takes cool down and fires the gun depending on what Firetype it is.
			if (Time.time >= cooldown)
			{
				if (Input.GetKeyDown(KeyCode.Mouse0) && fireType != FireType.AUTO)
				{
					if(fireType == FireType.SHOTGUN)
					{
						for (int i = 0; i < spreadammount; i++)
						{
							Fire();
							Debug.Log("Shoot with spread");
						}
					}
					if(fireType == FireType.SINGLE)
					{
						Fire();
						Debug.Log("Shoot Single");
					}
					if(fireType == FireType.BURST)
					{
						StartCoroutine(DoBurst());
						Debug.Log("Shoot Burst");
					}
	            
				}

	        
				if (Input.GetKey(KeyCode.Mouse0) && fireType == FireType.AUTO)
				{
					Fire();
					Debug.Log("Shoot Auto");
				}            
			}

			if(Input.GetKeyDown(KeyCode.R))
			{
				if (magazineSize <= 0)
				{
					Reload();
				}
			}
		}
		// Fire a bullet
		}

	public void Fire()
	{     
		if(Time.timeScale != 0)
		{
			if (magazineSize > 0)
			{
				magazineSize -= 1;
				Vector3 ForwardMovment = bulletShoot.transform.forward + (Random.onUnitSphere / baseaccuracy);
				GameObject bPrefab = Instantiate(bulletPrefab, bulletShoot.position, bulletShoot.rotation) as GameObject;
				bPrefab.GetComponent<Rigidbody>().AddForce(ForwardMovment * ShootSpeed);
				cooldown = Time.time + attackSpeed;
				AudioSource.PlayClipAtPoint(fire1, transform.position, 0.2f);
				if(shell != null)
				{
					GameObject Sprefab = Instantiate(shell, shellejectionpoint.position, shellejectionpoint.rotation) as GameObject;
					Sprefab.GetComponent<Rigidbody>().AddForce(transform.right * ejectspeed);
				}
			}
			//if magazineSize = 0 it will reload.
			if(magazineSize <= 0)
			{
				if(AutoReload == true)
				{
					Reload();
				}
			}

		}
		}

	//reloading weapon
	public void Reload()
	{ 
		if(Time.timeScale != 0)
		{
			if(Isreloading == false)
			{
				StartCoroutine(reloadcooldown());
			}
		}
    }
	IEnumerator DoBurst()
	{
		yield return new WaitForSeconds(0.1f);
		Fire();
		yield return new WaitForSeconds(0.1f);
		Fire();
		yield return new WaitForSeconds(0.1f);
		Fire();
	}
    IEnumerator reloadcooldown()
    {
        if (StockPile != 0)
        {
	        //ReloadingUI.SetActive(true);
            Isreloading = true;
            yield return new WaitForSeconds(reloadtime);
            Isreloading = false;
            StockPile -= magazineSize;
	        magazineSize = BaseAmmo;
	        //ReloadingUI.SetActive(false);
        }
    }

}
