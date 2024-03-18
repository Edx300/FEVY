using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    //[SerializeField] private UnityEvent<Vector2> _onMove = new(); //para llamar al movimiento

    //stats
    [SerializeField] public float _healthPlayer = 100;
    [SerializeField] public float _resistance = 100;
    [SerializeField] public float _speed = 3;
    [SerializeField] public float _power = 2;
    [SerializeField] public bool _weaponUpgrade = false;
    
    public bool _tired = false;

    private Rigidbody _rb; //rigid body del player
    public float _distanceToCheck = 2f;
    public bool _touchingGround;
    public RaycastHit hit;
    public Transform _rayCaster;
    public LayerMask terrainLayer; //layer del terreno

    public SpriteRenderer _PlayerSprite; // sprite del jugador

    void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {

        if(_tired)
        {
            tiredtoRun();
        }

        /*** * caminado
        //_rb.AddForce(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")), ForceMode.Force);
        //_onMove?.Invoke(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));
        *** */
        _rb.transform.Translate(new Vector3(Input.GetAxis("Horizontal") * Time.deltaTime * _speed, 0, Input.GetAxis("Vertical") * Time.deltaTime * _speed));

        //saltar
        if (Input.GetButtonDown("Jump") && _touchingGround )
        {
            _rb.AddForce( Vector3.up * 5, ForceMode.Impulse);
        }

        //Correr
        if (Input.GetMouseButton(1) && !_tired )
        {
            _speed = 6f;
            _resistance -= 7 * Time.deltaTime;
            
            if (_resistance <= 0)
            {
                _tired = true;

            }
        } else
        {
            _speed = 3f;
            _resistance += 5 * Time.deltaTime;
            _resistance = Mathf.Clamp(_resistance, 0, 100);
        }

       
    }

    private void FixedUpdate()
    {
        var ray = new Ray(_rayCaster.position, _rayCaster.up * -1);
        _touchingGround = Physics.Raycast(ray, _distanceToCheck, terrainLayer);
    }

    private void tiredtoRun()
    {
        _speed = 2f;
        _resistance += 5 * Time.deltaTime;
        _resistance = Mathf.Clamp(_resistance, 0, 100);
        if (_resistance >= 100 )
        {
            _tired = false;
        }
    }
}
