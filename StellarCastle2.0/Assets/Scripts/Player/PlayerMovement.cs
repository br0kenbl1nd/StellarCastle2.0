using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform graphics;
    public PlayerStats playerStats;

    public string habitatRqd = "MeteorGood";

    public float speed = 12f;

    public float rotationSpeed = 720f;

    [Header("Disable list when going off habitat")]
    public SpellRapidFire rapidFire;
    public SummonAttackUnit summonAttackUnit;

    Vector3 move;
    public Vector3 Move
    {
        get { return move; }
        private set { move = value; }
    }

    private void Update()
    {
        //front and back movement
        float z = Input.GetAxis("Vertical");
        float x = Input.GetAxis("Horizontal");

        //vectorize the input
        Move = transform.forward * z + transform.right * x;

        //apply movement
        transform.Translate(Move * speed * Time.deltaTime, Space.World);

        //detect the movement off habitat
        DisableAbilitiesOffHabitat();
        
    } //update

    //disabling abilities when the character moves off creep
    #region Disable abilities when off creep
    private void DisableAbilitiesOffHabitat()
    {
        //for the characters in the level phase some of these components maybe null

        if (playerStats.CurrentNode.habitat.CurrentHabitat.name != habitatRqd)
        {
            if (summonAttackUnit != null)
            {
                //disabling the player powerups
                if (summonAttackUnit.enabled == true)
                {
                    summonAttackUnit.enabled = false;
                }
            }

            if (rapidFire != null)
            {
                if (rapidFire.enabled == true)
                {
                    rapidFire.enabled = false;
                }
            }

        }
        else
        {
            if (summonAttackUnit != null)
            {
                //enable the player powerups when the player is in the habitat
                if (summonAttackUnit.enabled == false)
                {
                    summonAttackUnit.enabled = true;
                }
            }

            if (rapidFire != null)
            {
                if (rapidFire.enabled == false)
                {
                    rapidFire.enabled = true;
                }
            }
        }
    } //disable abilities off habitat
    #endregion

} //class
