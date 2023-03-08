using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 5f;

    private const string MOVMENT_AXIS_X = "Horizontal", MOVMENT_AXIS_Y = "Vertical";

    private float harvestTimer;
    private bool isHarvesting;
    public bool IsHarvesting { get { return isHarvesting; } }
    private Vector2 moveVector;
    private SpriteRenderer spriteRenderer;
    new private Rigidbody2D rigidbody2D;
    private GameObject artifact;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        if(isHarvesting)
        {
            rigidbody2D.velocity = Vector2.zero;
        }
        else
        {
            moveVector = new Vector2(Input.GetAxis(MOVMENT_AXIS_X), Input.GetAxis(MOVMENT_AXIS_Y)).normalized;
            rigidbody2D.velocity = moveVector * movementSpeed;

        }
    }

    private void Update()
    {

        if (Time.time > harvestTimer) isHarvesting = false;

        FlipSprite();
    }

    private void FlipSprite()
    {
        if(Input.GetAxisRaw(MOVMENT_AXIS_X) == 1)
        {
            spriteRenderer.flipX = false;
        }
        else if(Input.GetAxisRaw(MOVMENT_AXIS_X) == -1)
        {
            spriteRenderer.flipX = true;
        }
    }

    public void HarvestStopMovement(float time)
    {
        isHarvesting = true;
        harvestTimer = Time.time + time;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "MapEnd")
        {
            moveVector = -moveVector;
        }
    }
}
