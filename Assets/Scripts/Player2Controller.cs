using UnityEngine;

namespace Assets.Scripts
{
    public class Player2Controller : MonoBehaviour {
	
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
	
        // Use this for initialization
        void Start () {
		
            myRigidBody = GetComponent<Rigidbody2D>();
            controlsActive = true;
            isAlive = true;
		
        }

        void Update(){
		
            if (intersects){
                delay++;
                delayTimer();
            }
        }
	
        // Update is called once per frame
        void FixedUpdate () {
		
			if (GetComponent<NetworkView> ().isMine) {
				if (controlsActive) {
					moveVertical = 0.0f;
					moveHorizontal = 0.0f;
            	
					if (Input.GetKey (KeyCode.W)) {
            	
						moveVertical = 1.0f;
            	
					}
            	
					if (Input.GetKey (KeyCode.S)) {
            	
						moveVertical = -1.0f;
            	
					}
					if (Input.GetKey (KeyCode.A)) {
            	
						moveHorizontal = -1.0f;
            	
					}
					if (Input.GetKey (KeyCode.D)) {
            	
						moveHorizontal = 1.0f;
            	
					}
            	
					Vector3 movement = new Vector3 (moveHorizontal, moveVertical, 0.0f);
					myRigidBody.velocity = movement * speed;
				}
			}
		
        }

        void OnTriggerEnter2D(Collider2D other){
		
            if(other.tag == "Player"){
			
                Debug.Log("Intersect!!");
			
                controlsActive = false;
			
                intersects = true;
			
                PlayerController p1 = FindObjectOfType<PlayerController>();
			
                if(moveHorizontal > 0){
				
                    Vector3 negativeMovement = new Vector3(moveHorizontal, moveVertical, 0.0f);
                    p1.myRigidBody.velocity = negativeMovement * speed;
                    p1.delay = 0;
				
                }
			
                else{
				
                    Vector3 negativeMovement = new Vector3(moveHorizontal, moveVertical, 0.0f);
                    p1.myRigidBody.velocity = negativeMovement * speed;
                    p1.delay = 0;
				
                }
			
			
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
