using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMS_Entities;
using SMS_Exceptions;
using SMS_DAL;
namespace SMS_BLL
{
    public class Student_BLL

    {

        StudentDAL Dal = null;

        public Student_BLL()
        {
            Dal = new StudentDAL();
        }


        public List<Student> GetAll()
        {
            List<Student> stud = null;
            try
            {
                stud = Dal.selectAll();
            }
            catch (StudentExcpetion ex1)
            {
                throw ex1;
            }

            return stud;
        }

        public int Add(Student stud)
        {
            int no = 0;
            try
            {
               no = Dal.Insert(stud);
            }
            catch (StudentExcpetion ex1)
            {
                throw ex1;
            }
            catch (Exception ex2)
            {
                throw ex2;
            }
            return no;
        }

        public int Edit(Student stud)
        {
            int no = 0;
            try
            {
              no =  Dal.Update(stud);
            }
            catch (StudentExcpetion ex1)
            {
                throw ex1;
            }
            catch (Exception ex2)
            {
                throw ex2;
            }
            return no;
        }

        public List<Student> Remove(string studName)
        {
            List<Student> stud = new List<Student>();

            try
            {
                stud = Dal.Delete(studName);
            }
            catch (StudentExcpetion ex1)
            {
                throw ex1;
            }
            catch (Exception ex2)
            {
                throw ex2;
            }
            return stud;

        }

    }
}
