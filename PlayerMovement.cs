using System;
using UnityEngine;

public class PlayerMovement3D : MonoBehaviour
{
    public float moveSpeed = 5f; // Rychlost pohybu hráče
    public float jumpForce = 10f; // Síla skoku hráče
    private bool canReceiveJumpBoost = true; // Flag to track whether the player can receive the jump boost

    private Rigidbody rb; // Rigidbody komponenta hráče
    private bool isGrounded; // Příznak, zda je hráč na zemi

    void Start()
    {
        // Získání Rigidbody komponenty hráče
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Pohyb hráče vpřed a vzad (nebo strana od strany) pomocí kláves A a D
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(0f, rb.velocity.y, horizontalInput * moveSpeed);
        rb.velocity = movement;

        // Skákání hráče
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            // Apply the regular jump force
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            // Apply the jump boost if available
            if (canReceiveJumpBoost)
            {
                ApplyJumpBoost();
            }
        }
    }

    private void ApplyJumpBoost()
    {
        throw new NotImplementedException();
    }

    // Method to check if the player is grounded
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    // Method to apply the jump boost
    public void ApplyJumpBoost(float boostForce)
    {
        canReceiveJumpBoost = false; // Prevent further jump boosts until reset
        rb.AddForce(Vector3.up * boostForce, ForceMode.Impulse);
    }

    // Method to reset the jump boost
    public void ResetJumpBoost()
    {
        canReceiveJumpBoost = true;
    }
}
