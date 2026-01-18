using System;
using System.Collections.Generic;
using System.Text;

public class Question
{
    public string Text { get; set; }
    public string[] Options { get; set; }
    public int CorrectIndex { get; set; }
}

public class QuestionGroup
{
    public string GroupName { get; set; }
    public List<Question> Questions { get; set; } = new List<Question>();
}