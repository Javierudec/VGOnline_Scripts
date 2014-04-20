using UnityEngine;
using System.Collections;

public class NursingCelestialNarelle : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Call)
		{
			if(HandSize(delegate(Card c) { return c.name.Contains("Celestial"); }) > 0
			   && VanguardIs("Angel Feather"))
			{
				DisplayConfirmationWindow();
			}
		}
	}

	public override void Update ()
	{
		DelayUpdate(delegate {
			SelectInHand(1, false,
			delegate {
				FromHandToDamage(_SIH_Card);
			},
			delegate {
				return _SIH_Card.name.Contains("Celestial");
			},
			delegate {
				SelectInDamage(1, true,
				delegate {
					FromDamageToHand(_SID_Card);
				});
			}, "Choose a card from your hand with \"Celestial\" in its card name.");
		});
	}
}
