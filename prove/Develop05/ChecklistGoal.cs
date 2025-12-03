public class ChecklistGoal : Goal
{
    private int _completedCount;
    private int _targetCount;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points,
        int targetCount, int bonus, int completedCount = 0)
        : base(name, description, points)
    {
        _targetCount = targetCount;
        _bonus = bonus;
        _completedCount = completedCount;
    }

    public override int RecordEvent()
    {
        _completedCount++;
        int points = GetPoints();

        if (_completedCount == _targetCount)
            points += _bonus;

        return points;
    }

    public override bool IsComplete() =>
        _completedCount >= _targetCount;

    public override string GetStatus() =>
        IsComplete()
            ? $"[X] Completed {_completedCount}/{_targetCount}"
            : $"[ ] Completed {_completedCount}/{_targetCount}";

    public override string GetStringRepresentation() =>
        $"ChecklistGoal:{GetName()}|{GetDescription()}|{GetPoints()}|{_targetCount}|{_bonus}|{_completedCount}";
}
