using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dinosaurio : MonoBehaviour
{
    private Rigidbody2D dinoRb;
    [SerializeField] private float upForce;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask ground;
    [SerializeField] private float radius;
    private Animator dinoAnimator;

    // Start is called before the first frame update
    void Start()
    {
        dinoRb = GetComponent<Rigidbody2D>();
        dinoAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        bool isGrounded = Physics2D.OverlapCircle(groundCheck.position, radius, ground);
        dinoAnimator.SetBool("IsGrounded", isGrounded);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                dinoRb.AddForce(Vector2.up * upForce);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, radius);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            GameManager.Instance.ShowGameOverScreen();
            dinoAnimator.SetTrigger("Die");
            Time.timeScale = 0f;
        }
    }
}
