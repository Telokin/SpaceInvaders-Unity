using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{

    [SerializeField]
    private bool theShield;

    [SerializeField]
    private bool theMultiShot;

    [SerializeField]
    private bool theNuke;

    [SerializeField]
    private bool theRepair;

    [SerializeField]
    private float powerUpLenght;

    [SerializeField]
    private float powerUpSpeed;

    private PowerUpsManager thePowerUpsManager;


    // Start is called before the first frame update
    void Start()
    {
        thePowerUpsManager = FindObjectOfType<PowerUpsManager>();

    }

    void Update()
    {

        transform.Translate(new Vector3(0, powerUpSpeed * (-Time.deltaTime), 0));
        if (gameObject.name == "ForcefieldBuff(Clone)")
        {
            Destroy(gameObject, 3);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Player")
        {
            thePowerUpsManager.ActivatePowerUp(theShield, theMultiShot, theNuke, theRepair, powerUpLenght);
            Destroy(gameObject);
        }

        }
}
