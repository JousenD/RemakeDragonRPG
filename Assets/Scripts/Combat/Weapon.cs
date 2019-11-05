using System;
using RPG.Resources;
using UnityEngine;

namespace RPG.Combat
{
    [CreateAssetMenu(fileName = "Weapon", menuName = "Weapons/Make New Weapon", order = 0)]
    public class Weapon : ScriptableObject
    {
        [SerializeField] float weaponRange = 2f;
        [SerializeField] float weaponDamage = 5f;
        [SerializeField] AnimatorOverrideController animatorOverride = null;
        [SerializeField] GameObject weaponPrefab = null;
        [SerializeField] bool isRightHanded = true;
        [SerializeField] Projectile projectile = null;

        const string weaponName = "Weapon";

        public void Spawn(Transform rightHand, Transform leftHand, Animator animator)
        {
            DestroyOldWeapon(rightHand,leftHand);

            if(weaponPrefab !=null)
            {
                Transform handTransform = GetTransform(rightHand, leftHand);

                GameObject weapon = Instantiate(weaponPrefab, handTransform);
                weapon.name = weaponName;
            }
            if (animatorOverride !=null){
                animator.runtimeAnimatorController = animatorOverride;
            }   
        }

        private void DestroyOldWeapon(Transform rightHand, Transform leftHand)
        {
            Transform oldweapon = rightHand.Find(weaponName);
            if(oldweapon == null)
            {
                oldweapon = leftHand.Find(weaponName);
            }
            if (oldweapon == null){return;}

            oldweapon.name = "DESTROYING";
            Destroy(oldweapon.gameObject);
        }

        private Transform GetTransform(Transform rightHand, Transform leftHand)
        {
            Transform handTransform;
            if (isRightHanded)
            {
                handTransform = rightHand;
            }
            else
            {
                handTransform = leftHand;
            }

            return handTransform;
        }

        public bool HasProjectile()
        {
            return projectile !=null;
        }

        public void LaunchProjectile(Transform rightHand, Transform leftHand, Health target)
        {
            Projectile projectileInstance = Instantiate(projectile,GetTransform(rightHand,leftHand).position,Quaternion.identity);
            projectileInstance.SetTarget(target, weaponDamage);
        }

        public float GetRange(){
            return weaponRange;
        }
        public float GetDamage()
        {
            return weaponDamage;
        }

    }
}