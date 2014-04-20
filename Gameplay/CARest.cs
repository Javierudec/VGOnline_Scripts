using UnityEngine;
using System.Collections;

public class CARest : CardAnimation {

	bool bDoRestAnimation = false;

	public CARest(Card c) : base(c)
	{
		bDoRestAnimation = true;
	}

	public override bool NextUpdate ()
	{
		if(bDoRestAnimation)
		{
			if(GetModel().eulerAngles.y > 90.0f)
			{
				GetModel().eulerAngles = new Vector3(GetModel().eulerAngles.x, GetModel().eulerAngles.y - 20.0f, GetModel().eulerAngles.z);
			}
			else
			{
				GetModel().eulerAngles = new Vector3(GetModel().eulerAngles.x, 90.0f, GetModel().eulerAngles.z);
				bDoRestAnimation = false;
			}
		}

		return bDoRestAnimation;
	}
}
