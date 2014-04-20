using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShuraStealthDragonKabukicongo : UnitObject {
	List<Card> bindList = null;

	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			if(VC ()
			   && LimitBreak(4)
			   && GetDefensor().IsVanguard()
			   && CB(1))
			{
				SetBool(1);
				DisplayConfirmationWindow();
			}
		}
		else if(cs == CardState.HelpZone_EndTurn)
		{
			for(int i = 0; i < bindList.Count; i++)
			{
				OpponentFromBindToHand(bindList[i]);
			}
			RemoveFromHelpZone(OwnerCard);
		}
	}

	public override bool Cancel ()
	{
		UnsetBool(1);
		return true;
	}

	public override int Act ()
	{
		if(VC()
		   && CB(1))
		{
			return 1;
		}

		return 0;
	}

	public override void Update ()
	{
		DelayUpdate (delegate {
			if(GetBool(1))
			{
				UnsetBool(1);
				CounterBlast(1,
				delegate {
					bindList = new List<Card>();

					ForEachEnemyUnitOnField(delegate(Card c) {
						if(c.IsFaceup())
						{
							if(BindEnemyUnit(c))
							{
								bindList.Add (c);
							}
						}
					});

					if(NumEnemyUnitsBind() >= 3)
					{
						IncreasePowerByBattle(OwnerCard, 10000);
					}

					AddToHelpZone(OwnerCard);

					EndEffect();
				});
			}
			else
			{
				CounterBlast(1,
				delegate {
					IncreasePowerByTurn(OwnerCard, 2000);
					EndEffect();
				});
			}
		});
	}
}
