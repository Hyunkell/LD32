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
        if (this._rigidBody.velocity.x <= this.maxSpeed)
        {
            this.transform.Translate(new Vector3(Input.GetAxis("Horizontal") * this.acceleration, 0, 0) * Time.deltaTime, Space.World);
        }
    }
}
