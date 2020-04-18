﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_SunDetector : MonoBehaviour
{
    [SerializeField] private Transform SunDirection;
    [SerializeField] private Transform solarPanel;
    [SerializeField] private RaycastHit hit;

    [SerializeField] private Renderer Player_renderer;

    [SerializeField] private bool InSun;

    [Header("Health")]
    public int Charge;

    [Header("Charge")]
    [SerializeField] private float chargeTime = 1f;
    private float coolDown;

    [SerializeField] private float dischargeTime = 1f;
    private float discoolDown;

    private void Start()
    {
        //Set base values
        coolDown = chargeTime;
        discoolDown = dischargeTime;
    }

    private void Update()
    {
        if (!SunDirection) return; //If the sun transform is not found, disable the script.

        //Lower the player health every frame
        DischargePlayer();

        //Clamp the frames
        Charge = Mathf.Clamp(Charge, 0, 100);

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
            }
        }
    }
}