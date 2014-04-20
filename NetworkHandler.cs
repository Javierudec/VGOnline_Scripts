using UnityEngine;
using System.Collections;

public class NetworkHandler : MonoBehaviour {
	public bool IsServer;
	public string IPAddress;
	public string Port;
	public int maxConnections;
	
	// Use this for initialization
	void Start () {
		IPAddress = "127.0.0.1";
		Port = "27911";
		maxConnections = 10;
	}
	
	// Update is called once per frame
	void Update () {

	}
	
	void OnGUI()
	{
		/*
		if(ConnectedToServer)
		{
			GUI.Box (new Rect(0.0f, 50.0f, 100.0f, 25.0f), "Connected!");		
		}
		*/
		/*
		if(ServerCreated)
		{
			string str = "Server at " + IPAddress + " in the port " + Port;
			GUI.Box (new Rect(0.0f, 50.0f, 240.0f, 25.0f), str);	
		}
		*/
		
		if(Network.peerType == NetworkPeerType.Client)
		{
			GUI.Box (new Rect(0.0f, 50.0f, 100.0f, 25.0f), "Client");	
		}
		else if(Network.peerType == NetworkPeerType.Connecting)
		{
			GUI.Box (new Rect(0.0f, 50.0f, 100.0f, 25.0f), "Connecting");	
		}
		else if(Network.peerType == NetworkPeerType.Disconnected)
		{
			GUI.Box (new Rect(0.0f, 50.0f, 100.0f, 25.0f), "Disconnected");		
		}
		else if(Network.peerType == NetworkPeerType.Server)
		{
			GUI.Box (new Rect(0.0f, 50.0f, 100.0f, 25.0f), "Server");		
		}
		
		IPAddress = GUI.TextField(new Rect(0.0f, 125.0f, 100.0f, 25.0f), IPAddress);
		Port = GUI.TextField(new Rect(0.0f, 150.0f, 100.0f, 25.0f), Port);
		
		if(GUI.Button(new Rect(0.0f, 75.0f, 100.0f, 25.0f), "Server"))
		{
			Network.InitializeServer(maxConnections, int.Parse(Port), false);
		}
		
		if(GUI.Button(new Rect(0.0f, 100.0f, 100.0f, 25.0f), "Connect"))
		{
			Network.Connect(IPAddress, int.Parse(Port));
		}
	}
}
