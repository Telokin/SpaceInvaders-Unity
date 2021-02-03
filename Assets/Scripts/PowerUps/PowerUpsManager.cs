using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PowerUpsManager : MonoBehaviour
{
    [SerializeField]
    private GameObject forcefield;

    [SerializeField]
    private Image explosion;

    private PlayerController playerController;

    [SerializeField]
    private GameObject[] enemies;

    [SerializeField]
    private int random;

    private bool theShield;
    private bool theMultiShot;
    private bool theNuke;
    private bool theRepair;
    private bool powerUpActive;
    private float powerUpLenghtCounter;
    private int charges;
    public bool isImmortal = false;

    private EnemyStats enemyStats;

    [SerializeField]
    private GameObject[] buffs;

    public List<GameObject> pooledBuffsColection;
    
    // Start is called before the first frame update

    private void Start()
    {
        pooledBuffsColection = new List<GameObject>();
        pooledBuffsColection.Add(buffs[0]);
        pooledBuffsColection.Add(buffs[1]);
        pooledBuffsColection.Add(buffs[2]);
        pooledBuffsColection.Add(buffs[3]);
        pooledBuffsColection.Add(buffs[4]);
    }
    // Update is called once per frame
    void Update()
    {
        if (powerUpActive)
        {
            powerUpLenghtCounter -= Time.deltaTime;
            if(powerUpLenghtCounter <= 0)
            {

                powerUpActive = false;
            }
        }
    }


    public void ActivatePowerUp(bool shield, bool multiShot, bool nuke, bool repair, float time)
    {
        theShield = shield;
        theMultiShot = multiShot;
        theNuke = nuke;
        theRepair = repair;
        powerUpLenghtCounter = time;
        powerUpActive = true;

        if (shield)
        {
            forcefield.gameObject.SetActive(true);
            isImmortal = true;
        }
        else
        {
            forcefield.gameObject.SetActive(false);
            isImmortal = false;
        }

        if (repair)
        {
            playerController.health = 3;
        }

        if (multiShot)
        {

        }

        if (nuke)
        {
            if (Input.GetKey("r"))
            {

                Destroy(enemyStats.gameObject);
            }
        }

    }


}
