using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class EnemyController2 : MonoBehaviour
{
    public int maxEnergy;
    public int damage;
    public float moveSpeed;

    public GameObject p1;
    public GameObject p2;
    public GameObject ll;
    public GameObject lr;

    public bool direcao;
    public bool perseguicao;

    private int _currentEnergy;

    private Animator _animator;

    private bool _isAlive;

    private Collider2D _collider2D;
    
    private AudioSource _audioSource;
    
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _collider2D = GetComponent<Collider2D>();
        _audioSource = GetComponent<AudioSource>();

        _isAlive = true;

        _currentEnergy = maxEnergy;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isAlive)
        {
            Patrulha();
        }
}

    private void Patrulha()
    {
        if (direcao)
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }
    }

    private void Perseguicao()
    {
        
    }

    public void TakeEnergy(int damage)
    {
        _currentEnergy -= damage;

        if (_currentEnergy <= 0)
        {
            //TODO: Gerenciar morte  do inimigo
            _currentEnergy = 0;
            //Destroy(gameObject);
            _isAlive = false;
            _collider2D.enabled = false;
            _animator.Play("Dead");
            _audioSource.Play();
        }

        if (_currentEnergy > maxEnergy) _currentEnergy = maxEnergy;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("P1"))
        {
            direcao = !direcao;
        }
        if (col.gameObject.CompareTag("P2"))
        {
            direcao = !direcao;
        }
        if (col.gameObject.CompareTag("Lr"))
        {
            perseguicao = false;
        }
        if (col.gameObject.CompareTag("Ll"))
        {
            perseguicao = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            col.gameObject.GetComponent<PlayerController>().TakeDamage(damage);
        }
    }
    
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerController>().TakeDamage(damage);
        }
    }
}
