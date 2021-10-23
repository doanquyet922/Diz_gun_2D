using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets
{
    private string nameBullet;
    private int dame;
    public Bullets(string name,int dam)
    {
        this.nameBullet = name;
        this.dame = dam;
    }
    public string NameBullet { get => nameBullet; set => nameBullet = value; }
    public int Dame { get => dame; set => dame = value; }
}
