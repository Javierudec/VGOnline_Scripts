using UnityEngine;
using System.Collections;

public class LordOfTheSevenSeasNightmist : UnitObject {
	Card unitCalled = null;

	public override void Cont ()
	{
		if(VC ()
		   && IsPlayerTurn()
		   && NumUnits (delegate(Card c) { return c.BelongsToClan("Granblue"); }) >= 4)
		{
			AddContPower(2000);
		}
	}

	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.RideAboveIt)
		{
			if(VanguardIs("Granblue")
			   && LimitBreak(4))
			{
				StartEffect();
				ShowAndDelay();
			}
		}
	}

	public override void Update ()
	{
		DelayUpdate(delegate {
			IncreasePowerByTurn(GetVanguard(), 10000);
			SetBool(1);
			Game.field.ViewDropZone(2, delegate(Card c) {
				return c.BelongsToClan("Granblue");
			});
		});

		ResolveDropOpening(1,
		delegate {
			unitCalled = Game.field.GetDropByID(_AuxIdVector[0]);
			_AuxIdVector.RemoveAt(0);
			CallFromDrop(unitCalled);
		},
		delegate {
			EndEffect();
		});

		CallFromDropUpdate(delegate {
			IncreasePowerByTurn(unitCalled, 5000);
			unitCalled.unitAbilities.AddUnitObject(new LordOfTheSevenSeasNightmistEXT());
			if(_AuxIdVector.Count > 0)
			{
				unitCalled = Game.field.GetDropByID(_AuxIdVector[0]);
				_AuxIdVector.RemoveAt(0);
				CallFromDrop(unitCalled);
			}
			else
			{
				EndEffect();
			}
		});
	}
}

public class LordOfTheSevenSeasNightmistEXT : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.EndTurn)
		{
			RetireUnit (OwnerCard);
		}
	}
}
