using UnityEngine;
using System.Collections;

public class LiberatorCheerUpTrumpeter : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.RideAboveIt)
		{
			if(VanguardIs(OwnerCard.clan))
			{
				SetBool(1);
				Forerunner(OwnerCard.clan);
			}
		}
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
		else
		{
			StartEffect();
			ShowAndDelay();
		}
	}

	public override int Act ()
	{
		if(RC ()
		   && GetVanguard().name.Contains("Liberator"))
		{
			return 1;
		}

		return 0;
	}

	public override void Update ()
	{
		Forerunner_Update();

		DelayUpdate(delegate {
			MoveToSoul(OwnerCard);
			SelectAnimField(GetVanguard());
			GetVanguard().unitAbilities.AddUnitObject(new LiberatorCheerUpTrumpeterEXT());
			EndEffect();
		});
	}
}

public class LiberatorCheerUpTrumpeterEXT : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.CallFromDeck_NotMe)
		{
			if(VC ()
			   && ownerEffect.BelongsToClan("Gold Paladin"))
			{
				IncreasePowerByTurn(OwnerCard, 3000);
			}
		}
	}
}
