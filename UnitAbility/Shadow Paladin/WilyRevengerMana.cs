using UnityEngine;
using System.Collections;

public class WilyRevengerMana : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.Call || cs == CardState.Ride)
		{
			if(VanguardIs("Shadow Paladin")
			   && GetDeck().Size() > 0)
			{
				DisplayConfirmationWindow();
			}
		}
	}

	public override void Update ()
	{
		DelayUpdate(delegate {
			GetFieldWatcher().Reset();
			GetFieldWatcher().AddCardList(GetDeck().getCardList());
			GetFieldWatcher().Filter(delegate(Card c) {
				return c.name.Contains("Revenger") && c.grade <= 1;
			});
			GetFieldWatcher().SetActionToPerform(delegate(Card c) {
				CallFromDeck(c, GetSameColumPosition(OwnerCard.pos)); 
				GetFieldWatcher().Close();
				ShuffleDeck();
				c.unitAbilities.AddUnitObject(new WilyRevengerManaEXT());
				EndEffect();
			});
			GetFieldWatcher().SetOnCloseEvent(delegate {
				EndEffect();	 
			});

			GetFieldWatcher().Open();
		});
	}
}

public class WilyRevengerManaEXT : UnitObject {
	public override void Auto (CardState cs, Card ownerEffect)
	{
		if(cs == CardState.EndTurn)
		{
			FromFieldToDeck(OwnerCard, true);
		}
	}
}
