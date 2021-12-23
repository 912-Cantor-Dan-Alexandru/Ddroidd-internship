using System;
using System.Text;
using System.Xml;

namespace SantaClauseConsoleApp
{
    public class Child
    {
        private readonly UniqueId _childId;
        private string _name;
        private DateTime _dateOfBirth;
        private string _address;
        private BehaviorEnum _childsBehavior;
        private Letter _letter;

        public Child()
        {
            _childId = new UniqueId();
            _name = "";
            _dateOfBirth = new DateTime();
            _address = "";
            _childsBehavior = BehaviorEnum.Bad;
            _letter = null;
        }

        public Child(string name, DateTime dateOfBirth, string address,
            BehaviorEnum behavior, Letter letter)
        {
            _childId = new UniqueId();
            _name = name;
            _dateOfBirth = dateOfBirth;
            _address = address;
            _childsBehavior = behavior;
            _letter = letter;
        }

        public Letter Letter
        {
            get { return _letter; }
            set { _letter = value; }
        }

        public BehaviorEnum Behavior
        {
            get { return _childsBehavior; }
        }

        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        public DateTime DateOfBirth
        {
            get { return _dateOfBirth; }
            set { _dateOfBirth = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public UniqueId ChildId
        {
            get { return _childId; }
        }

        public override string ToString()
        {
            StringBuilder childString = new StringBuilder();
            childString.Append("Child object ->\n");
            childString.Append($"Id: {_childId}\n");
            childString.Append($"Name: {_name}\n");
            childString.Append($"Date of Birth: {_dateOfBirth.ToString("MM/dd/yyyy")}\n");
            childString.Append($"Address: {_address}\n");
            childString.Append($"Behavior: {(_childsBehavior == BehaviorEnum.Good ? "Good" : "Bad")}\n\n");
            return childString.ToString();
        }

        public string getCity()
        // Function that returns the city from the address string
        {
            string[] words = _address.Split(",");
            return words[1].Trim();
        }
    }
}
