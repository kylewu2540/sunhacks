using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pandemic
{
    public class Patient
    {
        public String patientName;
        public int ID;
        public int income;
        public int patientStatus;

        public Patient()
        {
            patientName = "?";
            ID = 0;
            income = 0;
            patientStatus = 0;
        }

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
    }
}
