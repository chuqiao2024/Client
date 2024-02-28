using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Models
{
    public class MenuBar
    {
        /// <summary>
        /// 实例化对象时，同时实列化子菜单对象
        /// </summary>
        public MenuBar()
        {
            MenuItems = new List<MenuBar>();
        }
        /// <summary>
        /// 菜单名称
        /// </summary>
        public string? MenuName {  get; set; }

        /// <summary>
        /// 菜单图标
        /// </summary>
        public string? MenuIcon {  get; set; }

        /// <summary>
        /// 菜单导航路径
        /// </summary>
        public string? MenuPath {  get; set; }

        /// <summary>
        /// 子菜单列表
        /// </summary>
        public List<MenuBar>? MenuItems { get; set; }    
    }
}
