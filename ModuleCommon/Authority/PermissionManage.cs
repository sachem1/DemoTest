using System;
using System.Collections.Generic;
using System.Text;

namespace ModuleCommon.Authority
{
    /// <summary>
    /// 
    /// </summary>
    public class PermissionManage
    {

        /**         
        基于位运算的权限控制不能解决的问题
        一个权限用2的N次冥表示,mysql的一个BIGINT类型占8个字节（8字节 * 8比特位 =64个比特位），则权限集可以表示64-1项权限.
        假如现在的系统需要的权限集超过了64项权限该怎嘛办？
        一种方法：定义多个BIGINT类型字段表示权限集，一个表示64位，多个字段就表示范围扩展了，但增加判断的复杂度
        另一种方法：采用VARCHAR列中的值为可变长字符串。长度可以指定为0到65,535之间的值，用每一位0或1表示true或false,如果权限集超过65,535项，可以考虑使用TEXT类型     
        */
        public bool CheckPermission(int permissionList, int permissionItem)
        {
            return (permissionList & permissionItem) == permissionItem;
        }

        public int AddPermission(int permissionList, int permissionItem)
        {
            return permissionList + permissionItem;
        }

        public int DelPermission(int permissionList, int permissionItem)
        {
            return permissionList & ~permissionItem;
        }
    }
}
