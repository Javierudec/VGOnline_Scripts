using UnityEngine;
using System.Collections;

/*
 * [CONT](VC):If you have a card named "Fate Healer, Ergodiel" in your soul, 
 * this unit gets [Power]+1000.
 * 
 * [AUTO] (VC):[Counter Blast (2) & Choose a card named "Cosmo Healer, Ergodiel"
 * from your hand, and discard it] When this unit's attack hits a vanguard,
 * you may pay the cost. If you do, choose a card from your damage zone, and heal it.
 */

public class CosmoHealerErgodiel : UnitObject {
	public override void Cont ()
	{
		if(VC () 
		   && IsInSoul(CardIdentifier.FATE_HEALER__ERGODIEL))
		{
			AddContPower(1000);
		}
	}

	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.AttackHits)
		{
			if(VC ()
			   && GetDefensor().IsVanguard()
			   && CB(2)
			   && HandSize(delegate(Card c) { return c.cardID == CardIdentifier.COSMO_HEALER__ERGODIEL; }) > 0
			   && NumUnitsDamage() > 0)
			{
				DisplayConfirmationWindow();
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
			CounterBlast(2,
			delegate {
				SelectInHand(1, false,
				delegate {
					DiscardSelectedCard();
				},
				delegate {
					return _SID_Card.cardID == CardIdentifier.COSMO_HEALER__ERGODIEL;
				},
				delegate {
					Heal(1,
					delegate {
						EndEffect();
					});
				}, "Choose a card named \"Cosmo Healer, Ergodiel\" from your hand.");
			});
		});
	}
}
