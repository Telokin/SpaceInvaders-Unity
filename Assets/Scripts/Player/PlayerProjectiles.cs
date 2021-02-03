using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectiles : MonoBehaviour
{
    [SerializeField]
    private float projectileSpeed;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, projectileSpeed * Time.deltaTime, 0));

        if (gameObject.name == "PlayerProjectile(Clone)")
        {
            Destroy(gameObject, 3);
        }
    }
}
