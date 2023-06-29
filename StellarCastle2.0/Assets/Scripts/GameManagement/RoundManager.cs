using UnityEngine;

public class RoundManager : MonoBehaviour
{

    [SerializeField]
    private float roundDuration;
    private float roundDurationCount;

    [SerializeField]
    private float preparationTime;
    private float preparationTimeCount;

    private void Awake()
    {
        roundDurationCount = preparationTime;
        preparationTimeCount = preparationTime;
    } //awake

    private void Update()
    {
        //if preparation time is over start round
        if(preparationTime <= 0f)
        {
            //start round
            StartRound();
        }


    } //update

    void StartRound()
    {

    } //start round


} //class
