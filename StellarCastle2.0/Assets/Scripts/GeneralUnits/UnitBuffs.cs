using UnityEngine;

[RequireComponent(typeof(UnitStats))]
public class UnitBuffs : MonoBehaviour
{
    UnitStats unitStats;

    private Color startColor;

    //attack speed buff
    private float ASBuffAmount = 0f;
    private float ASBuffDuration = 0f;
    private float ASBuffCounter = 0f;
    private bool isASBuffed = false;

    private void Awake()
    {
        unitStats = GetComponent<UnitStats>();
    } //start

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
    } //update

    public void AttackSpeedBuff(float amount, float duration)
    {
        //check if there is a buff already active
        if (isASBuffed == false)
        {
            //modify the AS of the unit
            unitStats.AttackSpeed = (1 + (amount / 100f)) * unitStats.StartAttackSpeed;

            //get the buff details and enter into local variables
            ASBuffAmount = amount;
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

} //class
