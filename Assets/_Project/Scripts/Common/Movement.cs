using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField] public float _speed = 1f;


    public void Move(Vector2 input)
    {

        transform.Translate(input.x * Time.deltaTime * _speed, 0, input.y * Time.deltaTime * _speed);

    }

}
