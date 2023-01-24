using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PegsManager
{
    static public List<Transform> AllPegs { get; private set; }
    static public List<Transform> NormalPegs {get; private set;}
    static public List<Transform> PointPegs  {get; private set;}
    static public Queue<Transform> PegsToRemove  {get; private set; }
    static private Prediction prediction { get; set; }

    static private float ratePegs;
    static private int powerUPsIndex;
    static private PegScript powerUpPeg, multiplierPeg;

    static private Material hittedMaterial;


    // Start is called before the first frame update
    static public void Init(Transform pegsParent, Prediction prediction, Material hittedMaterial, float rate = 0.75f)
    {
        PegsManager.hittedMaterial = hittedMaterial;

        powerUPsIndex = 1;
        ratePegs = rate;
        PegsManager.prediction = prediction;

        //Get all pegs
        List<Transform> allPegs = new List<Transform>();

        foreach (Transform obj in pegsParent)
        {
            allPegs.Add(obj);
        }

        allPegs.RemoveAt(0); // remove bounds from list

        Utilities.ShuffleThis(ref allPegs);

        AllPegs = allPegs;

        //generate special pegs
        powerUpPeg = AllPegs[0].GetComponent<PegScript>();
        powerUpPeg.SetType(PegScript.PegType.PowerUP);

        multiplierPeg = AllPegs[1].GetComponent<PegScript>();
        multiplierPeg.SetType(PegScript.PegType.Multiplier);

        InitPegsList();
        PegsToRemove = new Queue<Transform>();
    }
    static void InitPegsList()
    {

        PegScript pegScript;

        //generate normals and points pegs
        NormalPegs = new List<Transform>();
        PointPegs = new List<Transform>();

        for (int i = 2; i < AllPegs.Count * ratePegs; i++)
        {
            pegScript = AllPegs[i].GetComponent<PegScript>();

            pegScript.SetType(PegScript.PegType.Normal);

            NormalPegs.Add(AllPegs[i]);
        }

        for (int i = (int)(AllPegs.Count * ratePegs); i < AllPegs.Count; i++)
        {
            pegScript = AllPegs[i].GetComponent<PegScript>();

            pegScript.SetType(PegScript.PegType.Point);

            PointPegs.Add(AllPegs[i]);
        }
    }
    static Transform GetRandomNormalPeg()
    {
        int randomIndex = 0;
        try
        {
            randomIndex = Random.Range(3, ((int)(NormalPegs.Count)));
            NormalPegs.RemoveAt(randomIndex);
            return NormalPegs[randomIndex];
        }
        catch (System.Exception ex)
        {
            Debug.LogException(ex);
            return NormalPegs[0];
        }


    }
    static public void RemovePegFrom(Transform transform)
    {
        Transform obj = AllPegs.Find(obstacle => obstacle.transform == transform);

        PegScript pegScript = obj.GetComponent<PegScript>();

        switch (pegScript.Type)
        {
            case PegScript.PegType.Normal:
                var normalObj = NormalPegs.Find(obstacle => obstacle.transform == transform);
                NormalPegs.Remove(normalObj); // remove?
                break;
            case PegScript.PegType.Point:
                var pointObj = PointPegs.Find(obstacle => obstacle.transform == transform);
                PointPegs.Remove(pointObj);
                break;
            case PegScript.PegType.Multiplier:
                TextManager.SendText("Multiplier hitted");
                GetRandomNormalPeg().GetComponent<PegScript>().SetType(PegScript.PegType.Multiplier);
                break;
            case PegScript.PegType.PowerUP:
                if (powerUPsIndex > 1) return;
                TextManager.SendText("Power UP hitted");
                GetRandomNormalPeg().GetComponent<PegScript>().SetType(PegScript.PegType.PowerUP);
                powerUPsIndex++;
                break;
        }
    }
    static public void AddToRemove(Transform transform)
    {
        PegsToRemove.Enqueue(transform);
    }

    static public void RemoveSelectedPegs()
    {
        while (PegsToRemove.Count > 0)
        {
            Transform actualPeg = PegsToRemove.Dequeue();
            GameObject obj = actualPeg.gameObject;
            prediction.Obstacles[obj.name + "(Clone)"].SetActive(false);
            obj.SetActive(false);
            RemovePegFrom(obj.transform);
        }
    }

    static public void HittedPeg(Collision2D col)
    {
        Transform objTransform = col.gameObject.transform;

        if (!PegsToRemove.Contains(objTransform))
        {
            SoundManager.PlayRandomHit();

            AddToRemove(objTransform);

            PegScript pegScript = objTransform.GetComponent<PegScript>();
            int scoreToAdd = pegScript.Points;

            GameManager.ActualScore += scoreToAdd * ((int)GameManager.ActualMultiplier);

            col.gameObject.GetComponent<SpriteRenderer>().material = hittedMaterial;

            switch (pegScript.Type)
            {
                case PegScript.PegType.Multiplier:
                    GameManager.ActualMultiplier += 0.25f;
                    break;
                case PegScript.PegType.PowerUP:
                    ExplodePowerUp(objTransform);
                    GameManager.ActualMultiplier += 0.05f;
                    break;
            }
        }
    }

    static public void ExplodePowerUp(Transform pos)
    {
        GameObject explosion = GameManager.Explosion;
        explosion.SetActive(true);

        explosion.GetComponent<PowerScript>().Init();

        explosion.transform.position = pos.position;

    }
}
