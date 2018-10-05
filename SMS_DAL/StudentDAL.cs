using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMS_Entities;
using SMS_Exceptions;
using System.Data.SqlClient;
using System.Configuration;

namespace SMS_DAL
{
    public class StudentDAL
    {
        SqlConnection cn = null;
        SqlCommand cmd = null;
        SqlDataReader dr = null;


        public StudentDAL()
        {
            cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn1"].ConnectionString);
        }
        //select all

        public List<Student> selectAll()
        {
            List<Student> stud = new List<Student>();

            int no = 0;
            try
            {


                //Connect , command , data reader

                //   cmd = new SqlCommand("select * from Tushar.Student1", cn);
                cmd = new SqlCommand("Tushar.USP_SelectAll_StudName", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cn.Open();
                dr = cmd.ExecuteReader();

               while( dr.Read())
                {

                    Student s = new Student();
                    s.Rollno = Convert.ToInt32(dr[0]);
                    s.StudName = dr[1].ToString();
                    s.Gender = dr[2].ToString();
                    s.DOB = Convert.ToDateTime(dr[3]);
                    s.FeesPaid = Convert.ToDouble(dr[4]);
                    s.MobileNO = dr[5].ToString();
                    s.Email = dr[6].ToString();
                    stud.Add(s);
                }
                cn.Close();
            }


            catch (StudentExcpetion ex1)
            {
                throw ex1;
            }

            catch (Exception ex2)
            {
                throw ex2;
            }
            finally
            {
                dr.Close();
                cn.Close();
            }

   

            return stud;
        }


        //Insert

        public int Insert(Student stud)
        {
            int no = 0;
            try
            {


                //Connect , command , data reader

                // cmd = new SqlCommand("insert into Tushar.Student1(StudName, Gender, DOB, FeesPaid , MobileNO , Email) values('" + stud.StudName + "' ,'" + stud.Gender + "' ,'" + stud.DOB + "', "+stud.FeesPaid+",'" + stud.MobileNO + "', '" + stud.Email + "')", cn);
                cmd = new SqlCommand("Tushar.USP_Insert_Student", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StudName", stud.StudName);
                cmd.Parameters.AddWithValue("@Gender", stud.Gender);
                cmd.Parameters.AddWithValue("@DOB", stud.DOB);
                cmd.Parameters.AddWithValue("@FeesPaid", stud.FeesPaid);
                cmd.Parameters.AddWithValue("@MobileNO", stud.MobileNO);
                cmd.Parameters.AddWithValue("@Email", stud.Email);
                cn.Open();
                no = cmd.ExecuteNonQuery();
                cn.Close();
            }

           
            catch (StudentExcpetion ex1)
            {
                throw ex1;
            }

            catch (Exception ex2)
            {
                throw ex2;
            }
            finally
            {
                cn.Close();
            }

            return no;
        }


        //update
        public int Update(Student stud)
        {
            int no = 0;
            try
            {


                //Connect , command , data reader

                cmd = new SqlCommand("update  Tushar.Student1 set StudName='" + stud.StudName + "' , Gender = '" + stud.Gender + "' ,DOB ='" + stud.DOB + "',FeesPaid =" + stud.FeesPaid+" , MobileNO='" + stud.MobileNO + "', Email ='" + stud.Email + "' where Rollno = "+stud.Rollno, cn);
                cn.Open();
                no = cmd.ExecuteNonQuery();
                cn.Close();
            }


            catch (StudentExcpetion ex1)
            {
                throw ex1;
            }

            catch (Exception ex2)
            {
                throw ex2;
            }
            finally
            {
                cn.Close();
            }

            return no;
        }


        //Delete
        public List<Student> Delete(string studName)
        {
            List<Student> studs = new List<Student>();
            try
            {
                int no = 0;
                //Connection,Command, DataReader

                //cmd = new SqlCommand("Delete Shreyash.Student Where RollNo = " + studName, cn);
                cmd = new SqlCommand("Tushar.USP_Delete_Student", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StudName", studName);
                cn.Open();
                no = cmd.ExecuteNonQuery();

            }
            catch (StudentExcpetion ex1)
            {
                throw ex1;
            }
            catch (Exception ex2)
            {
                throw ex2;
            }
            finally
            {
                cn.Close();
            }
            return studs;
        }

    }
  }

