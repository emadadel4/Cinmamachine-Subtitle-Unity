using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Windows;

public class SubtitleTrackMixer : PlayableBehaviour
{
    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
        TextMeshProUGUI text = playerData as TextMeshProUGUI;

        string currnetText = "";
        float currnetAlpha = 0f;
        Color currnetColor = Color.red;

        if(!text) { return; }
        
        int inputCount = playable.GetInputCount();

        for (int i = 0; i < inputCount; i++)
        {
             float inputWight = playable.GetInputWeight(i);

            if(inputWight > 0f)
            {
                ScriptPlayable<SubtitleBehaviour> inputPlayable = (ScriptPlayable<SubtitleBehaviour>)playable.GetInput(i);

                SubtitleBehaviour input = inputPlayable.GetBehaviour();
                currnetText = input.subtitleText;
                currnetAlpha = inputWight;
                currnetColor = input.color;

            }
        }


        text.text = currnetText;
        text.color = currnetColor;
        text.color = new Color(currnetColor.r, currnetColor.g, currnetColor.b, currnetAlpha);


    }
}