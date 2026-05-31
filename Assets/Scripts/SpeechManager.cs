using System;
using System.Text;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.Windows.Speech;
using static UnityEngine.Rendering.GPUSort;

public class SpeechManager : MonoBehaviour
{
    public string asasa;
    [SerializeField]
    private string[] m_Keywords;

    private KeywordRecognizer m_Recognizer;

    [SerializeField] private Attacks attacks;

    void Start()
    {
        //keywords to be recognized, add japanese ones later
        m_Keywords = new string[] { "boom", "zap", "blaze", "slash", "whoosh", "spring", "‚Ç‚©‚ñ", "‚Ñ‚è‚Ñ‚è", "‚ß‚ç‚ß‚ç", "‚·‚Ï‚·‚Ï", "‚«‚ã‚¢‚ñ", "‚É‚å‚«‚É‚å‚«", "dokan", "biribiri", "meramera", "supasupa", "kyuin", "nyokinyoki" };
        m_Recognizer = new KeywordRecognizer(m_Keywords, ConfidenceLevel.Low); //low confidence to be more forgiving
        m_Recognizer.OnPhraseRecognized += OnPhraseRecognized;
        m_Recognizer.Start();
        Debug.Log(m_Recognizer.IsRunning);
    }

    private void OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        //debug
        StringBuilder builder = new StringBuilder();
        builder.AppendFormat("{0} ({1}){2}", args.text, args.confidence, Environment.NewLine);
        builder.AppendFormat("\tTimestamp: {0}{1}", args.phraseStartTime, Environment.NewLine);
        builder.AppendFormat("\tDuration: {0} seconds{1}", args.phraseDuration.TotalSeconds, Environment.NewLine);
        Debug.Log(builder.ToString());

        //Different attacks
        switch (args.text)
        {
            case "‚Ç‚©‚ñ":
            case "boom":
            case "dokan":
                SoundManager.Instance.PlaySE(SFX.Dokaan);
                attacks.LaunchAttack(AttackType.Dokan);
                break;
            case "‚Ñ‚è‚Ñ‚è":
            case "zap":
            case "biribiri":
                SoundManager.Instance.PlaySE(SFX.BiriBiri);
                attacks.LaunchAttack(AttackType.BiriBiri);
                break;
            case "‚ß‚ç‚ß‚ç":
            case "blaze":
            case "meramera":
                SoundManager.Instance.PlaySE(SFX.Meramera);
                attacks.LaunchAttack(AttackType.MeraMera);
                break;
            case "‚·‚Ï‚·‚Ï":
            case "slash":
            case "supasupa":
                SoundManager.Instance.PlaySE(SFX.Supasupa);
                attacks.LaunchAttack(AttackType.SupaSups);
                break;
            case "‚«‚ã‚¢‚ñ":
            case "whoosh":
            case "kyuin":
                SoundManager.Instance.PlaySE(SFX.kyuiin);
                attacks.LaunchAttack(AttackType.kyuin);
                break;
            case "‚É‚å‚«‚É‚å‚«":
            case "spring":
            case "nyokinyoki":
                SoundManager.Instance.PlaySE(SFX.Nyokinyoki);
                attacks.LaunchAttack(AttackType.nyokinyoki);
                break;
        }
    }
}
