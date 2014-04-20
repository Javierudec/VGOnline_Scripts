using UnityEngine;
using System.Collections;

public class StealthRogueOfKiteGoemon : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.RideAboveIt)
		{
			if(VanguardIs("Murakumo"))
			{
				SetBool(1);
				Forerunner("Murakumo");
			}
		}
	}

	public override int Act ()
	{
		if(RC ()
		   && CanSoulBlast(1))
		{
			return 1;
		}

		return 0;
	}

	public override bool Cancel ()
	{
		UnsetBool(1);
		return true;
	}

	public override void Active ()
	{
		if(GetBool(1))
		{
			UnsetBool(1);
			Forerunner_Active();
		}
	}

	public override void Update ()
	{
		Forerunner_Update();

		DelayUpdate(delegate {
			SoulBlast(1);
		});

		SoulBlastUpdate(delegate {
			if(VanguardIs("Murakumo")
			   && OpenRC())
			{
				SelectOpenRC(delegate(fieldPositions p) {
					MoveToOpenRC(OwnerCard, p);
					EndEffect();
				});
			}
			else
			{
				EndEffect();
			}
		});
	}
}



