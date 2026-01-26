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
        private int timer = 60;
        private int questionsPerSession = 52; // Number of random questions to pick
        private bool alarmPlayed = false;
        private bool isJetpotMode = false;

        private List<QuestionGroup> allGroups = new List<QuestionGroup>();
        private List<Question> activeQuizPool = new List<Question>();
        private List<string> usedQuestionIds = new List<string>();
        private List<Label> optionLabels;
        private List<string> sessionResults = new List<string>();

        private int currentIndex = 0;
        private string usedFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "used_questions.txt");

        public Form1()
        {
            InitializeComponent();

            timer1.Stop();
            timer1.Enabled = false;

            btnJetpot.Click += new EventHandler(btnJetpot_Click);

            optionLabels = new List<Label> { lblOptionA, lblOptionB, lblOptionC, lblOptionD };

            // Initial UI Setup
            btnNext.Visible = false;
            btnStop.Visible = false;
            btnShowAnswer.Visible = false;
            lblCorrectAnswer.Visible = false;
            btnJetpot.Visible = false;

            panelWelcome.Visible = true;
            panelWelcome.BringToFront();

            // StartNewSession();
        }

        //private void StartNewSession()
        //{
        //    LoadAllQuestions();
        //    LoadUsedHistory();
        //    isJetpotMode = false;

        //    // 1. Get the Sample Questions first (and filter out used ones)
        //    var samplePool = allGroups
        //        .Where(g => g.GroupName == "SampleQuestions")
        //        .SelectMany(g => g.Questions)
        //        .Where(q => !usedQuestionIds.Contains(q.Id))
        //        .ToList();

        //    // 2. Get the rest of the questions from other groups
        //    var otherPool = allGroups
        //        .Where(g => g.GroupName != "SampleQuestions")
        //        .SelectMany(g => g.Questions)
        //        .Where(q => !usedQuestionIds.Contains(q.Id))
        //        .OrderBy(x => rng.Next()) // Shuffle only the non-sample questions
        //        .ToList();

        //    // 3. Combine them: Sample questions first, then the random ones
        //    activeQuizPool = samplePool.Concat(otherPool).Take(questionsPerSession).ToList();

        //    if (activeQuizPool.Count > 0)
        //    {
        //        LoadQuestion();
        //    }
        //    else
        //    {
        //        lblQuestion.Text = "No new questions left!";
        //        MessageBox.Show("All questions used. Add New Questions or Reset the history file.");
        //    }
        //}

        private void StartNewSession()
        {
            isJetpotMode = false;
            LoadAllQuestions("questions.json");
            LoadUsedHistory();

            // 1. Get Samples
            var samplePool = allGroups
                .Where(g => g.GroupName == "SampleQuestions")
                .SelectMany(g => g.Questions)
                .Where(q => !usedQuestionIds.Contains(q.Id)).ToList();

            // 2. Get Others
            var otherPool = allGroups
                .Where(g => g.GroupName != "SampleQuestions")
                .SelectMany(g => g.Questions)
                .Where(q => !usedQuestionIds.Contains(q.Id))
                .OrderBy(x => rng.Next()).ToList();

            // 3. Combine for 50 total
             //activeQuizPool = samplePool.Concat(otherPool).Take(questionsPerSession).ToList();
            activeQuizPool = samplePool.Take(2).Concat(otherPool.Take(60)).ToList();

            if (activeQuizPool.Count > 0)
            {
                currentIndex = 0;
                LoadQuestion();
            }
        }

        //void LoadAllQuestions()
        //{
        //    try
        //    {
        //        string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "questions.json");
        //        if (File.Exists(path))
        //        {
        //            string json = File.ReadAllText(path);
        //            allGroups = JsonSerializer.Deserialize<List<QuestionGroup>>(json);
        //        }
        //        else
        //        {
        //            MessageBox.Show("JSON file not found in Data folder.");
        //        }
        //    }
        //    catch (Exception ex) { MessageBox.Show("JSON Error: " + ex.Message); }
        //}

        void LoadAllQuestions(string fileName)
        {
            try
            {
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", fileName);
                if (File.Exists(path))
                {
                    string json = File.ReadAllText(path);
                    allGroups = JsonSerializer.Deserialize<List<QuestionGroup>>(json);
                }
                else
                {
                    MessageBox.Show($"{fileName} not found in Data folder.");
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

            // --- RESET TIMER & PROGRESS BAR ---
            timeLeft = timer;
            lblTimer.Text = timer.ToString();
            lblTimer.ForeColor = Color.Black;
            PlayAlarm("start_alarm.wav");

            pbTimer.Maximum = timer;
            pbTimer.Value = timer;
            pbTimer.Visible = true;

            // Display Question and Options
            lblQuestion.Visible = true;
            //lblQuestion.Text = $"Question {currentIndex + 1}: {q.Text}";   // just for testing
            if (currentIndex < 2)
            {
                lblQuestion.Text = $"SAMPLE QUESTION {currentIndex + 1}: {q.Text}";
            }
            else
            {
                lblQuestion.Text = $"Question {currentIndex - 1}: {q.Text}";
            }
            string[] prefixes = { "A) ", "B) ", "C) ", "D) " };
            for (int i = 0; i < optionLabels.Count; i++)
            {
                if (i < q.Options.Length)
                {
                    optionLabels[i].Text = prefixes[i] + q.Options[i];
                    optionLabels[i].Visible = true;
                    optionLabels[i].ForeColor = Color.Black;
                }
                else { optionLabels[i].Visible = false; }
            }

            btnNext.Visible = false;
            btnStop.Visible = false;
            btnShowAnswer.Visible = false;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            timeLeft--;
            lblTimer.Text = timeLeft.ToString();

            if (timeLeft >= 0)
            {
                pbTimer.Value = timeLeft;
            }

            if (timeLeft <= 10)
            {
                lblTimer.ForeColor = Color.Red;
                if (!alarmPlayed)
                {
                    PlayAlarm("10sec-countdown.wav");
                    alarmPlayed = true;
                }
            }

            if (timeLeft <= 0)
            {
                timer1.Stop();
                pbTimer.Visible = false;

                lblQuestion.Text = "TIME'S UP!";

                btnShowAnswer.Visible = true;
            }
        }

        private void PlayAlarm(string music)
        {
            try
            {
                string soundPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", music);
                if (File.Exists(soundPath))
                {
                    SoundPlayer player = new SoundPlayer(soundPath);
                    player.Play();
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
            DialogResult result = MessageBox.Show("Are you sure you want to SHOW the answer?", "ARE YOU SURE?", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {


                foreach (var lbl in optionLabels) lbl.Visible = false;

                var q = activeQuizPool[currentIndex];
                char[] labels = { 'A', 'B', 'C', 'D' };

                // Reveal only the correct answer
                lblQuestion.Visible = false;
                lblCorrectAnswer.Visible = true;
                lblCorrectAnswer.Text = $"Correct Answer: {labels[q.CorrectIndex]}"; // - {q.Options[q.CorrectIndex]}
                lblCorrectAnswer.ForeColor = Color.DarkGreen;

                File.AppendAllLines(usedFilePath, new[] { q.Id });
                usedQuestionIds.Add(q.Id);

                string reportEntry = $"Question : {currentIndex - 1} ID: {q.Id} | Q: {q.Text} | Answer: {labels[q.CorrectIndex]} - {q.Options[q.CorrectIndex]}";
                sessionResults.Add(reportEntry);

                btnShowAnswer.Visible = false;
                btnNext.Visible = true;
                btnStop.Visible = true;
            }
        }

        private void SaveSessionReport()
        {
            if (sessionResults.Count == 0) return;

            try
            {
                string fileName = $"Session_Report_{DateTime.Now:yyyyMMdd_HHmmss}.txt";
                string reportPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", fileName);

                // Add a header
                List<string> fileContent = new List<string> { "--- QUIZ SESSION REPORT ---", $"Date: {DateTime.Now}\n" };
                fileContent.AddRange(sessionResults);

                File.WriteAllLines(reportPath, fileContent);
                MessageBox.Show($"Session report saved to: {fileName}");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving report: " + ex.Message);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            currentIndex++;
            lblQuestion.ForeColor = Color.Black;
            alarmPlayed = false;
            lblCorrectAnswer.Visible = false;
            if (currentIndex >= activeQuizPool.Count && !isJetpotMode)
            {
                lblQuestion.Text = "Session 1 Finished!";
                btnNext.Visible = true;
                SaveSessionReport();
                btnJetpot.Visible = false;
            }
            else
            {
                LoadQuestion();
            }
        }

        private void btnJetpot_Click(object sender, EventArgs e)
        {
            isJetpotMode = true;
            btnJetpot.Visible = false;

            LoadAllQuestions("jetpot_questions.json");

            activeQuizPool = allGroups.SelectMany(g => g.Questions).ToList();

            if (activeQuizPool.Count > 0)
            {
                currentIndex = 0;
                LoadQuestion();

                // Visual cue: Change background to gold for Jetpot!
                this.BackColor = Color.Gold;

            }
            else
            {
                MessageBox.Show("No questions found in jetpot_questions.json!");
            }
        }

        private void btnStartQuiz_Click(object sender, EventArgs e)
        {
            panelWelcome.Visible = false; // Hide the welcome screen
            StartNewSession();           // Now start the actual quiz logic
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit the quiz?", "Exit", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                SaveSessionReport();
                this.Close();
            }
        }
    }
}