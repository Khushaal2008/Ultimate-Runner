using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCar : MonoBehaviour
{
    public Rigidbody carRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        carRigidbody = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!PlayerManager.isGameStarted)
            return;

            carRigidbody.AddForce(0,0,-10f);
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            PlayerManager.gameOver = true;
            Time.timeScale = 0;
        }
        
    }
}
