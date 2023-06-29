using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject player;
    public GameObject playerBase;

    public UnitStats baseUnitStats;

    public PlayerStats playerStats;

    private float timeSeconds;
    public float timeMinutes;

    [Header("UI elements")]
    public GameObject currencyText;
    public GameObject timeText;
    public Image healthBar;

    private void Start()
    {
        timeSeconds = 0f;
        timeMinutes = 0f;
    } //start

    private void Update()
    {
        //manage the currency text
        currencyText.GetComponent<TMPro.TextMeshProUGUI>().text = "Gold: " + playerStats.Money.ToString("00");

        //manage the health image of the base
        if (playerBase != null)
        {
            if (healthBar != null)
            {
                healthBar.fillAmount = baseUnitStats.Health / baseUnitStats.StartHealth;
            }
        }

        //manage the time text
        CalculateTime();

        timeText.GetComponent<TMPro.TextMeshProUGUI>().text = timeMinutes.ToString("00") + ":" + timeSeconds.ToString("00");

    } //update

    void CalculateTime()
    {
        //increase seconds every frame
        timeSeconds += Time.deltaTime;
        //when seconds cross 60 increase minute by one
        if(timeSeconds >= 60f)
        {
            timeMinutes += 1f;
            //reset seconds
            timeSeconds = 0f;
        }

    } //calculate time

}
