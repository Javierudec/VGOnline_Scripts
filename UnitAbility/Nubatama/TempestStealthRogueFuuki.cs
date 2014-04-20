using UnityEngine;
using System.Collections;

public class TempestStealthRogueFuuki : UnitObject {
	Card cardToReturn = null;

	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.HelpZone_EndTurn)
		{
			OpponentFromBindToHand(cardToReturn);
			RemoveFromHelpZone(OwnerCard);
		}
	}

	public override int Act ()
	{
		if(CB(1)
		   && VanguardIs("Nubatama")
		   && Game.enemyHand.Size() >= 3)
		{
			return 1;
		}

		return 0;
	}

	public override void Update ()
	{
		DelayUpdate(delegate {
			CounterBlast(1,
			delegate {
				SelectInEnemyHand(1, true,
				delegate {
					cardToReturn = _SIEH_Card;
					OpponentFromHandToBind(Game.enemyHand.GetIndex(_SIEH_Card));
					AddToHelpZone(OwnerCard);
				},
				delegate {
					return true;
				},
				delegate {

				}, "Choose a card from your opponent's hand.");
			});
		});
	}
}
