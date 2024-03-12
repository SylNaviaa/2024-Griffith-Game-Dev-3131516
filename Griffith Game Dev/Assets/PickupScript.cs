using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PickupScript : MonoBehaviour
{

    public float scoreValue;
    public GameManagerScript gameManager;
    public GameObject collectedEffect;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<GameManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameManager.AddScore(scoreValue);
            //Instantiate(collectedEffect, transform.position.);
            Destroy(gameObject);
        }
    }

}
