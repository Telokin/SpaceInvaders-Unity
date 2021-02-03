using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private GameObject swarm;

    [HideInInspector]
    public float speed = 0;
    private bool isMovingRight = true;


    #region Dimensions
    private Vector2 screenBounds;
    private float objectWidth;
    #endregion

    void Start()
    {
        //Get camera resolution
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        // Get width of the swarm
        objectWidth = transform.GetComponent<BoxCollider2D>().bounds.size.x / 2;

        //Speed movement
        speed = 0.1f;


    }


    void Update()
    {
        //Check is swarm in bounds
        if (swarm.transform.position.x >= screenBounds.x - objectWidth && isMovingRight) isMovingRight = false;
        else if (swarm.transform.position.x <= -screenBounds.x + objectWidth && !isMovingRight) isMovingRight = true;

        //Right
        if (isMovingRight)
        {
            Vector3 newPosition = new Vector3(swarm.transform.position.x + speed, swarm.transform.position.y, swarm.transform.position.z);
            swarm.transform.position = newPosition;
        }

        //Change vector
        //Left
        else
        {
            Vector3 newPosition = new Vector3(swarm.transform.position.x - speed, swarm.transform.position.y, swarm.transform.position.z);
            swarm.transform.position = newPosition;
        }
        
    }

}
