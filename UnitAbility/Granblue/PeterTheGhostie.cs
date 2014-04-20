using UnityEngine;
using System.Collections;

public class PeterTheGhostie : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.RideAboveIt)
		{
			if(VanguardIs("Granblue"))
			{
				SetBool(1);
				Forerunner("Granblue");
			}
		}
	}

	public override bool Cancel ()
	{
		UnsetBool(1);
		return true;
	}

	public override void Active()
	{
		if(GetBool(1))
		{
			UnsetBool(1);
			Forerunner_Active();
		}
		else
		{
			StartEffect();
			ShowAndDelay();
		}
	}

	public override int Act ()
	{
		if(RC()
		   && CB(1)
		   && GetDeck().Size() >= 3)
		{
			return 1;
		}

		return 0;
	}

	public override void Update ()
	{
		Forerunner_Update();

		DelayUpdate(delegate {
			CounterBlast(1,
			delegate {
				Mill(2);
			});
		});

		MillUpdate(delegate {
			MoveToSoul(OwnerCard);
			if(VanguardIs("Granblue"))
			{
				DrawCardWithoutDelay();
			}
			EndEffect();
		});
	}
}
