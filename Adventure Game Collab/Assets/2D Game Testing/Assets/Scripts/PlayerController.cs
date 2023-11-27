using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using static Cinemachine.DocumentationSortingAttribute;

public class PlayerController : MonoBehaviour
{
    public float speed = 3.0f;
    public GameObject endScreen;
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
    public bool speedGrade { get { return speedUpgrade; } }

    public int maxHealth = 5;
    public int currentHealth;
    public float timeInvincible = 2.0f;
    public int health { get { return currentHealth; } }
    bool isInvincible;
    float invincibleTimer;

    public AudioSource damageSource;

    public int bal { get { return currentBalance; } }
    int currentBalance;

    SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        //Getting some Components
        rb = GetComponent<Rigidbody2D>();
        damageSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        //If we're playing the full game, get some data.
        if (MainManager.Instance != null)
        {
            //Calculate the MaxHp, based on Difficulty + Level.
            maxHealth = 10 + (MainManager.Instance.level * MainManager.Instance.difficulty);
            //Track the Current Health
            currentHealth = MainManager.Instance.currentHealth;
            //Track the Current Balance.
            currentBalance = MainManager.Instance.money;
            //Display the money.
            PlayerHealthBar.instance.SetBalance(currentBalance);
            //Track if the player is in God Mode.
            godMode = MainManager.Instance.godMode;
        }
        else
        {
            currentHealth = maxHealth;
            currentBalance = 0;
        }
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
            //Return all Defaults
            if (MainManager.Instance != null)
                MainManager.Instance.ResetDefaults();

            SceneManager.LoadScene("UI Scene");
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            godMode = !godMode;
            if (MainManager.Instance != null)
                MainManager.Instance.godMode = godMode;
        }

        if (godMode)
        {
            sprite.color = Color.red;
        }
        else
        {
            sprite.color = Color.white;
        }

        if (MainManager.Instance.currentHealth == 0)
        {
            talking = true;
            endScreen.gameObject.SetActive(true);
        }
        else
        {
            endScreen.gameObject.SetActive(false);
        }

        if (MainManager.Instance != null)
        {
            if (MainManager.Instance.level == 3)
            {
                reflectUpgrade = true;
            }

            if (MainManager.Instance.level == 4)
            {
                speedUpgrade = true;
            }
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
                if (MainManager.Instance != null)
                    MainManager.Instance.DamageTaken -= amount;
            }
            currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
            PlayerHealthBar.instance.SetValue(currentHealth / (float)maxHealth);
            if (MainManager.Instance != null)
                MainManager.Instance.currentHealth = currentHealth;
            damageSource.Play();

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
        PlayerHealthBar.instance.SetBalance(currentBalance);
        if(MainManager.Instance != null)
            MainManager.Instance.money = currentBalance;
    }
}
