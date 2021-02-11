using System;
using System.Collections;
using System.Collections.Generic;

namespace StudentSpace
{
    public class Student : IComparable<Student>
    {
        public string Name { get; private set; }
        public string TestName { get; private set; }
        public DateTime TestDate { get; private set; }
        public int TestMark { get ; private set; }


        public Student(string Name)
        {
            this.Name = Name;
        }

        public void PushTestMark(string TestName, int TestMark)
        {
            this.TestName = TestName;
            this.TestMark = TestMark;
            TestDate = DateTime.Today;
        }

        public int CompareTo(Student other)
        {
            if (this.TestMark > other.TestMark)
                return 1;
            else if (this.TestMark < other.TestMark)
                return -1;
            else
                return 0;
        }

        public override string ToString()
        {
            return $"{this.Name} получил за тест {TestMark} баллов ";
        }

        
    }
}
