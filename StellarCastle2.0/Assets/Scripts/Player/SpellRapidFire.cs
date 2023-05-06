using UnityEngine;

public class SpellRapidFire : MonoBehaviour
{

    public string allyTag = "Good";

    [SerializeField]
    private float cooldown;
    public float Cooldown
    {
        get { return cooldown; }
    }

    private float count;
    public float Count
    {
        get { return count; }
    }

    [SerializeField]
    private float duration;

    [SerializeField]
    private float rapidIncreaseAmount;

    private void Start()
    {
        count = 0f;
        
    } //start

    private void Update()
    {
        if(count <= 0f)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                RapidFire();
                count = cooldown;
            }
        }
        count -= Time.deltaTime;

    } //update

    public void RapidFire()
    {
        //Find all the allied units and buildings
        GameObject[] units = GameObject.FindGameObjectsWithTag(allyTag);
        //loop through them
        foreach(GameObject unit in units)
        {
            //get their buffs script
            UnitBuffs unitBuffs = unit.GetComponent<UnitBuffs>();

            if(unitBuffs != null)
            {
                Debug.Log("hi");
                unitBuffs.AttackSpeedBuff(rapidIncreaseAmount, duration);
                unitBuffs.MovementSpeedBuff(rapidIncreaseAmount, duration);
            }

        }

    } //rapid fire

} //class
