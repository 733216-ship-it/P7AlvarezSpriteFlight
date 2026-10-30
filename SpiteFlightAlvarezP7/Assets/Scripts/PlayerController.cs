using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float thrustForce = 1f;
    Rigidbody2D rb;
    public float maxSpeed = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Mouse.current.leftButton.isPressed) {
            // Calculate the mouse position
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.value);
            Vector2 direction = (mousePos - transform.position).normalized;

            //Move player in diercton of the mouse
            transform.up = direction;
            rb.AddForce(direction * thrustForce);
            if (rb.linearVelocity.magnitude > maxSpeed)
            {
                rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }


}