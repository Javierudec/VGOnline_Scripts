using UnityEngine;
using System.Collections;

public class CAMoveAndRotate : CardAnimation {
	bool bAnimation = false;

	float speed = 60.0f;
	float startTime;
	float length;

	Vector3 initialPosition;
	float initialAngleX;
	float initialAngleY;
	float initialAngleZ;

	float finalAngleX;
	float finalAngleY;
	float finalAngleZ;

	public CAMoveAndRotate(Card c, Vector3 finalPosition) : base(c, finalPosition)
	{
		bAnimation = true;

		startTime = Time.time;
		length = Vector3.Distance(GetModel().position, GetFinalPosition());
	
		initialPosition = GetModel().position;
		initialAngleX = GetModel().eulerAngles.x;
		initialAngleY = GetModel().eulerAngles.y;
		initialAngleZ = GetModel().eulerAngles.z;

		finalAngleX = 24.0f;
		finalAngleY = 180.0f;
		finalAngleZ = 0.0f;
	}

	public CAMoveAndRotate(Card c, Vector3 finalPosition, Vector3 newAngle): base(c, finalPosition, newAngle)
	{
		bAnimation = true;
		
		startTime = Time.time;
		length = Vector3.Distance(GetModel().position, GetFinalPosition());
		
		initialPosition = GetModel().position;
		initialAngleX = GetModel().eulerAngles.x;
		initialAngleY = GetModel().eulerAngles.y;
		initialAngleZ = GetModel().eulerAngles.z;
		
		finalAngleX = newAngle.x;
		finalAngleY = newAngle.y;
		finalAngleZ = newAngle.z;
	}

	public override bool NextUpdate ()
	{
		if(bAnimation)
		{
			float distCovered = (Time.time - startTime) * speed;
			float fracLength = distCovered / length;
			GetModel().position = Vector3.Lerp(initialPosition, GetFinalPosition(), fracLength);

			float newAngleX = Mathf.LerpAngle(initialAngleX, finalAngleX, fracLength);
			float newAngleY = Mathf.LerpAngle(initialAngleY, finalAngleY, fracLength);
			float newAngleZ = Mathf.LerpAngle(initialAngleZ, finalAngleZ, fracLength);

			GetModel().eulerAngles = new Vector3(newAngleX, newAngleY, newAngleZ);

			if(GetModel().position == GetFinalPosition())
			{
				bAnimation = false;
			}
		}

		return bAnimation;
	}
}
