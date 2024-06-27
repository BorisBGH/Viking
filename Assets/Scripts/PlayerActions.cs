using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    [SerializeField] private Bomb _bomb;
    [SerializeField] private Animator _animator;
    private bool _canTakeBomb = true;


    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Debug.Log(Vector2.Distance(transform.position, _bomb.transform.position));
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.GetComponent<ClickCollider>() && Input.GetMouseButton(0))
            {
                if (Vector2.Distance(transform.position, _bomb.transform.position) <= 1f && _canTakeBomb)
                {
                    _animator.SetBool("Taking", true);
                    _canTakeBomb = false;   
                    _bomb.MoveToPlayer();
                }
            }
        }

    }
}
