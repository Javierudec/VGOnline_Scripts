using UnityEngine;
using System.Collections;

public class Timer {
	private float accTime;
	private bool bActive;

	public Timer()
	{
		bActive = false;
	}

	public void Update()
	{
		if(bActive)
		{
			accTime += Time.deltaTime;
		}
	}

	public void Start()
	{
		bActive = true;
		accTime = 0;
	}

	public float GetMiliseconds()
	{
		return accTime;
	}

	public void Stop()
	{
		bActive = false;
	}

	public void Resume()
	{
		bActive = true;
	}
}
