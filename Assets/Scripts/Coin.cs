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
            Destroy(gameObject);
            return;
        }

        if (other.gameObject.name != "Player")
        {
            return;
        }

        GameManager.inst.IncrementScore();
        GetComponent<AudioSource>().PlayOneShot(GetComponent<AudioSource>().clip);
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