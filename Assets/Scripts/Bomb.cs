using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Bomb : MonoBehaviour
{
    [SerializeField] private Effector2D _effector;
    [SerializeField] private GameObject _explosion;
    [SerializeField] private GameObject _bombSprite;
    [SerializeField] private Transform _placeOnPlayer;
    [SerializeField] private float _timeToExplode = 2f;
    private Body _body;


    public void MoveToPlayer()
    {
        transform.position = _placeOnPlayer.transform.position;
        transform.parent = _placeOnPlayer.transform;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        StartCoroutine(ExplosionProcess());
        if (other.GetComponentInParent<Body>() is Body body)
        {
            _body = body;

        }
    }

    private IEnumerator ExplosionProcess()
    {
        yield return new WaitForSeconds(_timeToExplode);
        Explode();
        if (_body)
        {
            _body.MakeDynamic();
            _body.GetComponent<Animator>().enabled = false;
            _body.GetComponentInParent<PlayerMove>().enabled = false;
        }

    }

    private void Explode()
    {
        _effector.enabled = true;
        _explosion.SetActive(true);
        _bombSprite.SetActive(false);
        Invoke(nameof(Deactivate), 1f);
    }

    private void Deactivate()
    {
        //_effector.enabled = false;
        //_explosion.SetActive(false);
        //_bombSprite.SetActive(false);
        StopAllCoroutines();
        Destroy(gameObject);
    }
}
