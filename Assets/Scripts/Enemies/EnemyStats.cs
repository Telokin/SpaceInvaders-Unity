using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{

    [SerializeField]
    private GameObject enemyProjectile;

    [SerializeField]
    private int probability;

    [SerializeField]
    private int random;

    List<GameObject> pooledBuffs;

    public GameObject manager;

    void Update()
    {
        InvokeRepeating("fireEnemy", 0.1f, 0.5f);
        random = Random.Range(0, 4);
        //Debug.Log(powerUpsManager.pooledBuffsColection[random]);
        pooledBuffs = manager.GetComponent<PowerUpsManager>().pooledBuffsColection;
    }

    void fireEnemy()
    {
        if (Random.Range(0f, 800f) < 1)
        {
            Vector3 enemyProjectileClone = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            Instantiate(enemyProjectile, enemyProjectileClone, transform.rotation);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "PlayerProjectile")
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
            if(Random.Range(0, probability) < 1)
            {
                Instantiate(pooledBuffs[random], gameObject.transform.position, transform.rotation);
            }
        }
    }
}
