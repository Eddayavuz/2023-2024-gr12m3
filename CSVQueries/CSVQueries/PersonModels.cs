namespace CSVQueries
{
    public class PersonModel
    {

        // Index property
        public int Index { get; set; }

        // User Id property
        public string UserId { get; set; }

        // First Name property
        public string FirstName { get; set; }

        // Last Name property
        public string LastName { get; set; }

        // Sex property
        public string Sex { get; set; }

        // Email property
        public string Email { get; set; }

        // Phone property
        public string Phone { get; set; }

        // Date of Birth property
        public DateTime DateOfBirth { get; set; }

        // Job Title property
        public string JobTitle { get; set; }

        // now we have to map our properties bc in the CSV file some titles have space.



    }
}

