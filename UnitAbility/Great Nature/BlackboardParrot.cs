using UnityEngine;
using System.Collections;

/*
 * [AUTO]: When another «Great Nature» rides this unit, 
 * you may call this card to (RC).
 * 
 * [ACT](RC): [Put this unit into your soul] Choose one of 
 * your «Great Nature» rear-guards, and that unit gets "[AUTO]:
 * During your end phase, when this unit is put into the drop zone 
 * from (RC), draw a card." until end of turn.
 */

public class BlackboardParrot : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.RideAboveIt)
		{
			if(VanguardIs("Great Nature"))
			{
				SetBool(1);
				Forerunner("Great Nature");
			}
		}
	}

	public override int Act ()
	{
		if(RC ()
		   && NumUnits(delegate(Card c) { return c != OwnerCard && c.BelongsToClan("Great Nature"); }) > 0)
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
		else
		{
			StartEffect();
			ShowAndDelay();
		}
	}

	public override void Update ()
	{
		Forerunner_Update();

		DelayUpdate(delegate {
			MoveToSoul(OwnerCard);
			SelectUnit("Choose one of your \"Great Nature\" rear-guards.", 1, true,
			delegate {
				SelectAnimField(Unit);
				Unit.unitAbilities.AddUnitObject(new BlackboardParrotEXT());
			},
			delegate {
				return Unit.BelongsToClan("Great Nature");
			},
			delegate {

			});
		});
	}
}

public class BlackboardParrotEXT : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.DropZoneFromRC)
		{
			if(CurrentPhaseIs(GamePhase.ENDTURN))
			{
				DrawCardWithoutDelay();
			}
		}
	}
}
