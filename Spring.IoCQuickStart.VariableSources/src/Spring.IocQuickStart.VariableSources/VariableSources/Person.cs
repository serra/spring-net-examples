namespace Example
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return string.Format("{0} ({1})", Name, Age);
        }
    }
}