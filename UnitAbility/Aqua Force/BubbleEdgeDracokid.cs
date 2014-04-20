using UnityEngine;
using System.Collections;

public class BubbleEdgeDracokid : UnitObject {
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

	public override int Act ()
	{
		if(RC())
		{
			return 1;
		}

		return 0;
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

	public override void Update ()
	{
		Forerunner_Update();

		DelayUpdate(delegate {
			if(VanguardIs("Aqua Force"))
			{
				MoveToSoul(OwnerCard);
				SelectUnit ("Choose one of your \"Aqua Force\".", 1, true,
				delegate {
					SelectAnimField(Unit);
					Unit.unitAbilities.AddUnitObject(new BubbleEdgeDracokidEXT());
				},
				delegate {
					return Unit.BelongsToClan("Aqua Force");
				},
				delegate {

				}, true);
			}
		});
	}
}

public class BubbleEdgeDracokidEXT : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			if(GetDefensor().IsVanguard()
			   && Game.numBattle >= 4
			   && GetDeck().Size() > 0)
			{
				DrawCardWithoutDelay();
			}
		}
	}
}
