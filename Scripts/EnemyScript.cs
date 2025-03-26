using TMPro;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public PlayerScript playerScript;
    public LogicScript logicScript;
    public Animator animator;
    public int lifeBoundary = 220;
    public float moveSpeed;
    private float fishSize;
    private float sizeToAdd;
    public float maxSize = 5.5F;
    public float minSize = 0.5F;
    public float maxSpeed = 60;
    public float minSpeed = 30;
    public bool imAlive = true;
    private float despawnTimer = 0;
    void Start()
    {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
        logicScript = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        moveSpeed = Random.Range (minSpeed, maxSpeed - 1);
        fishSize = Random.Range (minSize, maxSize - 1);
        gameObject.transform.localScale *= fishSize;
        sizeToAdd = fishSize / 100;
        if (fishSize < playerScript.playerSize)
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(0.4F, 0.4F, 0.4F);
        }
    }
    private void Update()
    {
        if (transform.position.x < -lifeBoundary || transform.position.x > lifeBoundary)
        {
            Destroy(gameObject);
        }
        if (!imAlive && despawnTimer < 3)
        {
            despawnTimer += Time.deltaTime;
        }
        else if (!imAlive && despawnTimer >= 3)
        {
           Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6 && imAlive)
        {
            if (playerScript.playerSize >= fishSize)
            {
                PlayerEatsFish();
            }
            else
            {
                logicScript.GameOver();
            }
        }
    }
    public void PlayerEatsFish()
    {
        imAlive = false;
        animator.SetBool("Alive", false);
        playerScript.playerSize += sizeToAdd;
        logicScript.addScore();
        if (playerScript.gameObject.transform.localScale.x > 0)
        {
            playerScript.gameObject.transform.localScale = new Vector3(playerScript.playerSize, playerScript.playerSize, playerScript.playerSize);
        }
        else
        {
            playerScript.gameObject.transform.localScale = new Vector3(-playerScript.playerSize, playerScript.playerSize, playerScript.playerSize);
        }
        if (playerScript.playerSize >= 10)
        {
            logicScript.textMeshPro.text = logicScript.timerMinutes.ToString("00:") + logicScript.timerSeconds.ToString("00");
            logicScript.victoryScreen.SetActive(true);
        }
    }
}
