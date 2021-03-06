using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehavior : MonoBehaviour
{
    [SerializeField] public List<GameObject> SpawnLocList;
    [SerializeField] GameObject projectile;

    GameObject target = null;

    float attackRate = 2.0f;
    float attackTimer = 0.0f;
    int attackHand = -1;

    public string ID;
    public float HP;
    public int DEF;

    public bool isDead = false;
    public bool spawnSoul = false;

    public Animator animator;




    // Start is called before the first frame update
    void Start()
    {
        if (target != null)
            this.transform.LookAt(target.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.LookAt(target.transform.position);

        if (attackTimer < attackRate)
        {
            attackTimer += Time.deltaTime;
        }    

        else
        {
            attack();
            attackTimer = 0.0f;
        }
    }

    private void attack()
    {
        if(attackHand == -1)
        {
            GameObject.Instantiate(projectile, this.transform.position + (this.transform.right.normalized * -1), Quaternion.identity, this.transform);
        }

        else if(attackHand == 1)
        {
            GameObject.Instantiate(projectile, this.transform.position+ (this.transform.right.normalized * 1), Quaternion.identity, this.transform);
        }

        attackHand *= -1;
    }

    //public void setTarget(GameObject targetObj)
    //{
    //    this.target = targetObj;
    //}

    //public GameObject getTarget()
    //{
    //    return target;
    //}
    public void goToSpawnPoints()
    {

        //int index = Random.Range(0, SpawnLocList.Count - 1);

        //this.transform.parent.position = SpawnLocList[index].transform.position;
        //Debug.Log("move to" + SpawnLocList[index].name);
    }

    public void IntializeBossStats()
    {
        switch (gameObject.name)
        {
            case "Eyeball(Boss)":
                {
                    HP = 150;
                    DEF = 0;
                    ID = "Eyeball(Boss)";
                }; break;

        }
    }

    public void TakeDamage(float amount)
    {
        if (isDead == false)
        {
            animator.SetTrigger("takeDamage");

            if (amount - DEF > 0)
            {
                this.HP -= (amount - DEF);
            }

            if (this.HP <= 0)
            {
                Die();
            }
        }
    }

    public void DisplayStats()
    {
        Debug.Log("Name: " + gameObject.name + "\n" + "HP: " + HP + "DEF: " + DEF + "\n");
    }

    public void Die()
    {
        PlayerData.nEnemyBossesKilled++;
        animator.SetBool("isDead", true);
        isDead = true;
    }

    public void TurnToSoul()
    {
        spawnSoul = true;
    }
}
