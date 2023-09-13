using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using TMPro;


public class SubtitleClip : PlayableAsset
{
    public string speaker = "EPROJECTS";
    public string subtitleText;
    public Color color = Color.white;




    public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
    {
        var playable = ScriptPlayable<SubtitleBehaviour>.Create(graph);

        SubtitleBehaviour subtitleBehaviour = playable.GetBehaviour();



        subtitleBehaviour.subtitleText = string.Format("{0}: {1}" , speaker, subtitleText);
        subtitleBehaviour.color = color;


        return playable;
    }
}