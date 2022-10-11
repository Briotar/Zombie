using UnityEngine;

public class House : Building
{
    protected override void Destroy()
    {
        Debug.Log("Game over!");
    }
}