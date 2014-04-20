using UnityEngine;
using System.Collections;

/*
 * [AUTO](VC) Limit Break 4 (This ability is active if you have four or 
 * more damage):[Counter Blast (3)] When this unit attacks a vanguard, 
 * you may pay the cost. If you do, choose up to two of your «Bermuda 
 * Triangle» rear-guards, return them to your hand, search your deck for
 * up to one «Bermuda Triangle», call it to (RC), and shuffle your deck.
 * 
 * [CONT](VC):If you have a card named "Top Idol, Pacifica" in your soul, this unit gets [Power]+2000.
 * 
 * [CONT](VC/RC): Lord (If you have a unit without a same clan as this unit, this unit cannot attack)
 */

public class EternalIdolPacifica : UnitObject {
	public override void Cont ()
	{
		int power = 0;
		if(IsInSoul(CardIdentifier.TOP_IDOL__PACIFICA))
		{
			power += 2000;	
		}
		SetPower(power);
	}
	
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			if(GetDefensor().IsVanguard() && VC () && LimitBreak(4) && CB(3))
			{
				DisplayConfirmationWindow();	
			}
			else
			{
				ConfirmAttack ();	
			}
		}
	}
	
	public override void Active ()
	{
		ShowAndDelay();
	}
	
	public override void Update ()
	{
		DelayUpdate(delegate {
			CounterBlast(3,
			delegate {
				int num = min (2, NumUnits(delegate(Card c) { return c.BelongsToClan("Bermuda Triangle"); }));
				SelectUnit("Choose up to " + num + " of your \"Bermuda Triangle\" rear-guards.", num, false,
				delegate {
					ReturnToHand(Unit);
				},
				delegate {
					return Unit.BelongsToClan("Bermuda Triangle");
				},
				delegate {
					if(GetDeck().Size() > 0)
					{
						SetBool(1);
						GetDeck().ViewDeck(1, delegate(Game2DCard c) {
							return c._CardInfo.BelongsToClan("Bermuda Triangle");	
						});
					}
					else
					{
						EndEffect();
						ConfirmAttack();
					}	
				});
			});
		});
		
		if(GetBool(1) && !GetDeck().IsOpen())
		{
			UnsetBool(1);
			_AuxIdVector = GetDeck().GetLastSelectedList();
			if(_AuxIdVector.Count > 0)
			{
				CallFromDeck(_AuxIdVector);
			}
			else
			{
				EndEffect();
				ShuffleDeck();
				ConfirmAttack();
			}
		}
		
		CallFromDeckUpdate(delegate {
			EndEffect();
			ShuffleDeck();
			ConfirmAttack();
		});
	}
	
	public override void Pointer ()
	{
		CounterBlast_Pointer();
		SelectUnit_Pointer(true);
	}
}
