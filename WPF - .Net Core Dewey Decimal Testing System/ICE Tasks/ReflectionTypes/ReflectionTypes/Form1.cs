using System;
using System.Reflection;
using System.Windows.Forms;

namespace ReflectionTypes
{
    public partial class Form1 : Form
    {

        // I could rename this, but I won't...
        public Form1()
        {

            InitializeComponent();

        }

        // Those button things - you press them and things happen
        private void button2_Click(object sender, EventArgs e)
        {

            Type firstClass = Type.GetType("ReflectionTypes.IThinkThisIsAClass");

            richTextBox1.Text = "Class 1\n\n" +
                "Class Full Name: " + firstClass.FullName +
                "\nClass Name: " + firstClass.Name +
                "\nNamespace: " + firstClass.Namespace +
                "\n\nProperties:\n";

            PropertyInfo[] properties = firstClass.GetProperties();

            foreach (PropertyInfo prop in properties)
            {
                richTextBox1.Text += "\n" + prop.PropertyType.Name + " " + prop.Name;
            }

            richTextBox1.Text += "\n\nMethods:\n";

            MethodInfo [] methods = firstClass.GetMethods();

            foreach (MethodInfo method in methods)
            {
                richTextBox1.Text += "\n" + method.ReturnType.Name + " " + method.Name;
            }

            richTextBox1.Text += "\n\nConstructors:\n";

            ConstructorInfo[] constructors = firstClass.GetConstructors();

            foreach (ConstructorInfo con in constructors)
            {
                richTextBox1.Text += "\n" + con.Name;
            }

            Type secondClass = Type.GetType("ReflectionTypes.YeahMustBeAClass");

            richTextBox1.Text += "\n\nClass 2\n\n" +
                "Class Full Name: " + secondClass.FullName +
                "\nClass Name: " + secondClass.Name +
                "\nNamespace: " + secondClass.Namespace +
                "\n\nProperties:\n";

            PropertyInfo[] properties1 = secondClass.GetProperties();

            foreach (PropertyInfo prop in properties1)
            {
                richTextBox1.Text += "\n" + prop.PropertyType.Name + " " + prop.Name;
            }

            richTextBox1.Text += "\n\nMethods:\n";

            MethodInfo[] methods1 = secondClass.GetMethods();

            foreach (MethodInfo method in methods1)
            {
                richTextBox1.Text += "\n" + method.ReturnType.Name + " " + method.Name;
            }

            richTextBox1.Text += "\n\nConstructors:\n";

            ConstructorInfo[] constructors1 = secondClass.GetConstructors();

            foreach (ConstructorInfo con in constructors1)
            {
                richTextBox1.Text += "\n" + con.Name;
            }

        }

        // A text box that is rich $$$,$$$,$$$,$$$,$$$
        private void richTextBox1_TextChanged(object sender, EventArgs e) { }

    }

    // This may be a class - all a matter of perspective though if you think about it?
    public class IThinkThisIsAClass
    {

        // Maybe like properties of an object? I'm just guessing here...
        public static int Id { get; set; }
        public static string FirstName { get; set; }
        public static string LastName { get; set; }
        public static string DateOfBirth { get; set; }

        public IThinkThisIsAClass()
        {

            // Do something interesting
            // I'm a class constructor - so like construct a boat or something

            // Nah let's just set person details
            Id = 100;
            FirstName = "Mike";
            LastName = "Pence";
            DateOfBirth = "01/01/1776";

        }

        public void ImAMethodStuckInAClass()
        {

            // Where's the exit?
            // I'm trapped in a code block!
            // Get me out!

        }

    }

    // This I think is a class
    public class YeahMustBeAClass
    {

        // But more properties? Who would have guessed?
        public int Id { get; set; }
        public double Cost { get; set; }
        public string ProductName { get; set; }
        public string AnotherInterestingProperty { get; set; }

        // Some form of method - but with it's class name as the method name, and no return type?
        // Kinda strange, I'll just have to construct my own method then...
        public YeahMustBeAClass()
        {

            // This looks as if it's setting some kind of variables
            Id = 90;
            Cost = 54999.99;
            ProductName = "Like a boat, who knows? Seems expensive.";
            AnotherInterestingProperty = "Maybe like top speed or something - 100km / hr";

        }

    }

    // 看起來像程序的結尾。
    // Похоже на конец программы.
    // Изгледа да је крај програма.
    // Μοιάζει με το τέλος του προγράμματος.

}
