using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq; // Required for FirstOrDefault and OrderBy
using System.Text.Json;
using System.Windows.Forms;

namespace Quiz
{
    public partial class Form1 : Form
    {
        // ONE Random object
        private Random rng = new Random();

        // Timer
        int timeLeft = 60;

        // Questions - Data storage
        List<QuestionGroup> allGroups = new List<QuestionGroup>();
        List<Question> groupQuestions = new List<Question>();

        // UI state
        List<Button> optionButtons;
        string selectedGroup = "Database";
        int currentIndex = 0;

        public Form1()
        {
            InitializeComponent();

            // Start the quiz process
            LoadQuestions();
            PrepareGroup();
            LoadQuestion();
        }

        // 1. Load data from the JSON file
        void LoadQuestions()
        {
            try
            {
                string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "questions.json");
                if (File.Exists(filePath))
                {
                    string json = File.ReadAllText(filePath);
                    allGroups = JsonSerializer.Deserialize<List<QuestionGroup>>(json);
                }
                else
                {
                    MessageBox.Show("JSON file not found at: " + filePath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading JSON: " + ex.Message);
            }
        }

        // 2. Filter questions by the chosen category (GroupName)
        void PrepareGroup()
        {
            // Find the group object inside allGroups that matches our selectedGroup string
            var group = allGroups.FirstOrDefault(g => g.GroupName == selectedGroup);

            if (group != null && group.Questions != null)
            {
                // Copy the questions and shuffle them using LINQ
                groupQuestions = group.Questions.OrderBy(q => rng.Next()).ToList();
            }
            else
            {
                MessageBox.Show($"Could not find group: {selectedGroup}");
            }
        }

        // 3. Display the current question on the screen
        void LoadQuestion()
        {
            if (groupQuestions == null || groupQuestions.Count == 0 || currentIndex >= groupQuestions.Count)
            {
                MessageBox.Show("All questions displayed! Check your notebooks.");
                timer1.Stop();
                return;
            }

            panelBlank.Visible = false;
            var q = groupQuestions[currentIndex];

            // Display the question text
            lblQuestion.Text = $"Question {currentIndex + 1}: {q.Text}";

            // Display the options A, B, C, D
            string[] prefixes = { "A) ", "B) ", "C) ", "D) " };

            for (int i = 0; i < optionButtons.Count; i++)
            {
                if (i < q.Options.Length)
                {
                    // Combines the prefix (A, B, C, D) with the answer text from JSON
                    optionButtons[i].Text = prefixes[i] + q.Options[i];
                    optionButtons[i].Visible = true;

                    // Optional: Reset color so students don't see the previous answer
                    optionButtons[i].BackColor = Color.White;
                }
                else
                {
                    optionButtons[i].Visible = false;
                }
            }

            // Reset timer for the next question
            timeLeft = 60;
            lblTimer.Text = "60";
            timer1.Start();
        }

        // 4. Handle Answer Checking
        private void OptionButton_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            int selectedIndex = (int)clickedButton.Tag;
            var currentQuestion = groupQuestions[currentIndex];

            if (selectedIndex == currentQuestion.CorrectIndex)
            {
                clickedButton.BackColor = Color.Green;
                MessageBox.Show("Correct!");
            }
            else
            {
                clickedButton.BackColor = Color.Red;
                MessageBox.Show("Wrong!");
            }

            // Move to next question
            currentIndex++;
            LoadQuestion();
        }

        // Timer Logic
        private void timer1_Tick(object sender, EventArgs e)
        {
            timeLeft--;
            lblTimer.Text = timeLeft.ToString();

            if (timeLeft <= 0)
            {
                timer1.Stop();
                HideQuestion();
            }
        }

        void HideQuestion()
        {
            lblQuestion.Text = "Time is up!";
            foreach (var btn in optionButtons)
                btn.Visible = false;

            panelBlank.Visible = true;
        }

        // Shuffle helper (optional if you use the LINQ OrderBy version)
        public void Shuffle<T>(List<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}