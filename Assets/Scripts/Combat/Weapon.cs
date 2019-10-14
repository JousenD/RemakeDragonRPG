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

        public void Spawn(Transform handTransform, Animator animator)
        {
            if(weaponPrefab !=null){
                Instantiate(weaponPrefab, handTransform);
            }
            if(animatorOverride !=null){
                animator.runtimeAnimatorController = animatorOverride;
            }   
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