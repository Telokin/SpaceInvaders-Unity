using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Transform spaceShip;

    [HideInInspector]
    public float speed = 0;

    [SerializeField]
    private float projectileSpeed = 0.5f;

    [SerializeField]
    private GameObject projectile;

    private Vector3 projectileClone;

    private PowerUpsManager powerUpsManager;

    private GameObject clone;

    [HideInInspector]
    public int health;
    #region Dimensions
    private Vector3 mousePosition;
    private Vector2 screenBounds;
    private float objectWidth;
    private float objectHeight;

    #endregion

    void Start()
    {
        //Get camera resolution
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        // Get width of the ship
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;

        //Get height of the ship
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;

        speed = 0.1f;

        //Fire
        InvokeRepeating("lvlOneProjectiles", 0.1f, 0.5f);



    }


    void Update()
    {
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        //Move ship to mouse position
        spaceShip.transform.position = Vector2.Lerp(transform.position, mousePosition, speed);

        //Bound ship to camera resolution
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -screenBounds.x + objectWidth, screenBounds.x - objectWidth),
            Mathf.Clamp(transform.position.y, -screenBounds.y + objectHeight, screenBounds.y - objectHeight), transform.position.z);
    }

    void lvlOneProjectiles()
    {
        projectileClone = new Vector3(spaceShip.transform.position.x, spaceShip.transform.position.y, spaceShip.transform.position.z);
        clone = Instantiate(projectile, projectileClone, spaceShip.transform.rotation);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemyProjectile")
        {
            //if (powerUpsManager.isImmortal == true)
            //{
            //    return;
            //}
            //else
            //{
                Destroy(collision.gameObject);
                health--;
                if (health == 0)
                {
                    FindObjectOfType<GameManager>().GameOver();
                }
            //}
            
        }
    }
}
