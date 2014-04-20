using UnityEngine;
using System.Collections;

/*
 * [AUTO] (VC) Limit Break 4 (This ability is active if you have four or more
 * damage):[Counter Blast (2) & Choose a card named "Thundering Ripple, Genovious"
 * from your hand, and discard it] At end of the battle that this unit attacked a 
 * vanguard, if the number of [Rest] «Aqua Force» in your front row is three, you may
 * pay the cost. If you do, [Stand] all of your «Aqua Force» rear-guards.
 * 
 * [CONT](VC):If you have a card named "Rising Ripple, Pavroth" in your soul, 
 * this unit gets [Power]+1000.
 */

public class ThunderingRippleGenovious : UnitObject {
	public override void Cont ()
	{
		if(VC ()
		   && IsInSoul(CardIdentifier.RISING_RIPPLE__PAVROTH))
		{
			AddContPower(1000);
		}
	}

	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Attacking)
		{
			if(GetDefensor ().IsVanguard())
			{
				SetBool(1);
			}
		}
		else if(cs == CardState.EndBattle)
		{
			if(GetBool(1)
			   && VC ()
			   && LimitBreak(4)
			   && CB (2)
			   && HandSize(delegate(Card c) { return c.cardID == CardIdentifier.THUNDERING_RIPPLE__GENOVIOUS; }) > 0
			   && NumUnits(delegate(Card c) { return IsInFrontRow(c) && !c.IsStand() && c.BelongsToClan("Aqua Force"); }, true) == 3)
			{
				DisplayConfirmationWindow();
			}
			UnsetBool(1);
		}
	}

	public override void Active()
	{
		ShowAndDelay();
	}

	public override void Update ()
	{
		DelayUpdate(delegate {
			CounterBlast(2,
			delegate {
				SelectInHand(1, true,
				delegate {
					DiscardSelectedCard();
				},
				delegate {
					return _SIH_Card.cardID == CardIdentifier.THUNDERING_RIPPLE__GENOVIOUS;
				},
				delegate {
					ForEachUnitOnField(delegate(Card c) {
						if(c.BelongsToClan("Aqua Force"))
						{
							StandUnit(c);
						}
					});
				}, "Choose a card named \"Thundering Ripple, Genovious\" from your hand.");
			});
		});
	}
}
