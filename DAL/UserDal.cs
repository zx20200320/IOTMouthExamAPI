using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DAL
{
    public class UserDal
    {
        /// <summary>
        /// 显示员工列表
        /// </summary>
        /// <returns></returns>
        public List<UserInfo> Show(string name="",int id=-1)
        {
            string sql = "select UserInfo.ID,UName,RealName,Phone,Email,Name,Status from UserInfo join Depart on Depart.ID=DepartId";
            List<UserInfo> list = SqlDbHelper.GetList<UserInfo>(sql);
            if(name!=null)
            {
                list = list.Where(m=>m.RealName.Contains(name)).ToList();
            }
            if(id!=-1)
            {
                list = list.Where(m=>m.DepartId.Equals(id)).ToList();
            }
            return list;
        }
        /// <summary>
        /// 绑定下拉列表
        /// </summary>
        /// <returns></returns>
        public List<Depart> Bind()
        {
            List<Depart> list = SqlDbHelper.GetList<Depart>("select * from Depart");
            return list;
        }
        /// <summary>
        /// 添加部门
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public bool AddDepart(Depart m)
        {
            string sql = $"insert into Depart(Name) values({m.Name})";
            bool h = SqlDbHelper.ExecuteNonQuery(sql);
            return h;
        }
        /// <summary>
        /// 添加员工
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool AddUser(UserInfo user)
        {
            string sql = $"insert into UserInfo values('{user.UName}','{user.RealName}','{user.Email}','{user.Phone}',{user.DepartId},{user.Status})";
            bool h = SqlDbHelper.ExecuteNonQuery(sql);
            return h;
        }
        /// <summary>
        /// 删除员工
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DelUser(int id)
        {
            string sql = $"Delete from UserInfo where Id={id}";
            bool h = SqlDbHelper.ExecuteNonQuery(sql);
            return h;
        }
        
    }
}
