using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttackArea : MonoBehaviour
{
    public float damage = 3;
    public Collider2D swordCollider;
    private Vector2 rightAttackOffset;
    private Vector2 upAttackOffset;
    private Vector2 downAttackOffset;

    private void Start(){
        rightAttackOffset = transform.localPosition;
        upAttackOffset = new Vector2(0, rightAttackOffset.y);
        downAttackOffset = new Vector2(0, -rightAttackOffset.y);
    }

    public void AttackRight(){
        swordCollider.enabled = true;
        transform.localPosition = rightAttackOffset;
        Debug.Log("AttackRight triggered");
    }

    public void AttackLeft(){
        swordCollider.enabled = true;
        transform.localPosition = new Vector3(rightAttackOffset.x * -1, rightAttackOffset.y);
        Debug.Log("AttackLeft triggered");
    }

    public void AttackUp(){
        swordCollider.enabled = true;
        transform.localPosition = upAttackOffset;
        Debug.Log("AttackUp triggered");
    }

    public void AttackDown(){
        swordCollider.enabled = true;
        transform.localPosition = downAttackOffset;
        Debug.Log("AttackDown triggered");
    }

    public void StopAttack(){
        swordCollider.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("SwordAttackArea OnTriggerEnter2D triggered");

        if (other.CompareTag("Enemy")){
            Enemy enemy = other.GetComponent<Enemy>();

            if (enemy != null){
                Debug.Log("Damaging enemy");
                enemy.Health -= damage;
            }
        }
    }
}