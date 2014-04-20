using UnityEngine;
using System.Collections;

public class CAMove : CardAnimation {
	bool bAnimation = false;

	float speed = 20.0f;
	float startTime;
	float length;

	Vector3 initialPosition;

	public CAMove(Card c, Vector3 finalPosition) : base(c, finalPosition)
	{
		bAnimation = true;

		startTime = Time.time;
		length = Vector3.Distance(GetModel().position, GetFinalPosition());
	
		initialPosition = GetModel().position;
	}

	public override bool NextUpdate ()
	{
		if(bAnimation)
		{
			float distCovered = (Time.time - startTime) * speed;
			float fracLength = distCovered / length;
			GetModel().position = Vector3.Lerp(initialPosition, GetFinalPosition(), fracLength);

			if(GetModel().position == GetFinalPosition())
			{
				bAnimation = false;
			}
		}

		return bAnimation;
	}
}
