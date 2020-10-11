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
        List<Patient> patientList; //declare a patient list list
        private const int MAX = 30; //declare constants
        private const int PAY_AMOUNT = 10000; 
        public Form1(List<Patient> patientRecords)
        {
            this.patientList = patientRecords; //initialize the patient list
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (patientList.Count <= MAX) //when the list is full, don't add and return nothing
            {
                MessageBox.Show("The list is full. Unable to add.");
                return;
            }

            Patient patient = null; //declare a patient and set it to null
            textBox1.Text = String.Empty; //make the textboxes empty
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
                    int idNumber = Int32.Parse(textBox2.Text); //declare and initialize values from the textbox
                    int incomeValue = Int32.Parse(textBox3.Text);
                    int patientStatus = Int32.Parse(textBox4.Text);
                    patient = new Patient(); //set the patient object

                    if(patientStatus >= 0 || patientStatus <= 2) //patient status check
                    {
                        textBox4.Text = ""; //make it empty
                        MessageBox.Show("Please enter a patientStatus between 0 and 2");
                        patientStatus = Int32.Parse(textBox4.Text);
                    }

                    //if execution goes here, then we can set the patient to these values
                    patient.setPatientName(textBox1.Text);
                    patient.setID(idNumber);
                    patient.setIncome(incomeValue);
                    patient.setStatus(patientStatus);
                    MessageBox.Show("Patient added successfully!"); //successful add
                }
                catch(FormatException)
                {
                    //catch statment for formatting issues
                    MessageBox.Show("please enter a valid integer value for ID, income and Status.");
                }

                if(textBox1.Equals(textBox1)) //find a matching patient
                {
                    Boolean operation = false;
                    for(int i = 0; i < patientList.Count; i++)
                    {
                        if(patientList[i].getPatientName().Equals(textBox1))
                        {
                            //if found, set it to true;
                            operation = true;
                        }
                    }

                    if(operation == true)
                    {
                        //cannot add duplicate patient
                        MessageBox.Show("Cannot add patient to the List");
                    }
                    else
                    {
                        patientList.Add(patient);//we can add patient
                    }
                }
            }
                
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String message = "Type a name to be deleted.";
            String title = "Delete Patient";
            String defaultPatient = ""; //declare values for inputbox method from visualbasic reference

            Object myValue;

            myValue = Interaction.InputBox(message, title, defaultPatient);

            if(myValue.ToString() == "") //when user input is empty, nothing can be deleted
            {
                myValue = defaultPatient;
                MessageBox.Show("nothing to input. nothing can be deleted.");
            }
            else
            {
                if(patientList.Count == 0) //if we count nothing in the list, then nothing can be deleted
                {
                    MessageBox.Show("The list is empty. Nothing can be deleted.");
                }
                else
                {
                    for (int i = 0; i < patientList.Count; i++)
                    {
                        if (myValue.Equals(patientList[i].getPatientName()))
                        {
                            patientList.RemoveAt(i); //remove the specified patient
                        }
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.patientList.Sort(); //sort by patient names. This is the default sort method
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.patientList.Sort((x, y) => x.income.CompareTo(y.income)); //sorting method by inceom
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.patientList.Sort((x, y) => x.patientStatus.CompareTo(y.patientStatus)); //sort by status
        }

        private void button6_Click(object sender, EventArgs e)
        {
            patientData.Items.Clear(); //clear items before displaying it

            for(int i = 0; i < patientList.Count; i++) //loop through the items, then display
            {
                patientData.Items.Add(patientList[i].toString()); //display items in listBox
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int i;
            double paymentAmount = 0; //declare and intialize a payment amount

            for(i = 0; i < patientList.Count; i++) //loop through the list
            {
                //when a patient falls between a certain income bracket, their payment varies
                if(patientList[i].getIncome() < 30000 || patientList[i].getIncome() >= 0)
                {
                    MessageBox.Show("Patient Exempt from paying."); //display the message and return nothing
                    return;
                }

                if(patientList[i].getIncome() >= 30000 || patientList[i].getIncome() < 50000)
                {
                    MessageBox.Show("A certain amount will be deducted");
                    
                    switch(patientList[i].getPatientStatus()) //use switch statement for status
                    {
                        case 0:
                            paymentAmount = PAY_AMOUNT * 0.2;
                            break;
                        case 1:
                            paymentAmount = PAY_AMOUNT * 0.1;
                            break;
                        default:
                            break;
                    }
                    return;
                }

                if (patientList[i].getIncome() >= 50000 || patientList[i].getIncome() < 75000)
                {
                    MessageBox.Show("A certain amount will be deducted");

                    switch (patientList[i].getPatientStatus())
                    {
                        case 0:
                            paymentAmount = PAY_AMOUNT * 0.4;
                            break;
                        case 1:
                            paymentAmount = PAY_AMOUNT * 0.2;
                            break;
                        default:
                            break;
                    }
                    
                    return;
                }

                if (patientList[i].getIncome() >= 75000 || patientList[i].getIncome() < 100000)
                {
                    MessageBox.Show("A certain amount will be deducted");

                    switch (patientList[i].getPatientStatus())
                    {
                        case 0:
                            paymentAmount = PAY_AMOUNT * 0.8;
                            break;
                        case 1:
                            paymentAmount = PAY_AMOUNT * 0.4;
                            break;
                        default:
                            break;
                    }
                    return;
                }

                //this assumes people making over 100k will receive this fixed rate
                else
                {
                    MessageBox.Show("A certain amount will be deducted");

                    switch (patientList[i].getPatientStatus())
                    {
                        case 0:
                            paymentAmount = PAY_AMOUNT * 1.0;
                            break;
                        case 1:
                            paymentAmount = PAY_AMOUNT * 0.8;
                            break;
                        default:
                            break;
                    }
                    return;
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.patientList.Sort((x, y) => x.ID.CompareTo(y.ID)); //sort the ID's
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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
