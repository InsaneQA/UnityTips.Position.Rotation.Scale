using System.Collections;
using UnityEngine;

public class Distraction : MonoBehaviour
{
    [SerializeField] private float _waitTime;

    private float _timePassed = 0;

    private void Update()
    {
        _timePassed += Time.deltaTime;

        // _timePassed needs to be cleared from time to time
        // so that the monster don't get distracted every time the player enters the area of visibility
        if (_timePassed > (_waitTime * 2))
        {
            _timePassed = 0;
        }
    }

    public bool ShouldBeDistracted()
    {
        return _timePassed >= _waitTime;
    }

    public void Distract(SillyMonster sillyMonster)
    {
        _timePassed = 0;

        StartCoroutine(LookAway(sillyMonster));
    }

    public IEnumerator LookAway(SillyMonster sillyMonster)
    {
        sillyMonster.transform.Rotate(Vector3.forward, 180f);

        //Wait for some time
        yield return new WaitForSeconds(_waitTime);
        _timePassed = 0;

        sillyMonster.transform.Rotate(Vector3.forward, 180f);
    }


}

