using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ShipController : MonoBehaviour
{
    private new Rigidbody2D rigidbody;
    private Vector2 movement;
    private GameObject shipPlayer;
    private Vector3 pos;

    public float speed = 1f;
    private float posX;
    private const float MAX_SPEED = 4f;
    private float currentSpeed;
    private float movementX;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        //shipPlayer = GameObject.FindGameObjectsWithTag("shipTag");

        posX = Random.Range(-10, 10);
        pos = new Vector3(posX, -2, -11);

        transform.position = pos;
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        movement = new Vector2(moveHorizontal, 0f);
    }

    // FixedUpdate se llama en cada fixed frame-rate frame. (50 llamadas por segundo, por defecto)
    void FixedUpdate()
    {
        //Limitamos la velocidad (fuerza aplicada)
        currentSpeed = Mathf.Min(speed, MAX_SPEED);

        // Aplica la fuerza al Rigidbody2d
        rigidbody.AddForce(movement * currentSpeed * 5f);
    }
}
