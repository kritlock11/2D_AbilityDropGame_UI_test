using TMPro;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float HP;
    public float MaxHP;
    public float Defense;
    public TextMeshProUGUI text_HP;
    public TextMeshProUGUI text_Defense;

    public float enemyCounterAttackCounter; 

    private void Start()
    {
        HP = MaxHP;
        Defense = 0;
    }
    private void Update()
    {
        RefreshStats();
    }

    void RefreshStats()
    {
        text_HP.text = $"HP: {HP} / {MaxHP}";
        text_Defense.text = $"Defense: {Defense}";
    }
    public void Hurt(float damage)
    {
        if (Defense > 0)
        {
            var r = Mathf.Abs(Defense - damage);
            Defense -= damage;
            if (Defense < 0)
            {
                Defense = 0;
                HP -= r;
                if (HP <= 0)
                {
                    Die();
                }
            }
        }
        else
        {
            HP -= damage;
            if (HP <= 0)
            {
                Die();
            }
        }

    }
    public void Heal(float damage)
    {
        HP += damage;
        if (HP >= MaxHP)
        {
            HP = MaxHP;
        }
    }
    public void AddDefense(float defense)
    {
        Defense += defense;
    }

    private void Die()
    {
        Destroy(gameObject);
    }




}
