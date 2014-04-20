using UnityEngine;
using System.Collections;

public class SilverThornBeastTamerAna : UnitObject {
	Card unitCalled;

	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.AttackHits_NotMe)
		{
			Card tmp = OwnerCard.boostedUnit;
			if(RC ()
			   && CB(1)
			   && GetDefensor().IsVanguard()
			   && GetAttacker() == tmp
			   && tmp.BelongsToClan("Pale Moon")
			   && NumUnitsInSoul(delegate(Card c) { return c.name.Contains("Silver Thorn"); }) > 0)
			{
				DisplayConfirmationWindow();
			}
		}
	}

	public override void Update ()
	{
		DelayUpdate(delegate {
			CounterBlast(1,
			delegate {
				SetBool(1);
				Game.field.ViewSoul(1, delegate(Card c) {
					return c.name.Contains("Silver Thorn");
				});
			});
		});

		ResolveSoulOpening(1,
		delegate {
			unitCalled = Game.field.GetSoulByID(_AuxIdVector[0]);
			CallFromSoul(unitCalled);
		},
		delegate {
			EndEffect();
		});

		CallFromSoulUpdate(delegate {
			unitCalled.unitAbilities.AddUnitObject(new SilverThornBeastTamerAnaEXT());
			EndEffect();
		});
	}
}

public class SilverThornBeastTamerAnaEXT : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.EndTurn)
		{
			MoveToSoul(OwnerCard);
		}
	}
}
