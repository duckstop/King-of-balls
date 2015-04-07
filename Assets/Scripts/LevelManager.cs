using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class LevelManager : MonoBehaviour {

        PlayerController p1;
        Player2Controller p2; 

        Text p1Score;
        Text p2Score;
        private int p1s;
        private int p2s;

        // Use this for initialization
        void Start () {

            p1 = FindObjectOfType<PlayerController>();
            p2 = FindObjectOfType<Player2Controller>();
	
            p1Score =GetComponent<Text>();
            p2Score =GetComponent<Text>();

            p1s = 0;
            p2s = 0;

            p1Score.text = "Player 1: " + p1s;
            p2Score.text = "Player 2: " + p2s;


        }
	
        // Update is called once per frame
        void Update () {

            p1Score.text = "Player 1: " + p1s;
            p2Score.text = "Player 2: " + p2s;

            if(!p2.isAlive){


                p2.enabled = true;
                p2.GetComponent<Renderer>().enabled = true;
                p2.myRigidBody.position = new Vector3(2f, 0f, 0f);
                p2.isAlive = true;
                p1s++;
		
            }

            if(!p1.isAlive){
			

                p1.enabled = true;
                p1.GetComponent<Renderer>().enabled = true;
                p1.myRigidBody.position = new Vector3(2f, 0f, 0f);
                p1.isAlive = true;

                p2s++;
			
            }


	
        }
    }
}
