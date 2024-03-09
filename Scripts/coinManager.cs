using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinManager : MonoBehaviour
{
    public float coinRotationSpeed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, 0f, coinRotationSpeed);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            PlayerManager.numberOfCoins ++;
            PlayerPrefs.SetInt("NumberOfCoins",PlayerManager.numberOfCoins);
            Destroy(gameObject);
            FindObjectOfType<AudioManager>().PlaySound("Coins");

        }
    }
}
