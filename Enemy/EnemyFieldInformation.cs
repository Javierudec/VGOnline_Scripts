using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum EnemyFieldPosition
{
	DROP,
	DECK,
	VANGUARD,
	REAR_LEFT,
	REAR_CENTER,
	REAR_RIGHT,
	FRONT_LEFT,
	FRONT_RIGHT,
	DRIVE
}

public class EnemyFieldInformation {
	private List<Vector3> positions;
	private Vector3 cardRotation;
	private Vector3 cardDriveRotation;
	
	public EnemyFieldInformation()
	{
		positions = new List<Vector3>();
		cardRotation = new Vector3(0.0f, 0.0f, 0.0f);
		cardDriveRotation = new Vector3(0.0f, - 90.0f, 0.0f);
		SetupPositions();
	}
	
	private void SetupPositions()
	{
		//Same order as in fieldPositions enum
		positions.Add(new Vector3(-16.13057f, 0.5970612f, 17.45758f)); //Drop Zone
		positions.Add(new Vector3(-16.27214f, 0.5970612f, 9.258683f)); //Deck Zone
		positions.Add(new Vector3(-0.04151185f, 0.62f, 9.55506f)); //Vanguard
		positions.Add(new Vector3(8.989822f, 0.5970612f, 19.25502f)); //Rear left
		positions.Add(new Vector3(0.1030064f, 0.5970612f, 19.20929f)); //Rear center
		positions.Add(new Vector3(-8.765222f, 0.5970612f, 19.16366f)); //Rear right
		positions.Add(new Vector3(8.961312f, 0.5970612f, 9.662911f)); //Front left
		positions.Add(new Vector3(-8.715863f, 0.5970612f, 9.571945f)); //Front right
		
		
		positions.Add(new Vector3(-15.77659f, 0.6432791f, 2.407439f)); //Drive
	}
	
	public Vector3 GetPosition(int index)
	{
		return positions[index];	
	}
	
	public Vector3 GetCardRotation()
	{
		return cardRotation;	
	}
	
	public Vector3 GetDriveRotation()
	{
		return cardDriveRotation;	
	}
}
