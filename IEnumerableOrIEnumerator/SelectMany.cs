using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEnumerableOrIEnumerator
{
    class SelectMany
    {
    }
    public class School
    {
        private IList<Class> m_Classes = new List<Class>();
        internal IList<Class> Classes
        {
            get { return m_Classes; }
            set { m_Classes = value; }
        }
    }
    public class Class
    {
        private IList<Student> m_Students = new List<Student>();
        internal IList<Student> Students
        {
            get { return m_Students; }
            set { m_Students = value; }
        }
    }
    public class Student
    {
        public Student(int i, string name)
        {
            m_Sex = i;
            m_Name = name;
        }

        private string m_Name;

        public string Name
        {
            get { return m_Name; }
            set { m_Name = value; }
        }
        private int m_Sex;
        public int Sex
        {
            get { return m_Sex; }
            set { m_Sex = value; }
        }
    }

}
