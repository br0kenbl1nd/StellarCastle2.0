using UnityEngine;

[RequireComponent(typeof(UnitStats))]
public class UnitBuffs : MonoBehaviour
{
    UnitStats unitStats;

    //attack speed buff
    private float ASBuffDuration = 0f;
    private float ASBuffCounter = 0f;
    private bool isASBuffed = false;

    //movement speed buff
    private float MSBuffDuration = 0f;
    private float MSBuffCounter = 0f;
    private bool isMSBuffed = false;

    private void Awake()
    {
        unitStats = GetComponent<UnitStats>();
    } //start

    //contains the counter for different buffs and debuffs which will refresh the buffs/debuffs
    #region Update
    private void Update()
    {
        // check if there is AS buff active
        if(isASBuffed == true)
        {
            ASBuffCounter -= Time.deltaTime;

            if(ASBuffCounter <= 0f)
            {
                RefreshAttackSpeedBuff();
            }
        }

        // chekc if there is MS buff active
        if(isMSBuffed == true)
        {
            MSBuffCounter -= Time.deltaTime;

            if(MSBuffCounter <= 0f)
            {
                RefreshMovementSpeedBuff();
            }
        }


    } //update
    #endregion

    //Contains the AS buff function and refresh function
    #region Attack speed buff
    public void AttackSpeedBuff(float amount, float duration)
    {
        //check if there is a buff already active
        if (isASBuffed == false)
        {
            //modify the AS of the unit
            unitStats.AttackSpeed = (1 + (amount / 100f)) * unitStats.AttackSpeed;

            //get the buff details and enter into local variables
            ASBuffDuration = duration;
            isASBuffed = true;
            ASBuffCounter = ASBuffDuration;

            Debug.Log("Hi");
        }
        
    } //attack speed buff

    void RefreshAttackSpeedBuff()
    {
        if(isASBuffed == true)
        {
            //refresh attack speed of the unit
            unitStats.AttackSpeed = unitStats.StartAttackSpeed;
            isASBuffed = false;

            Debug.Log("Hi");
        }
    } //refresh attack speed buff
    #endregion

    //Contains the movement speed buff function and refresh function
    #region Movement speed buff
    public void MovementSpeedBuff(float amount, float duration)
    {
        //check if there is a buff already active
        if (isMSBuffed == false)
        {
            //modify the AS of the unit
            unitStats.Speed = (1 + (amount / 100f)) * unitStats.Speed;

            //get the buff details and enter into local variables
            MSBuffDuration = duration;
            isMSBuffed = true;
            MSBuffCounter = MSBuffDuration;

            Debug.Log("Hi");
        }

    } //attack speed buff

    void RefreshMovementSpeedBuff()
    {
        if (isASBuffed == true)
        {
            //refresh attack speed of the unit
            unitStats.Speed = unitStats.StartSpeed;
            isMSBuffed = false;

            Debug.Log("Hi");
        }
    } //refresh attack speed buff
    #endregion

} //class
