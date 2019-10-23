using System;
using System.Collections;
using System.Collections.Generic;
using RPG.Core;
using UnityEngine;

namespace RPG.Combat
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] float speed = 1f;
        
        Health target = null;
        
        float damage =0;
        bool isHoming = false;

        // Update is called once per frame

        void Start()
        {
            if (target == null) return;
            transform.LookAt(GetAimPosition());
        }
        void Update()
        {
            if(target == null) return;

            if(isHoming && !target.IsDead())
            {
                transform.LookAt(GetAimPosition());
            }
            
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }

        public void SetTarget(Health target, float damage)
        {
            this.target = target;
            this.damage = damage;
        }

        private void OnTriggerEnter(Collider other) {
            if(other.gameObject.GetComponent<Health>() != target) return;
            if(target.IsDead()) return;
            target.TakeDamage(damage);
            Destroy(gameObject);
        }

        private Vector3 GetAimPosition()
        {
            CapsuleCollider targetCapsule = target.GetComponent<CapsuleCollider>();
            if (targetCapsule == null)
            {
                return target.transform.position;
            }
            return target.transform.position + Vector3.up * targetCapsule.height/2;
        }
    }

}
