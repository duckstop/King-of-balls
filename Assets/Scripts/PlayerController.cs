using UnityEngine;

namespace Assets.Scripts
{
    public class PlayerController : MonoBehaviour {

        public float speed;
        public float tilt;
        public Rigidbody2D myRigidBody;
        private float moveHorizontal;
        private float moveVertical;
        public float knockbackDelay;
        
        public float delay;

        private bool controlsActive;
        private bool intersects;
        public bool isAlive = true;

	
        float movePos = 0.0f;
	
        // Use this for initialization
        void Start () {

            myRigidBody = GetComponent<Rigidbody2D>();
            controlsActive = true;
            isAlive = true;
	        
	
        }
	
        // Update is called once per frame
        void Update(){

            if (intersects){
                delay++;
                delayTimer();
            }
        }

        void FixedUpdate () {

			if (GetComponent<NetworkView> ().isMine) {
				if (controlsActive) {
            	
            	
            	
					moveVertical = 0.0f;
					moveHorizontal = 0.0f;
            	
            	
					if (Input.GetKey (KeyCode.UpArrow)) {
            	
						moveVertical = 1.0f;
            	
					}
            	
            	
            	
					if (Input.GetKey (KeyCode.DownArrow)) {
            	
						moveVertical = -1.0f;
            	
					}
					if (Input.GetKey (KeyCode.LeftArrow)) {
            	
						moveHorizontal = -1.0f;
            	
					}
					if (Input.GetKey (KeyCode.RightArrow)) {
            	
						moveHorizontal = 1.0f;
            	
					}
					Vector3 movement = new Vector3 (moveHorizontal, moveVertical, 0.0f);
            	
					myRigidBody.velocity = movement * speed;
            	  
            	
				}
			}

	

        }

        void OnTriggerEnter2D(Collider2D other){

            if(other.tag == "Player2"){

                Debug.Log("Intersect!!");

                controlsActive = false;
		
                intersects = true;

              /*  Player2Controller p2 = FindObjectOfType<Player2Controller>();

                if(moveHorizontal > 0){

                    Vector3 negativeMovement = new Vector3(moveHorizontal, moveVertical, 0.0f);
                    p2.myRigidBody.velocity = negativeMovement * speed;
                    p2.delay = 0;
		
                }

                else{

                    Vector3 negativeMovement = new Vector3(moveHorizontal, moveVertical, 0.0f);
                    p2.myRigidBody.velocity = negativeMovement * speed;
                    p2.delay = 0;

                }


			*/



            }

        }

        void delayTimer(){

            if(delay > knockbackDelay){
			
                Debug.Log("Countdown done!");
                controlsActive = true;
			
                delay = 0;
                intersects = false;
			
            }

        }

    }
}
