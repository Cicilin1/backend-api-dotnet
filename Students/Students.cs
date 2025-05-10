namespace backend_api_dotnet.Estudents
{
    public class Student
    {
        public Guid Id { get; init; }
        public string Name { get; private set; }
        public bool IsActive { get; private set; }

        public Student(string name)
        {
            Name = name;
            Id = Guid.NewGuid();
            IsActive = true;

        }
    }
}
 