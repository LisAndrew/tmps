using System;


namespace Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            Patient patient = new PatientBuilder()
                .Name("Алексей")
                .Surname("Смирнов")
                .Address("Studentilor 1/1")
                .Diagnosis("Синдром отличника")
                .Treatment("Лечения не существует")
                .Build();
                 DisplayValues(patient);

            Patient patient2 = patient.GetClone();
            patient2.Name = "Владимир";
            patient2.Surname = "Степанов";

            DisplayValues(patient2);
            

            Console.ReadKey();
        }
        public static void DisplayValues(Patient patient)
        {
            Console.WriteLine("\nИмя пациента: " + patient.Name);
            Console.WriteLine("Фамилия пациента: " + patient.Surname);
            Console.WriteLine("Адрес пациента: " + patient.Address);
            Console.WriteLine("Диагноз: " + patient.Diagnosis);
            Console.WriteLine("Лечение: " + patient.Treatment);
        }
    }
   

    public class Patient
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public string Diagnosis { get; set; }
        public string Treatment { get; set; }
        
        public Patient GetClone()
        {
            return (Patient)this.MemberwiseClone();
        }
    }

    public class PatientBuilder
    {
        private readonly Patient _patient;

        public PatientBuilder()
        {
            _patient = new Patient();
        }

        public PatientBuilder Name(string name)
        {
            _patient.Name = name;
            return this;
        }

        public PatientBuilder Surname(string surname)
        {
            _patient.Surname = surname;
            return this;
        }

        public PatientBuilder Address(string address)
        {
            _patient.Address = address;
            return this;
        }


        public PatientBuilder Diagnosis(string diagnosis)
        {
            _patient.Diagnosis = diagnosis;
            return this;
        }
        public PatientBuilder Treatment(string treatment)
        {
            _patient.Treatment = treatment;
            return this;
        }
        public Patient Build()
        {
            return _patient;
        }
    }
}



