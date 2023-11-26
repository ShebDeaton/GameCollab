using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed = 3.0f;
    public Vector2 position;
    public Vector2 SwordPosition;
    public float horizontalInput;
    public float verticalInput;
    Rigidbody2D rb;
    Animator animator;
    Vector2 lookDirection = new Vector2(0, -1);
    public bool godMode;
    public Vector2 lookdir { get { return lookDirection; } }
    Vector2 move;
    public GameObject swordPrefab;
    private bool isAttacking = false;
    private bool talking = false;
    public bool getTalk { get { return talking; } }

    public bool reflectUpgrade = false;
    public bool speedUpgrade = false;
    public bool reflect { get { return reflectUpgrade; } }
    public bool speedGrade {  get {  return speedUpgrade; } }

    public int maxHealth = 5;
    int currentHealth;
    public float timeInvincible = 2.0f;
    public int health { get { return currentHealth; } }
    bool isInvincible;
    float invincibleTimer;

    public int bal { get { return currentBalance; } }
    int currentBalance;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;
        currentBalance = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAttacking && !talking) { 
            horizontalInput = Input.GetAxis("Horizontal");
            verticalInput = Input.GetAxis("Vertical");

            move = new Vector2(horizontalInput, verticalInput);

            if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
            {
                lookDirection.Set(move.x, move.y);
                lookDirection.Normalize();
            }

            animator.SetFloat("Look X", lookDirection.x);
            animator.SetFloat("Look Y", lookDirection.y);
            animator.SetFloat("Speed", move.magnitude);

            if (isInvincible)
            {
                invincibleTimer -= Time.deltaTime;
                if (invincibleTimer < 0)
                {
                    isInvincible = false;
                }
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                StartCoroutine(Swing());
            }
        }
        if (talking)
        {
            animator.SetFloat("Speed", 0);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("UI Scene");
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            godMode = !godMode;
        }
    }

    private void FixedUpdate()
    {
        if (!isAttacking && !talking)
        {
            position = transform.position;
            position = position + move * speed * Time.deltaTime;

            transform.position = position;

            Vector2 playerSwordCenter = position;
            playerSwordCenter.Set(position.x,(position.y+0.5f));

            SwordPosition = swordPrefab.transform.position;
            SwordPosition = playerSwordCenter + lookDirection;
            swordPrefab.transform.position = SwordPosition;
        }

    }

    public void ChangeHealth(int amount)
    {
        if (!godMode)
        {
            if (amount < 0)
            {
                if (isInvincible)
                    return;

                isInvincible = true;
                invincibleTimer = timeInvincible;
            }
            currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
            Debug.Log(currentHealth + "/" + maxHealth);
        }
    }

    public void isTalking(bool talk)
    {
        talking = talk;
    }

    IEnumerator Swing()
    {
        isAttacking = true;
        swordPrefab.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.25f);
        swordPrefab.gameObject.SetActive(false);
        isAttacking = false;

    }

    public void ChangeBalance(int amount)
    {
        currentBalance = currentBalance + amount;
        Debug.Log("Current Balance: " + currentBalance);
    }
}
