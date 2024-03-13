using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private UnityEvent<Vector2> _onMove = new(); //para llamar al movimiento

    [SerializeField] public float _GroundDistance = 0; //para separarlo del suelo

    [SerializeField] LayerMask terrainLayer; //layer del terreno

    public Rigidbody _PlayerRB; //rigid body del player

    public SpriteRenderer _PlayerSprite; // sprite del jugador

    void Start()
    {
        _PlayerRB = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Vector3 castPos = transform.position;
        castPos.y += 1;

        if (Physics.Raycast(castPos,-transform.up, out hit, Mathf.Infinity, terrainLayer)) 
        {
            if(hit.collider != null)
            {

                Vector3 movePos = transform.position;
                movePos.y = hit.point.y + _GroundDistance;
                transform.position = movePos;

            }
        }

        _onMove?.Invoke(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));

        


    }
}
