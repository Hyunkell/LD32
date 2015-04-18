using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

    public float maxSpeed = 200;
    public float acceleration = 20;

    private Rigidbody2D _rigidBody;

    // Use this for initialization
    void Start()
    {
        this._rigidBody = this.GetComponent<Rigidbody2D>();
    }
    
    // Update is called once per frame
    void Update()
    {
        var nInputHorizontal = Input.GetAxis("Horizontal");
        if (this._rigidBody.velocity.x <= this.maxSpeed)
        {
            this._rigidBody.MovePosition(this._rigidBody.position + (new Vector2(nInputHorizontal * this.acceleration, 0) * Time.deltaTime));
            //this.transform.Translate(new Vector3(Input.GetAxis("Horizontal") * this.acceleration, 0, 0) * Time.deltaTime, Space.World);
            
        }
        if (nInputHorizontal != 0)
        {
            var sprite = this.gameObject.GetComponentInChildren<SpriteRenderer>();
			if(nInputHorizontal < 0){
				//Turn sprite to left
                sprite.transform.localScale = 
					new Vector3(1, this.gameObject.transform.localScale.y, this.gameObject.transform.localScale.z);
			} else if( nInputHorizontal > 0){
				//Turn sprite to right
                sprite.transform.localScale = 
					new Vector3(-1, this.gameObject.transform.localScale.y, this.gameObject.transform.localScale.z);
			}


            gameObject.GetComponentInChildren<Animator>().Play("MainCharacterWalking");
        }
        else
        {
            gameObject.GetComponentInChildren<Animator>().Play("MainCharacterIdle");
        }
    }
}
