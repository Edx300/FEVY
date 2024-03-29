using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIBasics : MonoBehaviour
{
    public float _health = 15;
    public float _damageGiven;

    PlayerController playerController; // pa agarrar la vida
    [SerializeField] GameObject PlayerHealth;

    public NavMeshAgent agent;
    public Transform player;
    public LayerMask LTerrain, LPlayer;

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

    private void Awake()
    {
        playerController = PlayerHealth.GetComponent<PlayerController>();
    }

    void Start()
    {
        player = GameObject.Find("player").transform; //definir que es el player y su posición
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
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

        if (_health <= 0)
        {
            Death();        }

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
            //inserta codigo de ataque aqui lol
            Debug.Log("Ataque de enemigo!");
            playerController._health = playerController._health - _damageGiven; 
           

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
