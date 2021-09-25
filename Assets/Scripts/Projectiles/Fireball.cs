using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour{
    private int _dano = 1;
    [SerializeField] private float _speed;

    void Update(){
        transform.Translate(0,0,_speed*Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other){

        var player = other.GetComponent<PlayerCharacter>();

        var target = other.GetComponent<ReactiveTarget>();

        if (player != null){player.Hurt(_dano);}

        if (target != null){target.ReactToHit(_dano);}

        Destroy(this.gameObject);
    }
}
