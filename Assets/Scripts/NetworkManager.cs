using UnityEngine;
using System.Collections;

public class NetworkManager : MonoBehaviour {

	public string gameName; 
	public bool refreshing; 
	public HostData[] hostData;
	public bool hasServers;
	public GameObject playerPrefab;
	public Transform spawnObject; 




	 

	void startServer(){
		Network.InitializeServer (32, 25001, !Network.HavePublicAddress());
		MasterServer.RegisterHost (gameName, "Test TurtlePir game Name", "This is a test");
		
			}

	void refreshHostList(){
		MasterServer.RequestHostList (gameName);
		refreshing = true;
	 

	}

	void spawnPlayer(){
		Network.Instantiate (playerPrefab, spawnObject.position, Quaternion.identity, 0);

		}

	//Messages
	void OnServerInitialized(){
		Debug.Log ("Server initialized");
		spawnPlayer ();

			}

	void OnConnectedToServer(){
		spawnPlayer ();

		}

	void OnMasterServerEvent(MasterServerEvent mse) {
		if(mse == MasterServerEvent.RegistrationSucceeded){
			Debug.Log("Registered Server");
			}

	}


	// Use this for initialization
	void Start () {

		refreshing = false; 
		gameName = "TestTurtleTest";
		hasServers = false;
		 
	}
	
	// Update is called once per frame
	void Update () {
		if (refreshing) {
			if(MasterServer.PollHostList().Length > 0){
				refreshing = false;
				Debug.Log(MasterServer.PollHostList().Length);
				hostData = MasterServer.PollHostList();
				hasServers = true;


			}

		}
	
	}


	//GUI
	void OnGUI(){
		if(!Network.isClient && !Network.isServer){

		//GUI.Box(new Rect(10,10,100,90), "Loader Menu");
		

		if(GUI.Button(new Rect(20,40,100,30), "Start Server")) {
			Debug.Log("Starting Server"); 
			startServer();
		}
		
		if(GUI.Button(new Rect(20,80,100,30), "Refresh Hosts")) {
			Debug.Log("Refreshing"); 
			refreshHostList();

		}

		if(hasServers){ 
		
			for (int i = 0; i < hostData.Length; i++) {
				if(GUI.Button(new Rect(140,40,180,30), hostData[i].gameName)){
					Network.Connect(hostData[i]);

				}
			}
		}
		}
	}
}
