using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeedHorizontal = 10f;
    [SerializeField] float jumpSpeed = 4f;
    float padding = 0.5f;
    [SerializeField] GameObject jumpVFX;

    float xMin;
    float xMax;
    float yMin;
    float yMax;

    [SerializeField] private int fuel = 100;

    void Start()
    {
        SetUpMoveBoundaries();
    }


    void Update()
    {
       Move();
       Jump();
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, jumpSpeed);
            Fart();
        }
    }

    public int GetFuel()
    {
        return fuel;
    }

    public void AddFuel(int fuel)
    {
        this.fuel += fuel;
    }

    public void RemoveFuel(int fuel)
    {
        this.fuel -= fuel;
    }
    private void Die()
    {
        FindObjectOfType<SceneLoader>().LoadGameOverScene();
        Destroy(gameObject);
    }
    private void Fart()
    {
        GameObject explosion = Instantiate(jumpVFX, transform.position, transform.rotation);
        explosion.transform.parent = transform;
        explosion.transform.position = new Vector2(transform.position.x, transform.position.y - 1f);

        Destroy(explosion, 0.7f);
    }

    private void Move()
    {
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeedHorizontal;
        var newXPos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);
        var newYPos = Mathf.Clamp(transform.position.y, yMin, yMax);
        transform.position = new Vector2(newXPos, newYPos);
        //transform.Translate(Input.acceleration.x, 0, 0);
        //var newXPos = Mathf.Clamp(transform.position.x, xMin, xMax);
        //var newYPos = Mathf.Clamp(transform.position.y, yMin, yMax);
        //transform.position = new Vector2(newXPos, newYPos);
    }

    private void SetUpMoveBoundaries()
    {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, -0.4f, 0)).y + padding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 0.4f, 0)).y - padding;
    }
}
