using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player_SunDetector : MonoBehaviour
{
    //The sun detector will use the transform of the sun to find the shadows
    //For the script to work you need to move the sun on the Z-Axis from the (0,0,0) point to get it exact

    [SerializeField] private Transform SunDirection;
    [SerializeField] private Transform solarPanel;
    [SerializeField] private RaycastHit hit;

    [Header("Player")]
    [SerializeField] private Renderer Player_renderer;
    [SerializeField] private Transform solarPanelObject;

    [SerializeField] private bool InSun;

    [Header("Health")]
    public int Charge;

    [Header("Charge")]
    [SerializeField] private float chargeTime = 1f;
    private float coolDown;

    [SerializeField] private float dischargeTime = 1f;
	private float discoolDown;
	public GameObject Death;
	public Slider slider;
	public TMPro.TMP_Text Percent;
	//public AudioSource AS;
    private void Start()
    {
        //Set base values
        coolDown = chargeTime;
	    discoolDown = dischargeTime;
	    Percent.text = ("%:" + Charge.ToString());
	    slider.value = Charge;
	    Death.SetActive(false);
    }

    private void Update()
	{
		//if(Charge == 40)
		//{
		//	AS.Play();
		//}
		if(Charge <= 0)
		{
			Death.SetActive(true);
		}
        if (!SunDirection) return; //If the sun transform is not found, disable the script.

        //Lower the player health every frame
        DischargePlayer();

        //Clamp the frames
        Charge = Mathf.Clamp(Charge, 0, 100);

        Vector3 lookDir = new Vector3(SunDirection.position.x, transform.position.y, -SunDirection.position.z);

        solarPanelObject.LookAt(lookDir);

        //Do a raycast to the sun point light
        if (Physics.Raycast(solarPanel.position, 1f * SunDirection.position, out hit))
        {
            Player_renderer.material.SetColor("_Color", Color.red);
            Debug.Log("In Shadow");
            InSun = false;
        }
        else
        {
            Player_renderer.material.SetColor("_Color", Color.blue);
            ChargePlayer();
            InSun = true;
        }

        //Debug raycast
        Debug.DrawLine(solarPanel.position, 1f * SunDirection.position, Color.red);
    }

    //Charge the player when they are in the sun
    void ChargePlayer()
    {
        coolDown -= Time.deltaTime;

        if (coolDown < 0 && Charge < 100)
        {
            Charge += 1;
	        coolDown = chargeTime;
	        slider.value = Charge;
	        Percent.text = ("%:" + Charge.ToString());
        }
    }
    
    //Discharge the player when they are in the shadows
    void DischargePlayer()
    {
        if(!InSun)
        {
            discoolDown -= Time.deltaTime;

            if (discoolDown < 0)
            {
                Charge -= 1;
	            discoolDown = dischargeTime;
	            slider.value = Charge;
	            Percent.text = ("%: " + Charge.ToString());
            }
        }
    }
}
