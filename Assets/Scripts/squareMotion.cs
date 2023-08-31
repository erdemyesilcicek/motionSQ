using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class squareMotion : MonoBehaviour
{
    public static bool IsDead { get; set; } = false;

    [SerializeField] float moveSpeed;
    [SerializeField] Rigidbody2D squareRigidbody2D;
    [SerializeField] GameObject gunPrefab;
    [SerializeField] float shotSpeed = 10f;
    private Vector2 moveDirection;
    public float attackCooldown = 0.5f;
    private bool canAttack = true;
    public SceneController controller;
    public static int deadCircles { get; set; }
    void Update()
    {
        Shooting();
        ProcessInputs();
    }
    private void FixedUpdate()
    {
        Move();
    }
    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY);
    }
    void Move()
    {
        squareRigidbody2D.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Circle") && !IsDead)
        {
            IsDead = true;
            Destroy(collision.gameObject);
            Destroy(gameObject);
            SceneController.LastGameScene = SceneManager.GetActiveScene().buildIndex;
            controller.toScene("Lose");
        }
    }
    public void Shooting()
    {
        if (!canAttack) return;
        canAttack = false;

        Vector2 shotDirection = Vector2.zero;

        if (Input.GetKey(KeyCode.UpArrow))
            shotDirection = Vector2.up;
        else if (Input.GetKey(KeyCode.DownArrow))
            shotDirection = Vector2.down;
        else if (Input.GetKey(KeyCode.LeftArrow))
            shotDirection = Vector2.left;
        else if (Input.GetKey(KeyCode.RightArrow))
            shotDirection = Vector2.right;

        if (shotDirection != Vector2.zero)
        {
            Vector3 shotPosition = transform.position;
            GameObject shot = Instantiate(gunPrefab, shotPosition, Quaternion.identity);
            shot.GetComponent<Rigidbody2D>().velocity = shotDirection * shotSpeed;
        }
        StartCoroutine(AttackCooldown());
    }
    IEnumerator AttackCooldown()
    {
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }
}