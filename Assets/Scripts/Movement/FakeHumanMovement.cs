using System.Threading;
using UnityEngine;

public class FakeHumanMovement : BaseMovement
{
    public AudioClip[] pains;

    //non-humans die when stared at
    public override void StaredAt()
    {
        base.StaredAt(); //switch to stare animation
        //increase displayed score
        Score.Instance.IncreaseScore();
        Invoke("DestroySelf", 5f);
    }

    // Return a random pain sound to play when stared at
    protected override AudioClip GetStareSound()
    {
        return pains[Random.Range(0, pains.Length)];
    }


    //self explanatory
    private void DestroySelf()
    {
        Destroy(gameObject);
    }
}
