using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private const string GIFT = "Gift";
    private const string DELIVERY = "DeliveryPlace";

    private Vector2 inputVector = new Vector2();
    [SerializeField] private int speed = 5;
    [SerializeField] private int angle = 300;
    [SerializeField] private Transform expl;
    [SerializeField] private Transform holdPoint;
    private bool isCarying = false;
    private bool isDriving = false;

    // Update is called once per frame
    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
      //  Vector2 inputVector = new Vector2();
        inputVector.x = Input.GetAxis("Horizontal");
        inputVector.y = Input.GetAxis("Vertical");

        if (inputVector.y != 0)
        {
            isDriving = true;

            if (inputVector.x != 0)
            {
                transform.eulerAngles = transform.eulerAngles + new Vector3(0, 0, -angle) * inputVector.x * inputVector.y * Time.deltaTime;
                
            }

            transform.Translate(new Vector3(-speed,0,0) * inputVector.y * Time.deltaTime, Space.Self);
        }
        else
        {
            isDriving = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            Instantiate(expl.gameObject, new Vector3(transform.position.x, transform.position.y, 0), transform.rotation);
            Destroy(gameObject);
            GameManagerScript.Instance.PlayerDeath();
        }
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == GIFT && !isCarying)
        {
            isCarying = true;
            collider.transform.SetParent(transform);
            collider.transform.position = holdPoint.position;
            GameManagerScript.Instance.SpawnNewPlace();
        }

        if (collider.gameObject.tag == DELIVERY && isCarying)
        {
            isCarying = false;
            Destroy(transform.GetChild(2).gameObject);
            Destroy(collider.gameObject);
            GameManagerScript.Instance.SpawnNewGift();
            GameManagerScript.Instance.ScoreIncreased();
        }
    }

    public bool IsDriving()
    {
        return isDriving;
    }

    public bool IsCarying()
    {
        return isCarying;
    }
}
