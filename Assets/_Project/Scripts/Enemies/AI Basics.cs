using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Cinemachine;

public class AIBasics : MonoBehaviour
{

    [SerializeField] private NavMeshAgent agent;
    public Transform player;
    public LayerMask LTerrain, LPlayer;
    [SerializeField] private Animator animator;


    //animator sprite
    //[SerializeField] private Animator _anim;
    [SerializeField] private SpriteRenderer _enemySprite;
    [SerializeField] private GameObject camara;


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

    private float randomX, randomZ;

    void Start()
    {
        camara = GameObject.Find("Main Camera");
        player = GameObject.Find("Player").transform; //definir que es el player y su posición
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        //Look At
        _enemySprite.transform.LookAt(camara.transform);

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
            animator.SetTrigger("isattack");
            Attacking();
        }

    }

    private void Walking()
    {
        if(!walkPointSet) 
        {
            SearchWalkPoint();
            animator.SetTrigger("isWalk");
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
         randomZ = Random.Range(-walkPointRange, walkPointRange);
         randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3 (transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
        
        CheckFlip();

        if (Physics.Raycast(walkPoint, -transform.up, 2f, LTerrain))
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


    private void CheckFlip()
    {
        if (randomX != 0 && randomX > 0)
        {
            _enemySprite.flipX = true;
        }
        //regresar a la normalidad
        if (randomX != 0 && randomX < 0)
        {
            _enemySprite.flipX = false;
        }
    }

}
