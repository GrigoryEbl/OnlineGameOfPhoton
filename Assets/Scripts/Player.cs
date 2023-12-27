using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.Runtime.CompilerServices;
using System;

[RequireComponent(typeof(ConstantForce))]
[RequireComponent(typeof(Rigidbody))]
public class Player : Damagable, IPunObservable
{
    [SerializeField] private float _forwardForce;
    [SerializeField] private float _strafeForce;
    [SerializeField] private float _rollForce;
    [SerializeField] private float _sensitivityX;
    [SerializeField] private float _sensitivityY;
    [SerializeField] private Transform _weapon;
    [SerializeField] private float _damage;

    private ConstantForce _force;
    private Rigidbody _rigidbody;
    private PhotonView _photonView;
    private Vector3 _startPosition;

    private void Awake()
    {
        _health = 100;
        _force = GetComponent<ConstantForce>();
        _rigidbody = GetComponent<Rigidbody>();
        _photonView = GetComponent<PhotonView>();
    }

    public void SetStartPosition(Vector3 position)
    {
        _startPosition = position;
    }

    private void Update()
    {
        if (_photonView.IsMine)
        {
            _force.relativeForce = Vector3.forward * _forwardForce * Input.GetAxis("Vertical") +
                                   Vector3.right * _strafeForce * Input.GetAxis("Horizontal");

            _force.relativeTorque = Vector3.forward * _rollForce * Input.GetAxis("Roll")   +
                                    Vector3.right * _sensitivityY * Input.GetAxis("Mouse Y") +
                                    Vector3.up * _sensitivityX * Input.GetAxis("Mouse X");

            if (Input.GetMouseButtonDown(0))
                Shoot();
        }

    }

    public void Shoot()
    {
        if(Physics.Raycast(_weapon.position, _weapon.forward, out RaycastHit hit, 500f))
        {
            var victin = hit.rigidbody?.GetComponentInParent<Player>();

            if (victin != null)
            {
                victin.TakeDamage(_damage);
                _photonView.RPC("ApplyDamage", RpcTarget.Others,victin.gameObject.GetPhotonView().ViewID, _damage);
            }
        }
    }

    [PunRPC]
    public void ApplyDamage(int id, float damage)
    {
        PhotonView photonView = PhotonView.Find(id);
        if (photonView == null)
            return;

        var player = photonView.GetComponent<Player>();

        if (player == null)
            return;

        player.TakeDamage(_damage);
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {

    }

    public override void OnDie()
    {
        Respawn();
    }

    private void Respawn()
    {
        if (_photonView.IsMine)
        {
            _health = 100;
            transform.position = _startPosition;
        }
    }
}
