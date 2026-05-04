namespace WinFormsApp2.Models;

public class ExerciseLog
{
    public int Id { get; set; }
    public int WorkoutId { get; set; }
    public int ExerciseId { get; set; }
    public int Sets { get; set; }
    public int Reps { get; set; }
    public double Weight { get; set; }
}
