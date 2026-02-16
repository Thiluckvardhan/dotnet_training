namespace HospitalPatientManagementSystem
{
    // Task 1: Implement Patient class with proper encapsulation
    public class Patient
    {
        // TODO: Add properties with get/set accessors
        // TODO: Add constructor
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Condition { get; set; }
        public Patient(int id, string name, int age, string condition)
        {
            Id = id;
            Name = name;
            Age = age;
            Condition = condition;
        }
    }

    // Task 2: Implement HospitalManager class
    public class HospitalManager
    {
        private Dictionary<int, Patient> _patients = new Dictionary<int, Patient>();
        private Queue<Patient> _appointmentQueue = new Queue<Patient>();

        // Add a new patient to the system
        public void RegisterPatient(int id, string name, int age, string condition)
        {
            // TODO: Create patient and add to dictionary
            Patient patient = new(id, name, age, condition);
            _patients.Add(id, patient);
            System.Console.WriteLine("Patient Added Sucessfully");
        }

        // Add patient to appointment queue
        public void ScheduleAppointment(int patientId)
        {
            Patient patient = null;
            // TODO: Find patient and add to queue
            foreach (var item in _patients)
            {
                if (item.Key == patientId)
                {
                    patient = item.Value;
                }
            }
            _appointmentQueue.Enqueue(patient);
            System.Console.WriteLine($"Appointment Scheduled for {patient.Name}");
        }

        // Process next appointment (remove from queue)
        public Patient ProcessNextAppointment()
        {
            // TODO: Return and remove next patient from queue
            return _appointmentQueue.Dequeue();
        }
        // Find patients with specific condition using LINQ
        public List<Patient> FindPatientsByCondition(string condition)
        {
            // TODO: Use LINQ to filter patients
            List<Patient> patientsByCondition = _patients.Where(p => p.Value.Condition == condition).Select(p => p.Value).ToList();
            return patientsByCondition;
        }
    }
    public class Program
    {
        public static void Main()
        {
            HospitalManager manager = new HospitalManager();
            manager.RegisterPatient(1, "John Doe", 45, "Hypertension");
            manager.RegisterPatient(2, "Jane Smith", 32, "Diabetes");
            manager.ScheduleAppointment(1);
            manager.ScheduleAppointment(2);

            var nextPatient = manager.ProcessNextAppointment();
            Console.WriteLine(nextPatient.Name); // Should output: John Doe

            var diabeticPatients = manager.FindPatientsByCondition("Diabetes");
            Console.WriteLine(diabeticPatients.Count); // Should output: 1

        }
    }
}