using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClearTempFiles
{
    class Program
    {
        public void DeleteFiles(string[] deleteList , bool directory)
        {
            DateTime currentDate = DateTime.Now;
            DateTime mondayOfLastWeek = currentDate.AddDays(-(int)currentDate.DayOfWeek - 6);
            DateTime lastModifiedDate = DateTime.MinValue;

            if (!directory)
            {
                foreach (string item in deleteList)
                {
                    lastModifiedDate = File.GetLastWriteTime(item);
                    try
                    {
                        //remove after test
                        File.Delete(item);
                        Console.WriteLine("File Name : " + item + " Deleted Successfully");
                        //
                        if (lastModifiedDate < mondayOfLastWeek && lastModifiedDate != DateTime.MinValue)
                        {
                            File.Delete(item);
                            Console.WriteLine("File Name : " + item + " Deleted Successfully");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            else
            {
                foreach (string item in deleteList)
                {
                    lastModifiedDate = File.GetLastWriteTime(item);

                    try
                    {
                        //remove after test
                        Directory.Delete(item, true);
                        Console.WriteLine("Directory Name : " + item + " Deleted Successfully");
                        //
                        if (lastModifiedDate < mondayOfLastWeek && lastModifiedDate != DateTime.MinValue)
                        {
                            Directory.Delete(item , true);
                            Console.WriteLine("Directory Name : " + item + " Deleted Successfully");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

        }
        static void Main(string[] args)
        {
            Program obj = new Program();

            //ServerImportLog_
            //string serverImportLog_ = @"C:\ErrorLog\ServerImportLog_";
            //Service_
            //string errorSercice_ = @"C:\ErrorLog\Server_";
            //ServerImportDetails
            //string serverImportDetails = @"C:\ErrorLog\ServerImportDetail_";
            //ServerCrarsh_
            //string serverCrarsh_ = @"C:\ErrorLog\ServerCrarsh_";
            //ServerImportPolicyLog_
            /*
            string allFiles = @"C:\ErrorLog\ServerImportPolicyLog_";
            string caravus = @"C:\ErrorLog\ServerImportPolicyLog_\Caravus";
            string lG_Planning = @"C:\ErrorLog\ServerImportPolicyLog_\LG Planning Group";
            string capital_Benefit = @"C:\ErrorLog\ServerImportPolicyLog_\Capital Benefit Group";
            string vanguard_Benefit = @"C:\ErrorLog\ServerImportPolicyLog_\Vanguard Benefit BG";
            string employee_Benefit = @"C:\ErrorLog\ServerImportPolicyLog_\Employee Benefit Associates";
            string toatal_Capital_Planning = @"C:\ErrorLog\ServerImportPolicyLog_\Total Capital Planning 2020";
            string group_Health_Solutions = @"C:\ErrorLog\ServerImportPolicyLog_\Group Health Solutions";
            */
            //Reports
            string reports = @"E:\FileManager\Reports";

            //Temp Files
            //string tempFiles = @"C:\Users\COMM-L~1\AppData\Local\Temp\3";   //************Uncomment after testing*************
            //test
            //string tempFiles = @"C:\Users\HP\AppData\Local\Temp";
            string tempFiles = @"C:\Users\Dell\AppData\Local\Temp";
            //-------------Production Path End--------------------------------------------

            /*
            //serverImportLog_
            Console.WriteLine("Start Deleting Files from serverImportLog_ : " + DateTime.Now);
            string[] serverImportLog_List = Directory.GetFiles(serverImportLog_, "*.txt");
            obj.DeleteFiles(serverImportLog_List , false);
            Console.WriteLine("**serverImportLog_ Process End**");

            //Service txt
            Console.WriteLine("Start Deleting Files from Sercice_ : " + DateTime.Now);
            string[] service_List = Directory.GetFiles(errorSercice_ , "*.txt");
            obj.DeleteFiles(service_List , false);
            Console.WriteLine("**Sercice_ Process End**");

            //ServerImportDetails
            Console.WriteLine("Start Deleting Files from serverImportDetails : " + DateTime.Now);
            string[] serverImportDetail_List = Directory.GetFiles(serverImportDetails , "*.txt");
            obj.DeleteFiles(serverImportDetail_List, false);
            Console.WriteLine("**serverImportDetails Process End**");

            //ServerCrarsh_
            Console.WriteLine("Start Deleting Files from serverCrarsh_ : " + DateTime.Now);
            string[] ServerCrarsh_List = Directory.GetFiles(serverCrarsh_ , "*.txt");
            obj.DeleteFiles(ServerCrarsh_List , false);
            Console.WriteLine("**serverCrarsh_ Process End**");

            //ServerImportPolicyLog_
            //all files
            Console.WriteLine("Start Deleting Files from ServerImportPolicyLog_ all Files : " + DateTime.Now);
            string[] allFiles_List = Directory.GetFiles(allFiles , "*.txt");
            obj.DeleteFiles(allFiles_List , false);
            //string[] allFiles_Directory_List = Directory.GetDirectories(allFiles);
            //obj.DeleteFiles(allFiles_Directory_List , true);
            Console.WriteLine("**All Files Process End**");

            //caravus
            Console.WriteLine("Start Deleting Directory from caravus : " + DateTime.Now);
            string[] caravus_List = Directory.GetDirectories(caravus);
            obj.DeleteFiles(caravus_List , true);
            Console.WriteLine("**caravus Process End**");

            //lG_Planning
            Console.WriteLine("Start Deleting Directory from lG_Planning : " + DateTime.Now);
            string[] lG_Planning_List = Directory.GetDirectories(lG_Planning);
            obj.DeleteFiles(lG_Planning_List, true);
            Console.WriteLine("**lG_Planning Process End**");

            //capital_Benefit
            Console.WriteLine("Start Deleting Directory from capital_Benefit : " + DateTime.Now);
            string[] capital_Benefit_List = Directory.GetDirectories(capital_Benefit);
            obj.DeleteFiles(capital_Benefit_List, true);
            Console.WriteLine("**capital_Benefit Process End**");

            //vanguard_Benefit
            Console.WriteLine("Start Deleting Directory from vanguard_Benefit : " + DateTime.Now);
            string[] vanguard_Benefit_List = Directory.GetDirectories(vanguard_Benefit);
            obj.DeleteFiles(vanguard_Benefit_List , true);
            Console.WriteLine("**vanguard_Benefit Process End**");

            //employee_Benefit
            Console.WriteLine("Start Deleting Directory from employee_Benefit : " + DateTime.Now);
            string[] employee_Benefit_List = Directory.GetDirectories(employee_Benefit);
            obj.DeleteFiles(employee_Benefit_List , true);
            Console.WriteLine("**employee_Benefit Process End**");

            //toatal_Capital_Planning
            Console.WriteLine("Start Deleting Directory from toatal_Capital_Planning : " + DateTime.Now);
            string[] toatal_Capital_Planning_List = Directory.GetDirectories(toatal_Capital_Planning);
            obj.DeleteFiles(toatal_Capital_Planning_List , true);
            Console.WriteLine("**toatal_Capital_Planning Process End**");

            //group_Health_Solutions
            Console.WriteLine("Start Deleting Directory from group_Health_Solutions : " + DateTime.Now);
            string[] group_Health_Solutions_List = Directory.GetDirectories(group_Health_Solutions);
            obj.DeleteFiles(group_Health_Solutions_List, true);
            Console.WriteLine("**group_Health_Solutions Process End**");


            //Report
            Console.WriteLine("Start Deleting Files from Report : " + DateTime.Now);
            string[] reports_List = Directory.GetFiles(reports, "*.*");
            obj.DeleteFiles(reports_List, false);
            Console.WriteLine("**Report Process End**");
            */

            //Temp files
            Console.WriteLine("Start Deleting Files from Temp_Files" + DateTime.Now);
            string[] tempFiles_AllFile_List = Directory.GetFiles(tempFiles , "*.*");
            obj.DeleteFiles(tempFiles_AllFile_List, false);
            Console.WriteLine("**Temp_Files Process End**");

            Console.WriteLine("Start Deleting Files from Temp_Files" + DateTime.Now);
            string[] tempFiles_Directory_List = Directory.GetDirectories(tempFiles);
            obj.DeleteFiles(tempFiles_Directory_List , true);
            Console.WriteLine("**Temp_Files Process End**");

            Console.ReadKey();

        }


    }
}
