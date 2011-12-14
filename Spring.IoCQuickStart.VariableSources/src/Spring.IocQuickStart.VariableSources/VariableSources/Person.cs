namespace Example
{
    public class Person
    {
        private string Name { get; set; }
        private int Age { get; set; }

        public override string ToString()
        {
            return string.Format("{0} ({1})", Name, Age);
        }
    }
}