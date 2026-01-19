using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Media;
using System.Windows.Forms;

namespace Quiz
{
    public partial class Form1 : Form
    {
        private Random rng = new Random();
        private int timeLeft = 60;
        private int questionsPerSession = 40; // Number of random questions to pick

        private List<QuestionGroup> allGroups = new List<QuestionGroup>();
        private List<Question> activeQuizPool = new List<Question>();
        private List<string> usedQuestionIds = new List<string>();
        private List<Label> optionLabels;

        private int currentIndex = 0;
        private string usedFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "used_questions.txt");

        public Form1()
        {
            InitializeComponent();

            // Link UI buttons (Ensure these names match your Designer names)
            optionLabels = new List<Label> { lblOptionA, lblOptionB, lblOptionC, lblOptionD };

            // Initial UI Setup
            btnNext.Visible = false;
            btnShowAnswer.Visible = false;

            StartNewSession();
        }

        private void StartNewSession()
        {
            LoadAllQuestions();
            LoadUsedHistory();

            // 1. Merge all questions from all groups
            // 2. Filter out questions already listed in used_questions.txt
            // 3. Shuffle the remaining pool
            // 4. Take the session count (e.g., 40)
            activeQuizPool = allGroups
                .SelectMany(g => g.Questions)
                .Where(q => !usedQuestionIds.Contains(q.Id))
                .OrderBy(x => rng.Next())
                .Take(questionsPerSession)
                .ToList();

            if (activeQuizPool.Count > 0)
            {
                LoadQuestion();
            }
            else
            {
                lblQuestion.Text = "No new questions left!";
                MessageBox.Show("All questions in the database have been used. Delete used_questions.txt to reset.");
            }
        }

        void LoadAllQuestions()
        {
            try
            {
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "questions.json");
                if (File.Exists(path))
                {
                    string json = File.ReadAllText(path);
                    allGroups = JsonSerializer.Deserialize<List<QuestionGroup>>(json);
                }
                else
                {
                    MessageBox.Show("JSON file not found in Data folder.");
                }
            }
            catch (Exception ex) { MessageBox.Show("JSON Error: " + ex.Message); }
        }

        void LoadUsedHistory()
        {
            // Ensure the Data directory exists
            string directory = Path.GetDirectoryName(usedFilePath);
            if (!Directory.Exists(directory)) Directory.CreateDirectory(directory);

            if (File.Exists(usedFilePath))
                usedQuestionIds = File.ReadAllLines(usedFilePath).ToList();
        }

        void LoadQuestion()
        {
            if (currentIndex >= activeQuizPool.Count)
            {
                lblQuestion.Text = "Session Finished!";
                return;
            }

            var q = activeQuizPool[currentIndex];

            // Display Question
            lblQuestion.Visible = true;
            lblQuestion.Text = $"Question {currentIndex + 1}: {q.Text}";

            string[] prefixes = { "A) ", "B) ", "C) ", "D) " };

            for (int i = 0; i < optionLabels.Count; i++)
            {
                if (i < q.Options.Length)
                {
                    optionLabels[i].Text = prefixes[i] + q.Options[i];
                    optionLabels[i].Visible = true;
                    optionLabels[i].ForeColor = Color.Black; // Standard text color
                }
                else
                {
                    optionLabels[i].Visible = false;
                }
            }

            btnNext.Visible = false;
            btnShowAnswer.Visible = false;
            timeLeft = 60;
            lblTimer.Text = "60";
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timeLeft--;
            lblTimer.Text = timeLeft.ToString();

            if (timeLeft <= 0)
            {
                timer1.Stop();
                PlayAlarm();

                // Disappear options so students stop writing
                lblQuestion.Text = "TIME IS UP!";
                //foreach (var lbl in optionLabels) lbl.Visible = false;

                btnShowAnswer.Visible = true;
            }
        }

        private void PlayAlarm()
        {
            try
            {
                string soundPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "alarm.wav");
                if (File.Exists(soundPath))
                {
                    SoundPlayer player = new SoundPlayer(soundPath);
                    player.Play(); // Use .PlaySync() if you want the app to wait for the sound
                }
            }
            catch (Exception ex)
            {
                // Fail silently or show error
                Console.WriteLine("Sound error: " + ex.Message);
            }
        }

        private void btnShowAnswer_Click(object sender, EventArgs e)
        {
            foreach (var lbl in optionLabels) lbl.Visible = false;

            var q = activeQuizPool[currentIndex];
            char[] labels = { 'A', 'B', 'C', 'D' };

            // Reveal only the correct answer
            lblQuestion.Text = $"Correct Answer: {labels[q.CorrectIndex]}) {q.Options[q.CorrectIndex]}";
            lblQuestion.ForeColor = Color.DarkGreen; // Make the answer stand out

            File.AppendAllLines(usedFilePath, new[] { q.Id });
            usedQuestionIds.Add(q.Id);

            btnShowAnswer.Visible = false;
            btnNext.Visible = true;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            currentIndex++;
            lblQuestion.ForeColor = Color.Black; // Reset color for next question
            LoadQuestion();
        }
    }
}