using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PasueUnpause : MonoBehaviour
{
	public GameObject Pause;
	public GameObject Resume;

    // Start is called before the first frame update
    void Start()
    {
	    Pause.SetActive(true);
	    Resume.SetActive(false);
    }
	public void ResumeTrue()
	{
		Pause.SetActive(true);
		Resume.SetActive(false);
		Time.timeScale = 0;
	}
	public void PauseTrue()
	{
		Pause.SetActive(false);
		Resume.SetActive(true);
		Time.timeScale = 1;
	}
}
