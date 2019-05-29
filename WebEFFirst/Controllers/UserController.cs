using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebEFFirst.DbContent;
using WebEFFirst.Models;

namespace WebEFFirst.Controllers
{
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {
        [Route("all")]
        public IEnumerable<User> GetUsers()
        {
            using (var emrDb = new EMRDbContext())
            {
                return emrDb.Users.ToList();
            }
        }

        [Route("id/{id}")]
        public User GetUser(string id)
        {
            using (var emrDb = new EMRDbContext())
            {
                return emrDb.Users.Where(o => o.Id == id).FirstOrDefault();
            }
        }

        [HttpPost]
        [Route("delete")]
        public int DeleteUser(string id)
        {
            using (var emrDb = new EMRDbContext())
            {

                var firstEntity = emrDb.Users.FirstOrDefault(o => o.Id == id);
                if (firstEntity != null)
                {
                    emrDb.Users.Remove(firstEntity);
                    return emrDb.SaveChanges();
                }
                else
                    return 0;
            }
        }

        /// <summary>
        /// 更新用户信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("update")]
        public int ModifyUser([FromBody] User user)
        {
            if (user != null)
            {
                using (var emrDb = new EMRDbContext())
                {
                    var firstEntity = emrDb.Users.FirstOrDefault(o => o.Id == user.Id);
                    if (firstEntity != null)
                    {
                        firstEntity.Id = user.Id;
                        firstEntity.Name = user.Name;
                        firstEntity.Password = user.Password;
                        return emrDb.SaveChanges();
                    }
                    else
                        return 0;
                }
            }
            return 0;
        }


        [HttpPost]
        [Route("insert")]
        public int CreateUser([FromBody]User user)
        {
            if (user != null)
            {
                using (var emrDb = new EMRDbContext())
                {
                    if (user != null)
                    {
                        emrDb.Users.Add(user);
                        return emrDb.SaveChanges();
                    }
                    return 0;
                }
            }
            return 0;
        }
    }
}