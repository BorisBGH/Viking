using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class Bomb : MonoBehaviour
{
    [SerializeField] private Effector2D _effector;
    [SerializeField] private GameObject _explosion;
    [SerializeField] private GameObject _bombSprite;
    [SerializeField] private Transform _placeOnPlayer;
    [SerializeField] private float _timeToExplode = 2f;
    [SerializeField] private float _damageDistnace = 2f;
    [SerializeField] private Timer _timer;

    private Body _body;

    private void Start()
    {
        
    }

    public void MoveToPlayer()
    {
        transform.position = _placeOnPlayer.transform.position;
        transform.parent = _placeOnPlayer.transform;

    }

    public void RemoveFromPlayer()
    {
        transform.parent = null;
        transform.position = new Vector2(transform.position.x, -2.627f);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
      

        if (other.GetComponentInParent<Body>() is Body body)
        {
            _body = body;
            _timer.SetValue(_timeToExplode);
            _timer.gameObject.SetActive(true);
            StartCoroutine(ExplosionProcess());
        }
    }

    private IEnumerator ExplosionProcess()
    {

        yield return new WaitForSeconds(_timeToExplode);
        Explode();
        if (_body && Vector2.Distance(transform.position, _body.transform.position) < _damageDistnace)
        {
            _body.MakeDynamic();
            _body.GetComponent<Animator>().enabled = false;
            _body.GetComponentInParent<PlayerMove>().enabled = false;
            Camera.main.transform.parent = null;
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
        StopAllCoroutines();
        Destroy(gameObject);
    }
}
