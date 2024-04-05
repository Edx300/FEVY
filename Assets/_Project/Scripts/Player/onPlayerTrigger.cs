using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnPlayerTrigger : MonoBehaviour
{


    [SerializeField] private UnityEvent _onEnemyDetected = new();

    public float cooldown;
    bool alreadyAttacked;

   
    private void OnTriggerEnter(Collider other)
    {

        switch (other.tag)
        {
            case "Enemy":
                if (!alreadyAttacked)
                {
                    alreadyAttacked = true;
                    _onEnemyDetected?.Invoke();


                    Invoke(nameof(ResetAttack), cooldown);
                }
                
            break;

            case "BULLETS":

                if (!alreadyAttacked)
                {
                    alreadyAttacked = true;
                    _onEnemyDetected?.Invoke();


                    Invoke(nameof(ResetAttack), cooldown);
                }
            break;

        }
    }



    private void ResetAttack()
    {
        alreadyAttacked = false;
    }
}
