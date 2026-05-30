using System;
using System.Text;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class SpeechManager : MonoBehaviour
{
    [SerializeField]
    private string[] m_Keywords;

    private KeywordRecognizer m_Recognizer;

    void Start()
    {
        //keywords to be recognized, add japanese ones later
        m_Keywords = new string[] { "boom", "zap", "blaze", "slash", "whoosh", "spring"}; 
        m_Recognizer = new KeywordRecognizer(m_Keywords, ConfidenceLevel.Low); //low confidence to be more forgiving
        m_Recognizer.OnPhraseRecognized += OnPhraseRecognized;
        m_Recognizer.Start();
        Debug.Log(m_Recognizer.IsRunning);
    }

    private void OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {    
        StringBuilder builder = new StringBuilder();
        builder.AppendFormat("{0} ({1}){2}", args.text, args.confidence, Environment.NewLine);
        builder.AppendFormat("\tTimestamp: {0}{1}", args.phraseStartTime, Environment.NewLine);
        builder.AppendFormat("\tDuration: {0} seconds{1}", args.phraseDuration.TotalSeconds, Environment.NewLine);
        Debug.Log(builder.ToString());

        //Different attacks
        switch(args.text)
        {
            case "boom":
                Attacks.LaunchAttack(Attack.Boom);
                break;
            case "zap":
                Attacks.LaunchAttack(Attack.Zap);
                break;
            case "blaze":
                Attacks.LaunchAttack(Attack.Blaze);
                break;
            case "slash":
                Attacks.LaunchAttack(Attack.Slash);
                break;
            case "whoosh":
                Attacks.LaunchAttack(Attack.Whoosh);
                break;
            case "Spring":
                Attacks.LaunchAttack(Attack.Spring);
                break;
        }
    }
}
