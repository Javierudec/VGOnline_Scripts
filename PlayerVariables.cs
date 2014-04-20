using UnityEngine;
using System.Collections;

public class PlayerVariables {
	public static string playerName = "";
	public static string enemyName  = "";
	public static string DeckName   = "";

	public static NetworkPlayer player;
	public static NetworkPlayer opponent;

	public static bool bFirstTurn;
	public static bool bHost;
	public static bool bPlayingOnServer;
	public static bool bPlayerConnected = false;
	public static bool bPlayingAgainstIA = false;

	public static EnemyAI enemyAI;
}
