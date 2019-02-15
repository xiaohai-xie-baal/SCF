using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Senparc.Scf.Service;

namespace Senparc.Areas.Admin.Areas.Admin.Pages
{
    public class AdminUserInfo_EditModel : BaseAdminPageModel
    {
        /// <summary>
        /// Id
        /// </summary>
        [BindProperty]
        public int Id { get; set; }
        /// <summary>
        /// 密码
        /// </summary>		
        public string Password { get; set; }
        /// <summary>
        /// 密码盐
        /// </summary>		
        public string PasswordSalt { get; set; }
        /// <summary>
        /// 真实姓名
        /// </summary>		
        public string RealName { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>		
        public string Phone { get; set; }
        /// <summary>
        /// 备注
        /// </summary>		
        public string Note { get; set; }
        /// <summary>
        /// 当前登录时间
        /// </summary>		
        public DateTime ThisLoginTime { get; set; }
        /// <summary>
        /// 当前登录IP
        /// </summary>		
        public string ThisLoginIP { get; set; }
        /// <summary>
        /// 上次登录时间
        /// </summary>		
        public DateTime LastLoginTime { get; set; }
        /// <summary>
        /// 上次登录Ip
        /// </summary>		
        public string LastLoginIP { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>		
        public DateTime AddTime { get; set; }
        public bool IsEdit { get; set; }

        private readonly AdminUserInfoService _adminUserInfoService;


        public AdminUserInfo_EditModel(AdminUserInfoService adminUserInfoService)
        {
            _adminUserInfoService = adminUserInfoService;
        }

        public IActionResult OnGet(int id)
        {
            bool isEdit = id > 0;
            if (isEdit)
            {
                var userInfo = _adminUserInfoService.GetAdminUserInfo(id);
                if (userInfo == null)
                {
                    throw new Exception("信息不存在！");//TODO:临时
                    return RenderError("信息不存在！");
                }
                UserName = userInfo.UserName;
                Note = userInfo.Note;
                Id = userInfo.Id;
            }
            IsEdit = isEdit;
            return Page();
        }

        public IActionResult OnPost(int id)
        {
            bool isEdit = id > 0;
            //this.Validator(model.UserName, "用户名", "UserName", false)
            //    .IsFalse(z => this._adminUserInfoService.CheckUserNameExisted(model.Id, z), "用户名已存在！", true);

            //if (!isEdit || !model.Password.IsNullOrEmpty())
            //{
            //    this.Validator(model.Password, "密码", "Password", false).MinLength(6);
            //}

            //if (!ModelState.IsValid)
            //{
            //    return View(model);
            //}

            //AdminUserInfo userInfo = null;
            //if (isEdit)
            //{
            //    userInfo = _adminUserInfoService.GetAdminUserInfo(model.Id);
            //    if (userInfo == null)
            //    {
            //        return RenderError("信息不存在！");
            //    }
            //}
            //else
            //{
            //    var passwordSalt = DateTime.Now.Ticks.ToString();
            //    userInfo = new AdminUserInfo()
            //    {
            //        PasswordSalt = passwordSalt,
            //        LastLoginTime = DateTime.Now,
            //        ThisLoginTime = DateTime.Now,
            //        AddTime = DateTime.Now,
            //    };
            //}

            //if (!model.Password.IsNullOrEmpty())
            //{
            //    userInfo.Password = this._adminUserInfoService.GetPassword(model.Password, userInfo.PasswordSalt, false);//生成密码
            //}

            //await this.TryUpdateModelAsync(userInfo, "", z => z.Note, z => z.UserName);
            //this._adminUserInfoService.SaveObject(userInfo);

            //base.SetMessager(MessageType.success, $"{(isEdit ? "修改" : "新增")}成功！");
            //return RedirectToAction("Index");

            return Page();
        }
    }
}