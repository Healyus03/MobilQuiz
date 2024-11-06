using UnityEngine;
using TMPro; // Använd TextMeshPro-namnrymd
using UnityEngine.UI; // För att använda UI-element som Button

public class QuizManager : MonoBehaviour
{
    public TMP_Text questionText; // Referens till TextMeshPro-textobjektet
    
    public TMP_Text progressText; // Texten för att visa progress
    public Button trueButton; // Referens till "Sant"-knappen
    public Button falseButton; // Referens till "Falskt"-knappen
    
    private int score = 0; // Variabel för att räkna antalet rätt

    private int currentQuestionIndex = 0; // Håller reda på vilken fråga som visas
    private string[] questions = {
        "En sessionsfilterbrandvägg arbetar på datalänk- och fysiska lagret.",
        "Ett autonomt nätverk arbetar bara med datagram-kopplingar.",
        "Ett ICMP skickas alltid tillbaka till närmaste router.",
        "TDM är en analog multiplexeringsteknik som kombinerar analoga signaler.",
        "På en ADSL-ledning är frekvensutrymmet för tal mindre än frekvensutrymmet för nedströmsdata.",
        "I ett kretskopplat nätverk (virtual circuit) kommer alltid alla paket i samma session mellan sändare och mottagare att gå samma väg.",
        "IPv4-adressen 128.0.0.0 kan också skrivas som 128::0.",
        "I ett datagram-nätverk kommer alltid alla paket mellan sändare och mottagare att gå samma väg.",
        "TTL-fältet i IP-huvudet indikerar antalet hopp som paketet kan göra innan det kommer att kastas.",
        "En sessionsfilterbrandvägg arbetar på datalänk- och nätverkslagret."
                             
    };

    private bool[] answers = {
        false,
        false,  
        false,
        false, 
        true, 
        true, 
        false, 
        false, 
        true, 
        false
    };

    void Start()
    {
        DisplayQuestion();
        trueButton.onClick.AddListener(() => CheckAnswer(true));
        falseButton.onClick.AddListener(() => CheckAnswer(false));
    }

    void DisplayQuestion()
    {
        UpdateProgressText(); // Uppdatera progressionstexten i början
        if (currentQuestionIndex < questions.Length)
        {
            questionText.text = questions[currentQuestionIndex];
        }
        else
        {
            questionText.text = (score + " av " + questions.Length + " rätt!");
            trueButton.gameObject.SetActive(false);
            falseButton.gameObject.SetActive(false);
        }
    }

    void CheckAnswer(bool answer)
    {
        if (answer == answers[currentQuestionIndex])
        {
            Debug.Log("Rätt svar!");
            score++;
        }
        else
        {
            Debug.Log("Fel svar.");
        }

        currentQuestionIndex++;
        DisplayQuestion();
    }
    
    void UpdateProgressText()
    {
        if (currentQuestionIndex < questions.Length)
        {
            progressText.text = $"{currentQuestionIndex + 1}/{questions.Length}";
            questionText.text = questions[currentQuestionIndex];
        }
        
    }

}