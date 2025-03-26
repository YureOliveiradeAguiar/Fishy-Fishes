using UnityEngine;

public class LeftFishScript : MonoBehaviour
{
    public EnemyScript enemyScript;
    void Start()
    {
        enemyScript = GetComponent<EnemyScript>();
    }
    void Update()
    {
        if (enemyScript.imAlive)
        {
            transform.position += (Vector3.right * enemyScript.moveSpeed) * Time.deltaTime;
        }
    }
}
