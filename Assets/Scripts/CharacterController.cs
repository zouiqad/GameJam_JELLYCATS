using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEntityCharacter : MonoBehaviour
{
    private int maxHp;
    private int hp;
    private int zoneID;
    public bool isDead;
    private bool alienForm;
    private int range;
    private int atk;
    private bool isPlayer;
    void Start()
    {
        maxHp = 2;
        hp = 2; 
        zoneID = UnityEngine.Random.Range(1, 9);
        // le max a modifier selon le nombre de zones au total
        isDead = false;
        alienForm = false;
        range = 0;
        atk = 1;
        isPlayer = false;
    }
    public int getHp() { return hp; }
    public int getMaxHp() { return maxHp; }
    public int getZoneID() {  return zoneID; }
    public void setHp(int hp) { this.hp = hp;}

    void declarePlayer()
    {
        isPlayer = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (!isPlayer)
        {
            return;
        }
        if (alienForm)
        {
            atk = 3;
            range = 3;
        } else
        {
            atk = 1;
            range = 1;
        }
    }
    void takeDamage()
    {
        hp--;
        if (hp <= 0)
        {
            isDead = true;
        }
    }
}
