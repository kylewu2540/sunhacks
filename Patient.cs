using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pandemic
{
    public class Patient
    {
        public String patientName; //declare our variable names
        public int ID;
        public int income;
        public int patientStatus;
        public int payment;

        public Patient() //constructor
        {
            patientName = "?"; //set the variable names to empty values
            ID = 0;
            income = 0;
            patientStatus = 0;
            payment = 0;
        }

        //following are get methods to return a patient's certain information
        public String getPatientName()
        {
            return patientName;
        }

        public int getID()
        {
            return ID;
        }

        public int getIncome()
        {
            return income;
        }

        public int getPatientStatus()
        {
            return patientStatus;
        }

        public int getPayment()
        {
            return payment;
        }

        //the following set the patient's info to a value specified in the function's argument
        public void setPatientName(String somePatientName)
        {
            patientName = somePatientName;
        }

        public void setID(int someID)
        {
            ID = someID;
        }

        public void setIncome(int someIncome)
        {
            income = someIncome;
        }

        public void setStatus(int someStatus)
        {
            patientStatus = someStatus;
        }

        public void setPayment(int somePayment)
        {
            payment = somePayment;
        }

        //the go to method for converting it to a string, will be used in a display method
        public String toString()
        {
            String result = "Name: " + patientName + " Patient ID: " + ID + " Patient Income: " +
                income + " Patient Status: " + patientStatus;

            return result;
        }
    }
}
