using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    [SerializeField] private Bomb _bomb;
    [SerializeField] private Animator _animator;
    private bool _tookBomb = false;


    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.GetComponent<ClickCollider>() && Input.GetMouseButton(0))
            {
                if (Vector2.Distance(transform.position, _bomb.transform.position) <= 1.5f && !_tookBomb)
                {
                    //_animator.SetBool("Taking", true);
                    _tookBomb = true;
                    //_animator.SetBool("Taking", false);
                    _bomb.MoveToPlayer();
                }
            }
        }

        if(_tookBomb && Input.GetMouseButton(1))
        {
            _bomb.RemoveFromPlayer();
        }

    }
}
