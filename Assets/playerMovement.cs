using System.Collections;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 5f;
    public int counter = 1;   // saltos disponibles

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKey("left"))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        if (Input.GetKey("right"))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        if (Input.GetKeyDown("space"))
        {
            jump();
        }
    }

    public void jump()
    {
        if (counter >= 1)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
            counter = 0;
            StartCoroutine(DoAfterDelay(3.0f));
        }
    }

    IEnumerator DoAfterDelay(float delaySeconds)
    {
        yield return new WaitForSeconds(delaySeconds);
        counter = 1;
    }
}