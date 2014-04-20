using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraPosition : MonoBehaviour {
	private List<Vector3> positions;
	private int curIndex;
	private int nextIndex;
	public int moveSpeed;
	// Use this for initialization
	void Start () {
		positions = new List<Vector3>();
		SetUpPositions();
		
		moveSpeed = 36;
		curIndex = 0;
		nextIndex = 0;
		transform.position = positions[curIndex];
	}
	
	// Update is called once per frame
	void Update () {
		if(curIndex != nextIndex)
		{
			if(Vector3.Distance(transform.position, positions[nextIndex]) < 0.5)
			{
				curIndex = nextIndex;
				transform.position = positions[curIndex];
			}
			else
			{
				transform.position += Vector3.Normalize(positions[nextIndex] - transform.position) * moveSpeed * Time.deltaTime;
			}
		}
	}
	
	private void SetUpPositions()
	{
		positions.Add(new Vector3(0.2712774f, 24.16631f, -30.25842f));
		positions.Add(new Vector3(0.0f, 19.37191f, -22.7334f));
		positions.Add(new Vector3(0.0f, 19.37191f, -15.99553f));
		positions.Add(new Vector3(9.896245f, 8.860885f, -5.329648f));
		positions.Add(new Vector3(0.2192917f, 14.3121f, -0.901718f));
		positions.Add(new Vector3(0.2192917f, 14.46854f, 10.09589f));
		positions.Add(new Vector3(0.2192917f, 14.88841f, 16.46574f));
		positions.Add(new Vector3(-13.19839f, 6.939449f, -0.7321097f));
	}
	
	public void MoveTo(int index)
	{
		nextIndex = index;	
	}
	
	public void SetLocation(CameraLocation loc)
	{
		nextIndex = (int)loc;	
		//Debug.Log(nextIndex);
	}
}

public enum CameraLocation
{
	Hand,
	Rear,
	Front,
	Drive,
	OpponentFront,
	OpponentRear,
	OpponentHand,
	OpponentDrive
}
