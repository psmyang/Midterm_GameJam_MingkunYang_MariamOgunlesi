using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    [SerializeField] float turnSpeed = 90f;

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.GetComponent<Obstacle>() != null)
        {
            GetComponent<AudioSource>().Play();
            Destroy(gameObject);
            return;
        }

        if (other.gameObject.name != "AmyCharacter")
        {
            return;
        }

        GameManager.inst.IncrementScore();

        Destroy(gameObject);

    }

    private void Start()
    {

    }

    private void Update()
    {
        transform.Rotate(0, 0, turnSpeed * Time.deltaTime);
    }
}