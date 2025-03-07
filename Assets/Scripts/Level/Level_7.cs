using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Level_7 : MonoBehaviour
{
    public GameObject ground;
    public GameObject posGround;
    public GameObject moveGround;
    public GameObject bigGround;
    public TMP_Text Text;

    private float timer = 0;
    private bool shouldMove = false;

    void Start()
    {
        Text.text = "You are Chill guy";
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 4.5f && !shouldMove)
        {
            shouldMove = true;
        }

        if (shouldMove)
        {
            Vector3 targetPosition = posGround.transform.position; // Get the position of posGround
            ground.transform.position = Vector3.MoveTowards(ground.transform.position, targetPosition, 4f * Time.deltaTime);
        }

        if(timer >= 8f)
        {
            moveGround.SetActive(true);
            bigGround.SetActive(true);
        }

        if(timer >= 10f)
        {
            Text.text = "Now go find the key!!!";
        }
    }
}
