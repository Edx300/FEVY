using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;


//clase para probar el nuevo input system que vi  xd


public class NEWPlayerController : MonoBehaviour
{
    public PlayerData PlayerData;

    //stats
    [SerializeField] private int _speed;
    [SerializeField] public float _resistance = 100;
    [SerializeField] public float _resistanceloose = 5f;
    public bool _tired = false;


    //cosas que ocupo pero que no son stats
    [SerializeField] private Animator _anim;
    [SerializeField] private SpriteRenderer _playerSprite;

    //necesarias para saltar
    public float _distanceToCheck = 5f;
    public bool _touchingGround;
    public RaycastHit hit;
    public Transform _rayCaster;

    public LayerMask terrainLayer; //layer del terreno

    //llamo los controles que definí con el nuevo Input
    private PlayerControls playerControls;

    private Rigidbody rb;
    private Vector3 movement; 

    public HealthBarScript resistanceBar;



   // public Vector3 PlayerPos => movement; //para guardar

    private void Awake()
    {
        playerControls = new PlayerControls();
    }
    private void OnEnable()
    {
        playerControls.Enable();
    }

    void Start()
    {

        //movement = PlayerPrefs.GetString("PlayerPos", JsonUtility.ToJson());
        //ChangePos(movement);
        
        rb = GetComponent<Rigidbody>();
        resistanceBar.SetMaxHealth(_resistance);

    }

    void Update()
    {
        //Debug.Log("posicion:" + movement);
        float x = playerControls.Player.Movement.ReadValue<Vector2>().x;
        float z = playerControls.Player.Movement.ReadValue<Vector2>().y;

        Walk();

        //flip sprite
        if (x!=0 && x < 0)
        {
            _playerSprite.flipX = true;
        }
        //regresar a la normalidad
        if (x != 0 && x > 0)
        {
            _playerSprite.flipX = false;
        }
         //saltar
        if (Input.GetButtonDown("Jump") && _touchingGround)
        {
            Jump();
        }

        //correr
        if (Input.GetMouseButton(1) && !_tired)
        {
            Run();
        }
        else
        {
            _speed = 5;
            _resistance += 5 * Time.deltaTime;
            _resistance = Mathf.Clamp(_resistance, 0, 100);
            resistanceBar.SetHealth(_resistance);

        }
        
        //por si su resistencia es 0 
        if (_tired)
        {
            tiredtoRun();
        }

    }

    private void FixedUpdate()
    {
        rb.MovePosition(transform.position + movement * _speed * Time.fixedDeltaTime);

        var ray = new Ray(_rayCaster.position, _rayCaster.up * -1);
        _touchingGround = Physics.Raycast(ray, _distanceToCheck, terrainLayer);//para revisar si toca el suelo
    }

    private void Walk()
    {
        float x = playerControls.Player.Movement.ReadValue<Vector2>().x;
        float z = playerControls.Player.Movement.ReadValue<Vector2>().y;

        movement = new Vector3(x, 0, z).normalized;

        _anim.SetBool("IsWalk", movement != Vector3.zero); //activa el bool de caminado cuando el vector no tiene 0 como valor
    }

    private void Jump()
    {
        rb.AddForce(Vector3.up * 7, ForceMode.Impulse);
        //_anim.SetBool("IsWalk", movement != Vector3.zero); //animacion para saltar
    }


    private void Run()
    {
        _speed = 7;
        _resistance -= _resistanceloose * Time.deltaTime;
        resistanceBar.SetHealth(_resistance);

        if (_resistance <= 0)
        {
            _tired = true;

        }
    }

    private void tiredtoRun()
    {
        _speed = 3;
        _resistance += 7 * Time.deltaTime;
        _resistance = Mathf.Clamp(_resistance, 0, 100);
        resistanceBar.SetHealth(_resistance);
        if (_resistance >= 100)
        {
            _tired = false;
        }
    }
    
    
    /* Cosas que no sirvieron del guardado
    public void ChangePos(Vector3 val)
    {
        movement = val;
        Debug.Log(val);
        //Debug.Log(val);

    }

    public void DefaultPos(Vector3 val)
    {
        movement = _playerSprite.transform.position;
    }
    */
}
