using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject deathScreen;

    [SerializeField]
    private Canvas canvas;

    [SerializeField]
    private GameObject[] firstWave;

    [SerializeField]
    private GameObject[] secondWave;

    private void Start()
    {
        Cursor.visible = false;
        
    }

    public void GameOver()
    {
            Cursor.visible = true;
            deathScreen.gameObject.SetActive(true);
            canvas.planeDistance = 2f;
    }

    private void Update()
    {
        

    }

    private IEnumerable EnemiesAfterWave()
    {
        yield return null;
    }

}
