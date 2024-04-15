using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Cinemachine;

public class AIBasics : MonoBehaviour
{

    public NavMeshAgent agent;
    public Transform player;
    public LayerMask LTerrain, LPlayer;


    //animator sprite
    //[SerializeField] private Animator _anim;
    [SerializeField] private SpriteRenderer _enemySprite;
    [SerializeField] private GameObject enemy;


    //Walking stuff
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attacking stuff
    public float timeBetweenAttacks;
    bool alreadyAttacked;

    //States for the enemy
    public float sightRange, attackRange;
    public bool playerInSight, playerInAttackRange;



    void Start()
    {
        enemy = GameObject.Find("Main Camera");
        player = GameObject.Find("Player").transform; //definir que es el player y su posición
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        //Look At

        _enemySprite.transform.LookAt(enemy.transform);

        //REVISAR SI EL JUGADOR ESTA CERCA
        playerInSight = Physics.CheckSphere(transform.position, sightRange, LPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, LPlayer);

        if (!playerInSight && !playerInAttackRange ) 
        {
            Walking();
        }

        if (playerInSight && !playerInAttackRange)
        {
            Chasing();
        }

        if (playerInSight && playerInAttackRange)
        {
            Attacking();
        }

    }

    private void Walking()
    {
        if(!walkPointSet) 
        {
            SearchWalkPoint();
        }

        if (walkPointSet)
        {
            agent.SetDestination(walkPoint);
        }

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //llega a su destino
        if(distanceToWalkPoint.magnitude < 1f)
        {
            walkPointSet = false;
        }

    }

    private void SearchWalkPoint() 
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3 (transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);


        if(Physics.Raycast(walkPoint, -transform.up, 2f, LTerrain))
        {
            walkPointSet = true;
        }

    }

    private void Chasing()
    {
        agent.SetDestination(player.position);
    }
    private void Attacking()
    {
        agent.SetDestination (transform.position);

        transform.LookAt(player);

        if(!alreadyAttacked)
        {
 
            Debug.Log("Ataque de enemigo!");
           

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }

    }
    
    private void ResetAttack()
    {
        alreadyAttacked = false;
    }


    private void Death()
    {
        Destroy(gameObject);
    }

}
