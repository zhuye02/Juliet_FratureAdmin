using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShiningInfomation.Entity;
using System.Data.Entity;
using PagedList;

namespace ShiningInfomation.Controllers
{
    public class SearchController : Controller
    {
        StudentInfoManagementEntities se = new StudentInfoManagementEntities();
        // GET: Search

        public DbSet<StudentInfo> Students { get; set; }
        private StudentInfoManagementEntities db = new StudentInfoManagementEntities();
      
        public ActionResult Search(string Search_name, string Search_team, string Search_group, int ? page)
        {
            if (!String.IsNullOrEmpty(Search_name) || !String.IsNullOrEmpty(Search_team) || !String.IsNullOrEmpty(Search_group))
            {
                var studentInfo = db.StudentInfo.Include(s => s.StudentID);
                //return View(studentInfo.ToList());

                int pageNumber = page ?? 1;
                int pageSize = 2;
                var persons = db.StudentInfo.ToList();
                return View(persons.ToPagedList(pageNumber, pageSize));
            }
            else
            {
                var SearchList = from u in se.StudentInfo
                                 where 1 != 1
                                 select u;

                int pageNumber = page ?? 1;
                int pageSize = 2;
                var persons = db.StudentInfo.ToList();
                return View(persons.ToPagedList(pageNumber, pageSize));
             
            }
        }
    }
}