using UnityEngine;
using System.Collections;

public class BlueRoseMusketeerErnest : UnitObject {
	public override int Act ()
	{
		if(RC()
		   && CB(1))
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
				FromFieldToDeck(OwnerCard, true);
				if(VanguardIs("Neo Nectar") && GetDeck().Size() > 0)
				{
					SetBool(1);
					GetDeck().ViewDeck(1, SearchMode.TOP_CARD, min(4, GetDeck().Size()), delegate(Game2DCard c) {
						return c._CardInfo.name.Contains("Musketeer");
					});
				}
				else
				{
					EndEffect();
				}
			});
		});

		ResolveDeckOpening(1,
		delegate {
			CallFromDeck(_AuxIdVector);
		},
		delegate {
			EndEffect();
			ShuffleDeck();
		});

		CallFromDeckUpdate(delegate {
			EndEffect();
			ShuffleDeck();
		});
	}
}
