using UnityEngine;
using System.Collections;

public class SilveThornBeastTamerMaricica : UnitObject {
	Card unitCalled;

	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.AttackHits)
		{
			if(CB(1)
			   && GetDefensor().IsVanguard()
			   && VanguardIs("Pale Moon"))
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
			CallFromSoul (unitCalled);
		},
		delegate {
			EndEffect();
		});

		CallFromSoulUpdate(delegate {
			unitCalled.unitAbilities.AddUnitObject(new SilveThornBeastTamerMaricicaEXT());
			EndEffect();
		});
	}
}

public class SilveThornBeastTamerMaricicaEXT : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.EndTurn)
		{
			MoveToSoul(OwnerCard);
		}
	}
}
