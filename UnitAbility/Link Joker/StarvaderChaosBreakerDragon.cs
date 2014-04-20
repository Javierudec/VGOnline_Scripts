using UnityEngine;
using System.Collections;

public class StarvaderChaosBreakerDragon : UnitObject {
	Card cardToRetire = null;

	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.EnemyUnlockCard)
		{
			Game.GameChat.AddChatMessage("ADMIN", "EnemyUnlockCard: " + ownerEffect.name);
			if(VC()
			   && LimitBreak(4)
			   && GetEnemyPhase() == EnemyPhase.ENDTURN
			   && CanSoulBlast(1, delegate(Card c) { return c.name.Contains("Star-vader"); }))
			{
				cardToRetire = ownerEffect;
				SetBool(1);
				DisplayConfirmationWindow();
			}
		}
		else if(cs == CardState.EndTurn)
		{
			UnsetBool(2);
		}
	}

	public override bool Cancel ()
	{
		UnsetBool(1);
		return true;
	}

	public override int Act ()
	{
		if(VC ()
		   && CB(1)
		   && HandSize(delegate(Card c) { return c.name.Contains("Star-vader"); }) > 0
		   && NumEnemyUnits(delegate(Card c) { return true; }) > 0
		   && !GetBool(2))
		{
			return 1;
		}

		return 0;
	}

	public override void Update ()
	{
		DelayUpdate(delegate {
			if(GetBool(1))
			{
				UnsetBool(1);
				SoulBlast(1, delegate(Card c) { return c.name.Contains("Star-vader"); });
			}
			else
			{
				CounterBlast(1,
				delegate {
					SelectInHand(1, false,
					delegate {
						DiscardSelectedCard();
					},
					delegate {
						return _SIH_Card.name.Contains("Star-vader");
					},
					delegate {
						SelectEnemyUnit("Choose one of your opponent's rear-guards.", 1, true,
						delegate {
							LockEnemyUnit(EnemyUnit);
						},
						delegate {
							return true;
						},
						delegate {
							SetBool(2);
						});
					}, "Choose a card from your hand with \"Star-vader\" in its card name.");
				});
			}
		});

		SoulBlastUpdate(delegate {
			RetireEnemyUnit(cardToRetire);
			if(GetDeck().Size() > 0)
			{
				DrawCardWithoutDelay();
			}
			Game.GameChat.AddChatMessage("ADMIN", "Ending effect.");
			EndEffect();
		});
	}
}
