using UnityEngine;
using UnityEngine.UI;

public class EnemyHP : MonoBehaviour
{
    //health variables
    public static float maxHp;
    public static float staticHp;
    public float hp;
    public Text hpText;


    // starting hp
    void Start()
    {
        maxHp = 20;
        staticHp = 10;
    }

    // displaying hp
    void Update()
    {
        hp = staticHp;
        if (hp >= maxHp)
        {
            hp = maxHp;
        }

        hpText.text = hp + "";
    }
}
