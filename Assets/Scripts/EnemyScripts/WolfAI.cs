using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfAI : MonoBehaviour
{
    [SerializeField] private bool isEater;
    [SerializeField] private int attackDamage = 5;
    [SerializeField] private float moveSpeed = 1f;   
    [SerializeField] private float attacTimeTreshold = 1f;
    [SerializeField] private float eatTimeTreshold = 2f;
    [SerializeField] private LayerMask bushMask;

    private bool isMoving;
    public bool IsMoving { get { return isMoving; } }
    private bool left;
    public bool Left { get { return left; } }
    private bool killingBush;
    private bool isAttacking;
    private float attackTimer;
    private float eatTimer;
    private Artifact artifact;
    private BushFruits bushFruitsTarget;


    private void Start()
    {
        if(isEater)
        {
            SearchForTarget();
            killingBush = false;
        }
        else
        {
            isAttacking = false;
        }
        

        try
        {
            artifact = GameObject.FindWithTag("Artifact").GetComponent<Artifact>();
        }
        catch(NullReferenceException nl)
        {
            artifact = null;
        }
    }

    private void Update()
    {
        if (!artifact) return;

        if(isEater)
        {
            if(bushFruitsTarget && bushFruitsTarget.enabled && bushFruitsTarget.HasFruit && !killingBush)
            {
                if(Vector2.Distance(transform.position, bushFruitsTarget.transform.position) > 0.5f)
                {
                    float step = moveSpeed * Time.deltaTime;
                    
                    transform.position = Vector2.MoveTowards(transform.position, bushFruitsTarget.transform.position, step);
                    isMoving = true;
                }
                else
                {
                    isMoving = false;
                    killingBush = true;
                    bushFruitsTarget.HarvestFruits();
                    eatTimer = Time.time + eatTimeTreshold;
                }
            }
            else if(killingBush)
            {
                if(Time.time > eatTimer)
                {
                    bushFruitsTarget.EatBushFruits();
                    killingBush = false;
                    SearchForTarget();
                }
            }
            else
            {
                SearchForTarget();
            }


            if (bushFruitsTarget)
            {
                if (bushFruitsTarget.transform.position.x < transform.position.x) left = true;
                else left = false;
            }

            if (!bushFruitsTarget) SearchForTarget();
        }
        else
        {
            if(Vector2.Distance(transform.position, artifact.transform.position) > 0.1f)
            {
                float step = moveSpeed * Time.deltaTime;
                transform.position = Vector2.MoveTowards(transform.position, artifact.transform.position, step);
                isMoving = true;
            }
            else if(!isAttacking)
            {
                isAttacking = true;
                attackTimer = Time.time + attacTimeTreshold;
                isMoving = false;
            }

            if(isAttacking)
            {
                if(Time.time > attackTimer)
                {
                    Attack();
                    attackTimer = Time.time + attacTimeTreshold;
                }
            }

            if (artifact.transform.position.x < transform.position.x) left = true;
            else left = false;
        }
    }

    private void SearchForTarget()
    {
        bushFruitsTarget = null;

        Collider2D[] hits;

        for(int i = 1; i < 50; i++)
        {
            hits = Physics2D.OverlapCircleAll(transform.position, Mathf.Exp(i), bushMask);

            foreach(Collider2D hit in hits)
            {
                if(hit && (hit.gameObject.GetComponent<BushFruits>().HasFruit && hit.gameObject.GetComponent<BushFruits>().enabled))
                {
                    bushFruitsTarget = hit.gameObject.GetComponent<BushFruits>();
                    break;
                }
            }

            if(bushFruitsTarget)
            {
                break;
            }

        }
    }

    private void Attack()
    {
        artifact.TakeDamage(attackDamage);
    }
}