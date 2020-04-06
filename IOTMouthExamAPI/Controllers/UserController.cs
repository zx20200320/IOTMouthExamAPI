using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Model;
using DAL;

namespace IOTMouthExamAPI.Controllers
{
    public class UserController : ApiController
    {
        //实例化dal
        UserDal d = new UserDal();
        [HttpGet]
        /// <summary>
        /// 显示员工列表
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public List<UserInfo> Show(string name="",int id=-1)
        {
            return d.Show(name,id);
        }
        /// <summary>
        /// 绑定下拉列表
        /// </summary>
        /// <returns></returns>
        //public List<Depart> GetBind()
        //{
        //    return d.Bind();
        //}
        /// <summary>
        /// 添加部门
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        [HttpPost]
        public bool AddDepart(Depart m)
        {
            return d.AddDepart(m);
        }
        /// <summary>
        /// 添加员工
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public bool AddUser(UserInfo user)
        {
            return d.AddUser(user);
        }
        /// <summary>
        /// 删除员工
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DelUser(int id)
        {
            return d.DelUser(id);
        }
    }
}
