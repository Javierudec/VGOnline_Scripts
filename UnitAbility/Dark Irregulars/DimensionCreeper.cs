using UnityEngine;
using System.Collections;

public class DimensionCreeper : UnitObject {
	public override int EffectOnSoul ()
	{
		if(GetDeck ().Size() >= 2)
		{
			return 1;
		}

		return 0;
	}

	public override void Active ()
	{
		StartEffect();
		ShowAndDelay();
		Game.field.CloseDeck();
	}

	public override void Update ()
	{
		DelayUpdate(delegate {
			_AuxIdVector = new System.Collections.Generic.List<CardIdentifier>();
			_AuxIdVector.Add(OwnerCard.cardID);
			SoulBlast(_AuxIdVector);
		});

		SoulBlastUpdate(delegate {
			if(VanguardIs("Dark Irregulars"))
			{
				SoulCharge(2);
			}
			else
			{
				EndEffect();
			}
		});

		SoulChargeUpdate(delegate {
			EndEffect();
		});
	}
}
