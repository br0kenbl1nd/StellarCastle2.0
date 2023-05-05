using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    [SerializeField]
    EnemyMovement enemyMovement;

    [SerializeField]
    Animator enemyAnimator;

    [SerializeField]
    MeleeAttack meleeAttack;

    [SerializeField]
    RangedAttack rangedAttack;

    private void Update()
    {
        if(enemyMovement.CanMove == true)
        {
            enemyAnimator.SetBool("isWalking", true);
        }
        else
        {
            enemyAnimator.SetBool("isWalking", false);
        }

        if (meleeAttack != null)
        {
            if (meleeAttack.CanAttack == true)
            {
                enemyAnimator.SetBool("isAttacking", true);
            }
            else
            {
                enemyAnimator.SetBool("isAttacking", false);
            }
        }
        
        if(rangedAttack != null)
        {
            if (rangedAttack.CanAttack == true)
            {
                enemyAnimator.SetBool("isAttacking", true);
            }
            else
            {
                enemyAnimator.SetBool("isAttacking", false);
            }
        }

    } //update


} //class
