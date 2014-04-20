using UnityEngine;
using System.Collections;

/*
 * [AUTO](RC):When this unit attacks, if you have a «Granblue» vanguard,
 * this unit gets [Power]+3000 until end of that battle, and at the
 * beginning of the end phase of that turn, retire this unit.
 * 
 * [ACT](Drop zone):[Counter Blast (1) & Choose one of your grade 2 or 
 * greater «Granblue» rear-guards and retire it] If you have a «Granblue» 
 * vanguard, call this card to (RC).
 */

public class DragonUndeadSkullDragon : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			if(RC ()
			   && VanguardIs("Granblue"))
			{
				IncreasePowerByBattle(OwnerCard, 3000);
				SetBool(1);
			}
		}
		else if(cs == CardState.EndBattle)
		{
			if(GetBool(1))
			{
				UnsetBool(1);
				RetireUnit(OwnerCard);
			}
		}
	}

	public override int EffectOnDrop ()
	{
		if(CB(1)
		   && NumUnits(delegate(Card c) { return c.BelongsToClan("Granblue") && c.grade >= 2; }) > 0
		   && VanguardIs("Granblue"))
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
			CounterBlast(1,
			delegate {
				SelectUnit("Choose one of your grade 2 or greater \"Granblue\" rear-guards.", 1, false,
				delegate {
					CallFromDrop(OwnerCard);
				},
				delegate {
					return Unit.grade >= 2 && Unit.BelongsToClan("Granblue");
				},
				delegate {

				});
			});
		});

		CallFromDropUpdate(delegate {
			EndEffect();
		});
	}
}
