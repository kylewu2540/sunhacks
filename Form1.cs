using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace Pandemic
{
    public partial class Form1 : Form
    {
        List<Patient> patientList;
        public Form1(List<Patient> patientRecords)
        {
            this.patientList = patientRecords;
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Patient patient = null;
            textBox1.Text = String.Empty;
            textBox2.Text = String.Empty;
            textBox3.Text = String.Empty;
            textBox4.Text = String.Empty;

            if(textBox1.Text ==  ""  && textBox2.Text == "" && textBox3.Text == "" && textBox4.Text == ""
            {
                MessageBox.Show("Please fill out all fields. Patient status must be from 0 to 2, 0 is severe case, 1 is mild, 2 is fine for release.");
            }
            else
            {
                try
                {
                    int idNumber = Int32.Parse(textBox2.Text);
                    int incomeValue = Int32.Parse(textBox3.Text);
                    int patientStatus = Int32.Parse(textBox4.Text);
                    patient = new Patient();
                    if(patientStatus >= 0 || patientStatus <= 2)
                    {
                        textBox4.Text = "";
                        MessageBox.Show("Please enter a patientStatus between 0 and 2");
                        patientStatus = Int32.Parse(textBox4.Text);
                    }

                    patient.setPatientName(textBox1.Text);
                    patient.setID(idNumber);
                    patient.setIncome(incomeValue);
                    patient.setStatus(patientStatus);
                    MessageBox.Show("Patient added successfully!");
                }
                catch(FormatException)
                {
                    MessageBox.Show("please enter a valid integer value for ID, income and Status.");
                }

                if(textBox1.Equals(textBox1))
                {
                    Boolean operation = false;
                    for(int i = 0; i < patientList.Count; i++)
                    {
                        if(patientList[i].getPatientName().Equals(textBox1))
                        {
                            operation = true;
                        }
                    }

                    if(operation == true)
                    {
                        MessageBox.Show("Cannot add patient to the List");
                    }
                    else
                    {
                        patientList.Add(patient);
                    }
                }
            }
                
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String message = "Type a name to be deleted.";
            String title = "Delete Patient";
            String defaultPatient = "";

            Object deleteMessage;

            deleteMessage = Interaction.InputBox(message, title, defaultPatient);

            if (deleteMessage.ToString() == "")
            {

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
