using UnityEngine;

namespace Assets.Scripts
{
    public class Bounderies : MonoBehaviour {

        private PlayerController player;
        private Player2Controller player2;

        // Use this for initialization
        void Start () {
	
            player = FindObjectOfType<PlayerController>();
            player2 = FindObjectOfType<Player2Controller>();
        }
	
        // Update is called once per frame
        void Update () {


	
        }

        void OnTriggerEnter2D(Collider2D other){

            if (other.tag == "Player"){

                player.enabled = false;
                player.GetComponent<Renderer>().enabled = false;

                player.isAlive = false;

                Debug.Log("HIT!");	

            }

            if (other.tag == "Player2"){
			
                player2.enabled = false;
                player2.GetComponent<Renderer>().enabled = false;

                player2.isAlive = false;
			
                Debug.Log("HIT! Player 2");
			
            }

        }
    }
}
