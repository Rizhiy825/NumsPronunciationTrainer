using NumsPronunciationTrainer.Algorythms;

namespace NumsPronunciationTrainer.Models;

public class NumModel
{
    public int Number { get; }
    public string? Pronunciation
    {
        get
        {
            var solver = new PronunciationSolver();
            var pron = solver.GetPronunciation(Number);
            
            return pron;
        }
    }

   

    public NumModel(int number)
    {
        Number = number;
    }
}